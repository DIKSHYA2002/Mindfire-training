<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductsPage.aspx.cs" Inherits="TentHouseRentals.Web.ProductsPage" %>

<%@ Register Src="~/Navbar.ascx" TagPrefix="uc1" TagName="NavbarUC" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="./CSS/Navbar.css" />
    <link rel="stylesheet" href="CSS/Products.css" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@48,400,0,0" />
</head>  
<body>
    <form id="form1" runat="server">
        <uc1:NavbarUC runat="server" ActiveTab="Products" ID="NavbarUC" />
        <div class="main-section">
          <h1> <button id="btnOpenAddProductModal" class="btn"><span class="material-symbols-outlined">
            add_circle
            </span></button><span>All Products</span></h1>
           <div class="product-lists">
             
           </div>
            <div class="modal-content modal" id="AddProductModal">
                <div class="product-container">
                    <span class="closeModal">&times;</span>
                    <div class="input-field">
                        <label for="txtTitle" id="lblTitle">Image Title *</label>
                        <input type="text" id="txtTitle" refto="lblTitle" />
                    </div>
                    <div class="input-field">
                        <label for="nbQuantity" id="lblQuanity">Quantity *</label>
                        <input type="number" id="counting" refto="lblQuanity" />
                    </div>

                    <div class="input-field">
                        <label for="flImage" id="lblImage">Image:</label>
                        <div class="file-drop-area">
                            <span class="fake-btn">Choose Image</span>
                            <span class="file-msg">or drop Image here</span>
                            <input class="file-input" type="file" id="flImage" accept="image/png, image/jpeg"
                                refto="lblImage" />
                            <div class="item-delete"></div>
                        </div>
                    </div>
                    <div class="input-field">
                        <label for="txtPrice" id="lblPrice">Price/Day *</label>
                        <input type="number" id="txtPrice" refto="lblPrice" />
                    </div>
                    <div class="input-field">
                        <button id="btnSubmitProduct" class="btn">Add Product</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script src="./SCRIPT/Dashboard.js"></script>
    <script src="./SCRIPT/Products.js"></script>
</body>
</html>
