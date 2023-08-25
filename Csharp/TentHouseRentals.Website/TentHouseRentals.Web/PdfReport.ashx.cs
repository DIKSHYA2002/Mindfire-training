using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Globalization;
using TentHouseRentals.BusinessAccess;
using TentHouseRentals.Model;
using System.Xml.Linq;
using System.Web.SessionState;

namespace TentHouseRentals.Web
{
    /// <summary>
    /// Summary description for PdfReport
    /// </summary>
    public class PdfReport : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string documentType = context.Request.Params["type"];
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                document.Open();
                if (documentType == "product")
                {
                    List<Products> products = UserBusiness.GetProducts();

                    PdfPTable productTable = new PdfPTable(5);
                    productTable.AddCell("ID");
                    productTable.AddCell("TITLE");
                    productTable.AddCell("QUANTITY PRESENT");
                    productTable.AddCell("ON RENT");
                    productTable.AddCell("PRICE/DAY");

                    foreach (var productss in products)
                    {

                        productTable.AddCell(productss.ID.ToString());
                        productTable.AddCell(productss.Title.ToString());
                        productTable.AddCell(productss.QuantityPresent.ToString());
                        productTable.AddCell(productss.QuantityBooked.ToString());
                        productTable.AddCell(productss.PricePerDay.ToString());
                    }
                    document.Add(productTable);
                }
                else if (documentType == "detail")
                {

                    List<Products> products = UserBusiness.GetProducts();
                    for (int i = 0; i < products.Count; i++)
                    {
                        List<Transactions> transactionTable = Reports.GetProductTransactions(products[i].ID);

                        if(transactionTable != null )
                        {
                            if(transactionTable.Count > 0)
                            {
                                PdfPTable tableProduct = new PdfPTable(2);
                                PdfPCell imageCell = new PdfPCell();
                                imageCell.Border = PdfPCell.NO_BORDER;

                                string imagePath = System.Web.HttpContext.Current.Server.MapPath("~/ImageFolder/") + products[i].Image;

                                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagePath);
                                image.ScaleAbsolute(120f, 120f);

                                imageCell.AddElement(image);
                                PdfPCell listCell = new PdfPCell();
                                listCell.Border = PdfPCell.NO_BORDER;

                                List list = new List(List.ORDERED);
                                list.Add(new iTextSharp.text.ListItem(""));
                                list.Add(new iTextSharp.text.ListItem(""));

                                listCell.AddElement(list);
                                tableProduct.AddCell(imageCell);
                                tableProduct.AddCell(listCell);

                                document.Add(tableProduct);

                            }
                            
                        }
                      
                       

                        Paragraph paragraph = new Paragraph("ITEM NAME :" + products[i].Title);
                        paragraph.IndentationLeft = 50f;
                        document.Add(paragraph);
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

                        if (transactionTable != null)
                        {
                            foreach (var transaction in transactionTable)
                            {

                                table.AddCell(transaction.TransactionID.ToString());
                                string formattedDateTime = transaction.TransactionDateTime.ToString();
                                if (DateTime.TryParseExact(formattedDateTime, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDateTime))
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

                        document.Add(table);
                    }

                }
                byte[] bytesInStream = ms.ToArray();
                ms.Write(bytesInStream, 0, bytesInStream.Length);
                document.Close();
                writer.Close();
                context.Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
                context.Response.ContentType = "application/pdf";
                context.Response.AddHeader("content-disposition", "attachment;filename=DetailReport.pdf");
                context.Response.BinaryWrite(bytesInStream);
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}