const loadingGif = `<div class="transaction-individual"><img src="./ImageFolder/Loading.gif" style="width:5rem; height:5rem"></div>`;
$(document).ready(function () {
    getProductList();
    function getProductList() {
        $.ajax({
            type: "POST",
            url: "ProductsPage.aspx/GetProducts",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: "false",
            success: function (response) {
                response.d.forEach((item => {
                    var $newDiv = `
                    <option value="${item.ID}">${item.Title}</option>
               `;
                    $("#SelectProductName").append($newDiv);
                }))
                getProduct1();
            },
            Error: function (response) {
                alert(response);
            }
        });
    }
    function getProduct1() {
        var selectedId = SelectProductName.value;
        var arr = { id: selectedId };
        $.ajax({
            type: "POST",
            url: "Reports.aspx/GetProduct",
            data: JSON.stringify(arr),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: "false",
            success: function (response) {
                $(".product").remove();
                var $newDiv = `<div class="product">
                   <img src="./ImageFolder/${response.d.Image}"/>
                   <div class="product-details">
                   <div class="product-title info">Name: ${response.d.Title}</div>
                   <div class="product-present-quantity info">Quantity : ${response.d.QuantityPresent}</div>
                   </div> 
               </div>`;
                $(".product-details").append($newDiv);
                getTransactionList(response.d.ID);
            },
            Error: function (response) {
                alert(response);
            }
        });

    }

    $("#productReports").on("change", "#SelectProductName", function (e) {
        e.preventDefault();
        var selectedId = SelectProductName.value;
        var arr = { id: selectedId };
        $(".product-details").html(loadingGif);
        $.ajax({
            type: "POST",
            url: "Reports.aspx/GetProduct",
            data: JSON.stringify(arr),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: "false",
            success: function (response) {
                $(".product-details").empty();
                $(".product").remove();
                var $newDiv = `<div class="product">
                   <img src="./ImageFolder/${response.d.Image}"/>
                   <div class="product-details">
                   <div class="product-title info">Name: ${response.d.Title}</div>
                   <div class="product-present-quantity info">Quantity : ${response.d.QuantityPresent}</div>
                   </div> 
               </div>`;
                $(".product-details").append($newDiv);
                getTransactionList(response.d.ID);
            },
            Error: function (response) {
                alert(response);
            }
        });
    })

    $(".report-action").on("click", "#btnProductReport", function (e) {
        e.preventDefault();
        window.location.href = "PdfReport.ashx?type=" + "product";
    })
    $(".report-action").on("click", "#btnProductDetailedReport", function (e) {
        e.preventDefault();
        window.location.href = "PdfReport.ashx?type=" + "detail";
    })
    function getTransactionList(productId) {
        var arr = { productId: productId };
     
        $.ajax({
            type: "POST",
            url: "Reports.aspx/GetProductTransactions",
            data: JSON.stringify(arr),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: "false",
            success: function (response) {
               
                $("#transactionResults .table_row").remove();
                $(".product-transaction-individuals.error").remove();
                if (response.d.length != 0)
                {
                    response.d.forEach((item => {
                   var TransDate = GetFormattedDate(item.TransactionDateTime.substring(0,24)); 
                        var $newDiv = `
                  <div class='table_row'>
                    <div class='table_small'>
                      <div class='table_cell'>ID</div>
                      <div class='table_cell transaction-ids'>${item.TransactionID}</div>
                    </div>
                    <div class='table_small'>
                      <div class='table_cell'>DATE</div>
                      <div class='table_cell transaction-date'>${TransDate}</div>
                    </div>
                    <div class='table_small'>
                      <div class='table_cell'>CUSTOMER</div>
                      <div class='table_cell transaction-customer-name'>  ${item.CustomerName}</div>
                    </div>
                    <div class='table_small'>
                      <div class='table_cell'>PRODUCT</div>
                      <div class='table_cell transaction-product-name'> ${item.ProductName}</div>
                    </div>
                     <div class='table_small'>
                      <div class='table_cell'>TYPE</div>
                      <div class='table_cell transaction-type'> ${item.Type}</div>
                    </div>
                     <div class='table_small'>
                      <div class='table_cell'>QTY</div>
                      <div class='table_cell transaction-quantity'>${item.Quantity}</div>
                    </div>
                  </div>
              `;
                        $("#transactionResults").append($newDiv);

                    }))
                }
                else
                {
                    var $newDiv = ` <div class="product-transaction-individuals  error">
                    <h3> No Transactions Found</h3>
                    </div>`;
                    $(".report-page").append($newDiv);

                }
               
            },
            Error: function (response) {
                alert(response);
            }
        });
    }
    function GetFormattedDate(datetimestring) {
        /*const date = new Date(datetimestring);
        const hours = date.getHours();
        const minutes = date.getMinutes();
        const seconds = date.getSeconds();
        const amOrPm = hours >= 12 ? 'PM' : 'AM';
        const hours12 = hours % 12 || 12;

        const timeString = `${hours12}:${String(minutes).padStart(2, '0')}:${String(seconds).padStart(2, '0')} ${amOrPm}`;
        const dateString = `${date.getMonth() + 1}/${date.getDate()}/${date.getFullYear()}`;
        const resultString = `${dateString} ${timeString}`;
        return resultString;*/
        const [datePart, timePart] = datetimestring.split(' ');
        const [day, month, year] = datePart.split('-');
        const date = new Date(year, month - 1, day);
        const localDateString = date.toLocaleDateString();

        return localDateString;
    }
})













