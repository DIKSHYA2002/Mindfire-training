const loadingGif = `<div class="transaction-individual"><img src="./ImageFolder/Loading.gif" style="width:3rem; height:3rem"></div>`;
const loadingGif2 = `<div class="transaction-individual"><img src="./ImageFolder/Loading2.gif" style="width:3rem; height:3rem"></div>`;

$(document).ready(function () {

    $(".out-section-list").on('click', '.deletebutton', function (e) {
        e.preventDefault();
        $(this).closest('.transaction-individual.in').remove();
        alert("deleted!");
    });

    getCustomers();
    $('input[type=radio][name=transactionType]').change(function () {
        if (this.value == 'in') {
            $(".in-section").css("display", "flex");
            $(".out-section").css("display", "none");
          
        }
        else if (this.value == 'out') {
            $(".in-section").css("display", "none");
            $(".out-section").css("display", "flex");
           
        }
       
    });

    function getCustomers() {
       
        
        $.ajax({
            type: "POST",
            url: "CustomersPage.aspx/GetCustomers",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: "false",
            success: function (response) {
                $("#transactionCustomer2").empty();
                $("#customerList").empty();

                var $newDiv2 = `<option value="" id="">Select User</option>`
                $("#transactionCustomer2").append($newDiv2);
                response.d.forEach((item =>
                  {
                    var $newDiv = `<option value="${item.Name}" id="${item.ID}">${item.Name}</option>`
                    $("#transactionCustomer2").append($newDiv);
                    $("#customerList").append($newDiv);

                  }
                ))
            },
            Error: function (response) {
                alert(response);
            }
        });
    }
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
                console.log(response.d);
                response.d.forEach((item => {
                    var $newDiv = `
                    <option id="${item.ID}" data-img_src="./ImageFolder/${item.Image}">${item.Title}</option>
               `;
                    $("#id_select2_example").append($newDiv);
                }))
            },
            Error: function (response) {
                alert(response);
            }
        });
    }

    $(".button-add-transaction").on("click", "#btnAddTransaction", function (e) {
        e.preventDefault();
        if (ValidateProductTransaction()) {
            e.preventDefault();
            var customerName = transactionCustomer.value;
            var TransactionDate = dtTransactionDate.value;
            var transactionFormatDate = GetFormattedDate(TransactionDate);
            var selectedProductId = $('#id_select2_example').find(":selected").prop("id");
            var selectedProductName = $('#id_select2_example').find(":selected").text();
            var qty = counting.value;
            var $newDiv = `<div class="transaction-individual in">
                        <div class="transaction-date" refDate="${TransactionDate}">
                          ${transactionFormatDate}
                        </div>
                        <div class="transaction-product-name" productId="${selectedProductId}">
                           ${selectedProductName}
                        </div>
                        <div class="transaction-product-quantity">
                          ${qty}
                        </div>
                        <div class="transaction-product-customer">
                           ${customerName} 
                        </div>
                        <div class="transaction-product-buttons">
                            <button class="deletebutton btn">Delete</button>
                        </div>
                    </div>`;
            $(".out-section-list").append($newDiv);

           
        }
        else {
            alert("complete all the required fields");
        }
    })


    function ValidateProductTransaction() {
        var noerror;
        $(".out-section-form .input-field input[type='text'] ,.out-section-form .input-field input[type='datetime-local'],.out-section-form .input-field input[type='number']").each(function () {
            if ($(this).val().trim() == "") {
                var labelId = $(this).attr("refto");
                $(`#${labelId}`).css("color", "red");
                noerror = false;
            }
            else
            {
                noerror = true;
            }
        })
        var selectedProductId = parseInt($('#id_select2_example').find(":selected").prop("id")); 
        if (selectedProductId == -1)
        {
            noerror = false;
            $(`#lblProducts`).css("color", "red");
        }

        return noerror;

    }

    function GetTransactionParticular()
    {
        var customerId = parseInt($("#transactionCustomer2").children(":selected").attr("id"));
        if (customerId > 0) {
         /*   $(".in-section-list").find(".theader").html(loadingGif);*/
            var arr = { customerId: customerId };
            $.ajax({
                type: "POST",
                url: "TransactionsPage.aspx/GetIndividualTransactionDetails",
                data: JSON.stringify(arr),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: "false",
                success: function (response) {
                
                    if (response.d.length == 0) {
                        $(".in-section-list").find(".transaction-individual").remove();
                        var $newDiv = ` <div class="transaction-individual" >
                         <h1>No Transactions Found</h1>
                     </div>`;
                        $(".in-section-list").append($newDiv);
                    }
                    else {
                        $(".in-section-list").find(".transaction-individual").remove();
                        response.d.forEach((item => {
                            var str = item.TransactionOutDate.toString();
                            var num = parseInt(str.replace(/[^0-9]/g, ""));
                            var date = new Date(num);
                            var outDate = GetFormattedDate(date.toISOString().substring(0, 24)); 
                            var inDate = `<input type="datetime-local" class="retDate" id="DateOf${item.TransactionID}">`;
                            var checkornot = "";
                            var disableornot = "";
                            if (item.TransactionInDate != null) {
                                var str2 = item.TransactionInDate.toString();
                                var num2 = parseInt(str2.replace(/[^0-9]/g, ""));
                                var date = new Date(num2);
                                var inDate = GetFormattedDate(date.toISOString().substring(0, 24)); 
                                checkornot = "checked";
                                disableornot = "disabled";
                            }
                            var $newDiv = `
                             <div class='table_row transaction-individual'>
                            <div class='table_small'>
                              <div class='table_cell'>OUT-DATE</div>
                              <div class='table_cell transaction-date out-date'>${outDate}</div>
                            </div>
                        <div class='table_small'>
                        <div class='table_cell'>IN-DATE</div>
                      <div class='table_cell transaction-date in-date'>${inDate}</div>
                    </div>
                     <div class='table_small'>
                      <div class='table_cell'>PRODUCT</div>
                      <div class='table_cell transaction-product-id'>${item.ProductID}</div>
                    </div>
                    <div class='table_small'>
                      <div class='table_cell'>QUANTITY</div>
                      <div class='table_cell transaction-product-quantity'>${item.Quantity}</div>
                    </div>
                   
                     <div class='table_small'>
                      <div class='table_cell'>TYPE</div>
                      <div class='table_cell transaction-type'> ${item.Type}</div>
                    </div>
                     <div class='table_small'>
                      <div class='table_cell'>RETURN</div>
                      <div class='table_cell transaction-product-buttons'><input type="checkbox" class="checkReturn" id="${item.TransactionID}Transaction" ${checkornot} ${disableornot} /></div>
                    </div>
                  </div>`;
                            $(".in-section-list #transactionResults").append($newDiv);
                        }))
                    }
                },
                Error: function (response) {
                    alert(response);
                }
            });
        }
        else {
            $(".in-section-list").find(".table_row").remove();
            $(".in-section-list").find(".transaction-individual").remove();
            var $newDiv = ` <div class="transaction-individual" >
                         <h1>No Transactions Found</h1>
                     </div>`;
            $(".in-section-list").append($newDiv);
        }
    }

    $(".in-section").on("change", "#transactionCustomer2", function (e) {
        e.preventDefault();
        GetTransactionParticular();
    })

    function GetFormattedDate(datetimestring)
    {
        const date = new Date(datetimestring);
        const hours = date.getHours();
        const minutes = date.getMinutes();
        const seconds = date.getSeconds();
        const amOrPm = hours >= 12 ? 'PM' : 'AM';
        const hours12 = hours % 12 || 12; 
   
        const timeString = `${hours12}:${String(minutes).padStart(2, '0')}:${String(seconds).padStart(2, '0')} ${amOrPm}`;
        const dateString = `${date.getMonth() + 1}/${date.getDate()}/${date.getFullYear()}`;
        const resultString = `${dateString} ${timeString}`;
        return resultString;
    }


    $(".in-section").on("click", "#btnSaveInTransactionsIn", function (e) {
        var childNodes = $(".in-section-list .transaction-individual");
        var transactionArray = [];
        $("#btnSaveInTransactionsIn").html(loadingGif2);
       childNodes.each(function () {
            if ($(this).find(".transaction-product-buttons .checkReturn").is(':checked') && !$(this).find(".transaction-product-buttons .checkReturn").is(':disabled'))
            {
                var transactionObject = {};
                transactionObject["TransactionDateTime"] = $(this).find(`.in-date .retDate`).val();
                transactionObject["CustomerName"] = $("#transactionCustomer2").children(":selected").val();
                transactionObject["ProductName"] = $(this).find(".transaction-product-id").prop("innerText");
                transactionObject["Type"] = "IN";
                transactionObject["Quantity"] = $(this).find(".transaction-product-quantity").prop("innerText");
                transactionObject["ParentId"] = parseInt($(this).find(".transaction-product-buttons .checkReturn").prop("id").substring(0));
                transactionArray.push(transactionObject);
            }
          }

        )
        if (transactionArray.length != 0) {
            var transactions = { transactions: transactionArray };
            $.ajax({
                type: "POST",
                url: "TransactionsPage.aspx/SubmitTransactions",
                data: JSON.stringify(transactions),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: "false",
                success: function (response) {
                    $("#btnSaveInTransactionsIn").html("SAVE TRANSACTIONS");
                    if (response.d == "Successful Transaction") {
                        alert("Transactions Succesful");
                        GetTransactionParticular();
                    }
                    else {
                        alert(response.d);
                    }
                },
                Error: function (response) {
                    $("#btnSaveInTransactionsIn").html("SAVE TRANSACTIONS");
                    alert(response);
                }
            });
        }
        else {
            $("#btnSaveInTransactionsIn").html("SAVE TRANSACTIONS");
            alert("select some checkboxes");
        }

        e.preventDefault();

    })
    $(".out-section-list").on("click", "#btnSaveTransactions", function (e) {
        var childNodes = $(".out-section-list .transaction-individual");
        var transactionArray = [];
        $("#btnSaveTransactions").html(loadingGif2);
        childNodes.each(function () {
            var transactionObject = {};
            transactionObject["TransactionDateTime"] = $(this).find(".transaction-date").attr("refDate");
            transactionObject["CustomerName"] = $(this).find(".transaction-product-customer").prop("innerText");
            transactionObject["ProductName"] = $(this).find(".transaction-product-name").prop("innerText");
            transactionObject["Type"] = "OUT";
            transactionObject["Quantity"] = parseInt( $(this).find(".transaction-product-quantity").prop("innerText"));
            transactionArray.push(transactionObject);
           }
        )
        if (transactionArray.length != 0)
        {
            var transactions = { transactions: transactionArray };
            $.ajax({
                type: "POST",
                url: "TransactionsPage.aspx/SubmitTransactions",
                data: JSON.stringify(transactions),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: "false",
                success: function (response) {
                    $("#btnSaveTransactions").html("SAVE TRANSACTIONS");
                    alert(response.d);
                },
                Error: function (response) {
                    $("#btnSaveTransactions").html("SAVE TRANSACTIONS");
                    alert(response);
                }
            });
        }
        else {
            alert("Rent some items");
        }

        e.preventDefault();
      
    })
})