using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System.IO;
using TentHouseRentals.BusinessAccess;
using TentHouseRentals.Model;
using iTextSharp.tool.xml;
using TentHouseRentals.Utilities;
using System.Web.Services;
using System.Globalization;

namespace TentHouseRentals.Web
{
    public partial class Reports : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void btnClickDownloadReportProducts_Click(object sender, EventArgs e)
        {
            try { 
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] {
                              new DataColumn("ProductId", typeof(int)),
                              new DataColumn("ProductTitle", typeof(string)),
                              new DataColumn("Available", typeof(int)),
                              new DataColumn("OnRent", typeof(int)),
                              new DataColumn("PricePerDay", typeof(int)),
            });
            List<Products> products = UserBusiness.GetProducts();

            for(int i=0;i<products.Count; i++)
            {
                dt.Rows.Add(products[i].ID , products[i].Title, products[i].QuantityPresent , products[i].QuantityBooked,products[i].PricePerDay);
            }
           
            using (StringWriter sw = new StringWriter())
            {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<table width='100%' border='1'' cellspacing='0' cellpadding='4'>");
                        sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>PRODUCT SHEET</b></td></tr>");
                        sb.Append("<tr><td colspan = '2'></td></tr>");
                        sb.Append("<tr><td align = 'right'><b>Date: </b>");

                        DateTime currentDateTime = DateTime.Now;
                        string currentDateTime12Hour = currentDateTime.ToString("MM/dd/yyyy hh:mm tt");
                        sb.Append(currentDateTime12Hour);
                        sb.Append(" </td></tr>");
                        sb.Append("</table>");
                        sb.Append("<br />");
                        //Generate Invoice (Bill) Items Grid.
                        sb.Append("<table width='100%'  border='1' cellspacing='0' cellpadding='4'>");
                        sb.Append("<tr>");
                        foreach (DataColumn column in dt.Columns)
                        {
                            sb.Append("<td style = 'background-color: #D20B0C'>");
                            sb.Append(column.ColumnName);
                            sb.Append("</td>");
                        }
                        sb.Append("</tr>");
                        foreach (DataRow row in dt.Rows)
                        {
                            sb.Append("<tr>");
                            foreach (DataColumn column in dt.Columns)
                            {
                                sb.Append("<td>");
                                sb.Append(row[column]);
                                sb.Append("</td>");
                            }
                            sb.Append("</tr>");
                        }

                        sb.Append("</table>");
                        StringReader sr = new StringReader(sb.ToString());

                        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        pdfDoc.Close();
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.Write(pdfDoc);
                        Response.End();
                    }

                }
            }
            catch (Exception ex)
            {
                CommonFunctions.WriteLogFile(ex);
            }
        }

        protected void btnDownloadDetail(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                List<Products> products = UserBusiness.GetProducts();
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                document.Open();

                for (int i=0;i<products.Count; i++)
                {
                    List<TransactionsModel2> transactionTable = GetProductTransactions(products[i].ID);

                    PdfPTable tableProduct = new PdfPTable(2);

                    // Create a cell for the image
                    PdfPCell imageCell = new PdfPCell();
                    imageCell.Border = PdfPCell.NO_BORDER; // Remove cell border

                    // Create an Image instance
                    string imagePath = Server.MapPath("~/ImageFolder/") + products[i].Image;

                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagePath);
                    image.ScaleAbsolute(120f, 120f);
                    // Add the image to the cell
                    imageCell.AddElement(image);

                 
                    PdfPCell listCell = new PdfPCell();
                    listCell.Border = PdfPCell.NO_BORDER; // Remove cell border

                    // Create a list
                    List list = new List(List.ORDERED); // You can use List.UNORDERED for an unordered list
                    list.Add(new iTextSharp.text.ListItem(""));
                    list.Add(new iTextSharp.text.ListItem(""));

                    listCell.AddElement(list);
                    tableProduct.AddCell(imageCell);
                    tableProduct.AddCell(listCell);

                    document.Add(tableProduct);

                    Paragraph paragraph = new Paragraph("ITEM NAME :" + products[i].Title);
                    paragraph.IndentationLeft = 50f;
                    document.Add(paragraph);
                   /* string imagePath = Server.MapPath("~/ImageFolder/") + products[i].Image;
          
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagePath);

                    image.ScaleAbsolute(120f, 120f); // Set width and height as needed
                    image.IndentationLeft = 150f;*/
                    Paragraph paragraph2 = new Paragraph("AVAILABLE QUANTITY :" + products[i].QuantityPresent);
                    paragraph2.IndentationLeft = 50f;
                    document.Add(paragraph2);
                    document.Add(new Paragraph(" "));
                   
                    PdfPTable table = new PdfPTable(6);
                    table.AddCell("ID");
                    table.AddCell("DATE-TIME");
                    table.AddCell("CUSTOMER");
                    table.AddCell("PRODUCT");
                    table.AddCell("TYPE");
                    table.AddCell("QTY");

                    if(transactionTable!=null)
                    {
                        foreach (var transaction in transactionTable)
                        {
                           
                                table.AddCell(transaction.TransactionID.ToString());
                            string formattedDateTime = transaction.TransactionDateTime;
                            if (DateTime.TryParseExact(transaction.TransactionDateTime, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDateTime))
                            {
                               formattedDateTime = parsedDateTime.ToString("MM/dd/yyyy hh:mm tt"); 
                            }
                            table.AddCell(formattedDateTime);
                            table.AddCell(transaction.CustomerName.ToString());
                                table.AddCell(transaction.ProductName.ToString());
                                table.AddCell(transaction.Type.ToString());
                                table.AddCell(transaction.Quantity.ToString());
                        }
                    }

                    else
                    {
                        PdfPCell cellWithRowspan6 = new PdfPCell(new Phrase("No transactions Found"));
                        cellWithRowspan6.Rowspan = 6;
                        table.AddCell(cellWithRowspan6);
                    }

                    document.Add(table);
                }
                document.Close();
                writer.Close();
                Response.ContentType = "pdf/application";
                Response.AddHeader("content-disposition",
                "attachment;filename=DetailReport.pdf");
                Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            }
        }

        [WebMethod]
        public static List<TransactionsModel2> GetProductTransactions(int productId)
        {
            return UserBusiness.GetProductTransactions(productId);
        }


        [WebMethod]
        public static Products GetProduct(int id)
        {
            Products products = UserBusiness.GetProduct(id);
            return products;
        }

    }

}