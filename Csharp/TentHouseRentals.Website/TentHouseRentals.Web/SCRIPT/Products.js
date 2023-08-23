﻿const  loadingGif = `<img src="./ImageFolder/Loading.gif" style="width:30px; height:30px">`;
$(document).ready(function () {
    
    var modal = document.getElementById("AddProductModal");
    $(".main-section").on("click", "#btnOpenAddProductModal", function (e) {
        e.preventDefault();
        $("#AddProductModal").css("display", "block");
    })

    $(".closeModal").on("click", function () {
        $("#AddProductModal").css("display", "none");
    })
    window.onclick = function (event) {
        if (event.target == $(".main-section")[0]) {
            modal.style.display = "none";
        }
    }

    $('.input-field').on('click', "#btnSubmitProduct", function (e) {

        if (ValidateProductSubmit()) {

            var loadingGif = `<img src="./ImageFolder/Loading.gif" style="width:50px; height:50px">`;
            const fileInput = document.querySelector('#flImage');
            $("#btnSubmitProduct").html(loadingGif);
            const file = fileInput.files[0];
            var formdata = new FormData();
            formdata.append("productImagefile", file, file.name);
            formdata.append("title", txtTitle.value);
            formdata.append("Quantity", counting.value);
            formdata.append("price", txtPrice.value);
            $.ajax({
                type: "POST",
                url: "ProductSubmitHandler.ashx",
                data: formdata,
                contentType: false,
                processData: false,
                success: function (response) {
                    $("#btnSubmitProduct").html("Add Product");
                    alert("succesfully Added Product");
                    getProductList();
                },
                Error: function (response) {
                    alert(response);
                }
            });
        }
        else {
            alert("Add required Details");
        }
        e.preventDefault();
    });


    function ValidateProductSubmit() {
        var noerror;
        $("#AddProductModal .input-field input[type='text'] ,#AddProductModal .input-field input[type='number']").each(function () {
            if ($(this).val().trim() == "") {
                var labelId = $(this).attr("refto");
                $(`#${labelId}`).css("color", "red");
                noerror=false;
            }
            else {
                noerror = true;
            }
        })
        const fileInput = document.querySelector('#flImage');
        const file = fileInput.files[0];
        if (file == undefined) {
            noerror = false;
            var labelId = $("#flImage").attr("refto");
            $(`#${labelId}`).css("color", "red");
        }
        return noerror;
        
    }
    getProductList();
    function getProductList() {
        $(".product-lists").html(`<img src="./ImageFolder/Loading.gif" style="width: 10rem; height: 10rem">`);
        $.ajax({
            type: "POST",
            url: "ProductsPage.aspx/GetProducts",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: "false",
            success: function (response) {
                $(".product-lists").empty();
             
                response.d.forEach((item => {
                    var $newDiv = `<div class="product">
                   <img src="./ImageFolder/${item.Image}"/>
                   <div class="product-details">
                   <div class="product-title info">Name: ${item.Title}</div>
                   <div class="product-price info">Price/Day : Rs ${item.PricePerDay}</div>
                   <div class="product-present-quantity info">Quantity : ${item.QuantityPresent}</div>
                   <div class="product-rented-quantity info">On Rent: ${item.QuantityBooked}</div> 
                   </div> 
               </div>`;
                    $(".product-lists").append($newDiv);
                }))
            },
            Error: function (response) {
                alert(response);
            }
        });
    }
    
})

const $fileInput = $('.file-input');
const $droparea = $('.file-drop-area');
const $delete = $('.item-delete');

$fileInput.on('dragenter focus click', function () {
    $droparea.addClass('is-active');
});

$fileInput.on('dragleave blur drop', function () {
    $droparea.removeClass('is-active');
});

$fileInput.on('change', function () {
    let filesCount = $(this)[0].files.length;
    let $textContainer = $(this).prev();

    if (filesCount === 1) {
        let fileName = $(this).val().split('\\').pop();
        $textContainer.text(fileName);
        $('.item-delete').css('display', 'inline-block');
    } else if (filesCount === 0) {
        $textContainer.text('or drop files here');
        $('.item-delete').css('display', 'none');
    } else {
        $textContainer.text(filesCount + ' files selected');
        $('.item-delete').css('display', 'inline-block');
    }
});

$delete.on('click', function () {
    $('.file-input').val(null);
    $('.file-msg').text('or drop files here');
    $('.item-delete').css('display', 'none');
});