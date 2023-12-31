﻿const loadingGif = `<div class="transaction-individual"><img src="./ImageFolder/Loading.gif" style="width:5rem; height:5rem"></div>`;
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
                if (response.d != null)
                {
                    response.d.forEach((item => {
                        var $newDiv = `
                    <option value="${item.ID}">${item.Title}</option>
               `;
                        $("#selectProductName").append($newDiv);
                    }))
                    getProduct1();
                }
               
            },
            Error: function (response) {
                alert(response);
            }
        });
    }
    function getProduct1() {
        var selectedId = selectProductName.value;
        var arr = { id: selectedId };
        $.ajax({
            type: "POST",
            url: "Reports.aspx/GetProduct",
            data: JSON.stringify(arr),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: "false",
            success: function (response) {
                if (response.d != null) {
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
                }
                else {
                    alert("failed to load");
                }
               
            },
            Error: function (response) {
                alert(response);
            }
        });

    }
    $(".report-action").on("click", "#btnProductReport", function (e) {
        e.preventDefault();
        window.location.href = "PdfReport.ashx?type=" + "product";
    })
    $(".report-action").on("click", "#btnProductDetailedReport", function (e) {
        e.preventDefault();
        window.location.href = "PdfReport.ashx?type=" + "detail";
    })
    $("#productReports").on("change", "#selectProductName", function (e) {
        e.preventDefault();
        var selectedId = selectProductName.value;
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
                if (response.d != null) {
                    var $newDiv = `<div class="product">
                   <img src="./ImageFolder/${response.d.Image}"/>
                   <div class="product-details">
                   <div class="product-title info">Name: ${response.d.Title}</div>
                   <div class="product-present-quantity info">Quantity : ${response.d.QuantityPresent}</div>
                   </div> 
               </div>`;
                    $(".product-details").append($newDiv);
                    getTransactionList(response.d.ID);
                }
                else {
                    alert("failed to load");
                }
              
              
            },
            Error: function (response) {
                alert(response);
            }
        });
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

                if (response.d != null) {
                    if (response.d.length != 0 && response.d !== null) {
                        response.d.forEach((item => {
                            var str = item.TransactionDateTime.toString();
                            var num = parseInt(str.replace(/[^0-9]/g, ""));
                            var date = new Date(num);
                            var TransDate = getFormattedDate(date.toISOString().substring(0, 24)); 
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

                }

                else {
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
    /*function getFormattedDate(datetimestring) {
        const date = new Date(datetimestring);
        const hours = date.getHours();
        const minutes = date.getMinutes();
        const seconds = date.getSeconds();
        const amOrPm = hours >= 12 ? 'PM' : 'AM';
        const hours12 = hours % 12 || 12;
        const timeString = `${hours12}:${String(minutes).padStart(2, '0')}:${String(seconds).padStart(2, '0')} ${amOrPm}`;
        const dateString = `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`;
        const resultString = `${dateString} ${timeString}`;
        return resultString;
    }*/
})