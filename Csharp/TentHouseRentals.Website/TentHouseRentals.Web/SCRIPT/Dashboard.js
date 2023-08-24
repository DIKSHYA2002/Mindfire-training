
$(document).ready(function () {
    const loadingGif = `<img src="./ImageFolder/Loading.gif" style="width:5rem; height:5rem">`;
    /*Nav bar close*/
    $("nav").on("click", ".toggle", function (e) {
        $("nav").toggleClass("close");
    })

    /*Validate Login Form*/
    function ValidateLogin() {
        var error;
        $(".login-container input[type='email'] ,.login-container input[type='password'] ").each(function () {
            if ($(this).val().trim() == "") {
                var labelId = $(this).attr("refto");
                $(`#${labelId}`).css("color", "red");
                error = true;
            }
            else {
                var labelId = $(this).attr("refto");
                $(`#${labelId}`).css("color", "green");
                error = false;
            }
        })
        if (error == true) {
            alert("complete the form");
        }
        return error;
    }
    getCustomers();
    $(".customer-form").on("click", "#btnAddCustomer", function (e) {
        e.preventDefault();
        var customerName = txtName.value;

        if (customerName.trim() == "" || customerName == undefined) {
            $("#txtName").css("border", "red");
            alert("Enter the name Correctly");
        }
        else {
            var arr = { customerName: customerName };
            $.ajax({
                type: "POST",
                url: "CustomersPage.aspx/SubmitCustomer",
                data: JSON.stringify(arr),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: "false",
                success: function (response) {
                    if (response.d == false) {
                        alert("user already exists");
                        $("#txtName").css("border", "red");
                    }
                    else
                        alert("succesfully added customer");
                    getCustomers();
                },
                Error: function (response) {
                    alert(response);
                }
            });
        }


    })
    function getCustomers() {
        $(".customer-lists").html(`<img src="./ImageFolder/Loading.gif" style="width:5rem; height:5rem">`);
        $.ajax({
            type: "POST",
            url: "CustomersPage.aspx/GetCustomers",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: "false",
            success: function (response) {
                $(".customer-lists").empty();
                var $newDiv = `<div class="customer head">
                                   <div class="customer-id">CUSTOMER-ID</div>
                                   <div class="customer-name">CUSTOMER-NAME</div>
                           </div>`;
                $(".customer-lists").append($newDiv);

                response.d.forEach((item => {

                    var $newDiv = `<div class="customer">
                                   <div class="customer-id">${item.ID}</div>
                                   <div class="customer-name">${item.Name}</div>
                           </div>`
                    $(".customer-lists").append($newDiv);
                }))
            },
            Error: function (response) {
                alert(response);
            }
        });
    }
    /*Report*/

})
