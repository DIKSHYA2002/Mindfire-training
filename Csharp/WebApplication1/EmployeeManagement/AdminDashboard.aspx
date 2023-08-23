<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="EmployeeManagement.AdminDashboard" %>

<%@ Register Src="~/WebUserControl2.ascx" TagPrefix="uc" TagName="User"%>  
<%--<%@ Register Src="~/FileUpload.ascx" TagPrefix="uc" TagName="File"%>  --%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
     <link rel="stylesheet" href="userDashboard.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <link rel="stylesheet" href="form.css" />
</head>
<body>
    <form id="form1" runat="server">
        <nav>
            <ul class="nav-user">
                 <li>Welcome<asp:Label runat="server" ID="displayUsername"></asp:Label>!</li>
                 <li> <asp:Button ID="Button1" runat="server" Height="47px" OnClick="Button1_Click" Text ="Log out" Width="92px" /></li>
            </ul>
        </nav>

        <div class="button-links">
        <button class="tablink" opens="userDetails" id="detailBtn">DETAILS</button>
        <button class="tablink" opens="userNotes" id="noteBtn">NOTES</button>
        <button class="tablink" opens="userFiles" id="fileBtn">FILES</button>
        <button class="tablink" opens="userList" id="usersBtn">USERLIST</button>
</div>  
    <asp:ScriptManager ID="scriptmanager2" runat="server">  
                  </asp:ScriptManager>  
   <div class="tabcontent" id="userNotes" >
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">  
                     <ContentTemplate>
     <uc:User ID="UserControl" runat="server" /> 
                         </ContentTemplate>
         </asp:UpdatePanel>
</div>

<div class="tabcontent" id="userDetails">
      <asp:Button Text="Add User" runat="server" OnClick="AddUserClick"  UseSubmitBehavior="false" ID="btnAddUser" ClientIDMode="Static" />
     <div class="form-container">
            <!-- header-part-html -->
       
            <div class="header">
                <div class="header-text">
                    <h1  runat="server" id="headertext"> PERSONAL DETAILS </h1>
                   
                </div>
                <div class="header-profile-container">
                    <asp:Image ID="Image1" runat="server" ImageUrl="https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png" Height="200px" Width="200px"/>
                </div>
            </div>
            <!-- personal-detail-part -->
            <div class="information">Fields marked with <span class="red">*</span> are required </div>
            <div class="input-field-group">
                <div class="input-field">
                    <label for="inputFirstName" id="labelFirstName">First Name<span class="red">*</span>:</label>
                    <input type="text" name="inputFirstName" id="inputFirstName" fieldName = "First-Name"  importantField="true" runat="server" clientIDmode ="static" />
                </div>
                <div class="input-field">
                    <label for="inputLastName" id="labelLastName">Last Name<span class="red">*</span>:</label>
                    <input type="text" name="inputLastName" id="inputLastName" fieldName = "Last-Name" importantField="true" runat="server"/>
                </div>
            </div>
            <div class="input-field-group">
                <div class="input-field">
                    <label for="inputDateOfBirth">DOB<span
                            class="red">*</span>:</label>
                    <input type="date" name="inputDateOfBirth" id="inputDateOfBirth"  max="2010-01-01" fieldName = "Date-Of-Birth" importantField="true" runat="server" />
                </div>
                <div class="input-field">
                    <label for="Gender" id="labelGender">Gender <span class="red">*</span>:</label>
                    <div class="gender-field">
                        <label for="Male"><i class='bx bx-male'></i><span>M:</span></label>
                        <input type="radio" name="Gender" id="Male"  runat="server">
                    </div>
                    <div class="gender-field">
                        <label for="Female"><i class='bx bx-female'></i> <span>F:</span></label>
                        <input type="radio" name="Gender" id="Female"  runat="server">
                    </div>
                    <div class="gender-field">
                        <label for="others"><i class='bx bx-male-female'></i> <span>O:</span></label>
                        <input type="radio" name="Gender" id="others"  runat="server">
                    </div>
                </div>
            </div>
            <div class="input-field-group">
                <div class="input-field">
                    <label for="inputImage">Picture<span class="red">*</span>:</label>
                    <asp:FileUpload ID="fiImages" runat="server" ClientIDMode="static"/>
                 
                </div>
                <div class="input-field">
                    <label for="inputDropdownBloodGroup" id="labelBloodGroup">
                        Role<span class="red">*</span>:
                    </label>
                    <asp:ListBox ID="lbRoles" runat="server" Height="240px" SelectionMode="Multiple" ClientIDMode="Static" >
                        
                    </asp:ListBox> 
                 
                    
                </div>
            </div>
            <div class="input-field-group">
                <div class="input-field">
                    <label for="inputEmail" id="labelEmail">Email<span>*</span>:</label>
                    <input type="email" name="inputEmail" id="inputEmail" fieldname = "Email" importantfield="true"  runat="server" />
                </div>
                <div class="input-field">
                    <label for="inputPhone" id="labelPhone">Phone<span
                            class="red">*</span>:</label>
                    <input type="number" name="inputPhone" id="inputPhone" fieldname ="Phone-Number" importantfield="true"  runat="server"/>
                </div>
            </div>
        </div>
      
        <div class="form-container">
            <!-- present-address-details -->
            <div class="container-present-address">
                <div class="header-text">
                    <h3>Present-address</h3>
                </div>
                <div class="input-field-group">
                    <div class="input-field">
                        <label for="inputPresentLine1" id="labelPresentLine1">line-1<span class="red">*</span>:</label>
                        <input type="text" name="inputPresentLine1" id="inputPresentLine1" fieldname ="Present-Line1"
                        importantfield="true"  runat="server"/>
                    </div>
                    <div class="input-field">
                        <label for="inputPresentLine2" id="present-label-line2">line-2:</label>
                        <input type="text" name="inputPresentLine2" id="inputPresentLine2" fieldname ="Present-Line2" importantfield="false" runat="server" />
                    </div>
                </div>
                  <asp:UpdatePanel ID="updatepnl" runat="server">  
                     <ContentTemplate>
                <div class="input-field-group">
                  
                    <div class="input-field">
                        <label for="inputDropdownCountry" id="labelPresentCountry">Country<span class="red">*</span>
                            :</label>
                       <asp:DropDownList ID="ddlCountryNamesPresent" runat="server" AutoPostBack = "true" OnSelectedIndexChanged = "FetchState" refTo ="stateNamesPresent" ClientIDMode="static" >
                        <asp:ListItem Text="Select State" Value="0" />
                    </asp:DropDownList>
                      
                    </div>
                    <div class="input-field">
                        <label for="state-names-present" id="labelPresentState"> State<span class="red">*</span>:</label>
                        <select name="state-names-present" id="stateNamesPresent" type="text" fieldname ="Present-State-Name" importantfield="true" runat="server" ClientIDMode="static"  >
                            <option value="">Select State</option>
                        </select>
                    </div>
                </div>
                   </ContentTemplate>  
                   </asp:UpdatePanel>  
                <div class="input-field-group">
                    <div class="input-field">
                        <label for="city-names-present" id="label-present-city"> City <span class="red">*</span>:</label>
                        <input placeholder="Enter City" id="inputCityPresent" type="text" fieldname ="Present-City-Name" importantfield="true"  runat="server"/>
                       
                    </div>
                    <div class="input-field">
                        <label for="inputPresentPincode" id="labelPresentPincode"> pincode<span class="red">*</span>
                            :</label>
                        <input type="text" name="inputPresentPincode" id="inputPresentPincode" class="validateOnChange" fieldname ="Present-Pincode" importantfield="true"  runat="server" />
                    </div>
                </div>
            </div>

            <!-- permanent-address-details -->
            <div class="container-permanent-address">
                <div class="header-text" >
                    <h3  title="to change the permanent address uncheck the checkbox first">Permanent-Address <label for="sameas">(Same as present </label><span><input type="checkbox" name="sameas" id="sameas" /></span>)</h3>
                </div>

                <div class="input-field-group">
                    <div class="input-field">
                        <label for="inputPermanentLine1" id="labelPermanentLine1">line-1<span
                                class="red">*</span>:</label>
                        <input type="text" name="inputPermanentLine1" id="inputPermanentLine1" fieldname = "Permanent-Line1" importantfield="true"  runat="server"/>
                    </div>
                    <div class="input-field">
                        <label for="inputPermanentLine2">line-2:</label>
                        <input type="text" name="inputPermanentLine2" id="inputPermanentLine2" fieldname = "Permanent-Line2"  importantfield="false"  runat="server"/>
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">  
                     <ContentTemplate>
                <div class="input-field-group">
                    <div class="input-field">
                        <label for="country-names-permanent" id="labelPermanentCountry">Country<span
                                class="red">*</span>:</label>

                          <asp:DropDownList ID="ddlcountryNamesPermanent" runat="server" AutoPostBack = "true" OnSelectedIndexChanged = "FetchState2" fieldName="Permanent-Country-Name" importantField="true" refTo ="stateNamesPermanent" >
                        <asp:ListItem Text="Select Country" Value="0"  runat="server"/>
                    </asp:DropDownList>
                    </div>
                    <div class="input-field">
                        <label for="state-names-permanent" id="labelPermanentState">
                            State<span class="red">*</span>:</label>
                        <select name="state-names-permanent" id="stateNamesPermanent" type="text" fieldname="Permanent-State-Name" importantfield="true" runat="server" />
                            <option value="">Select State</option>
                        </select>
                    </div>
                </div>
                  </ContentTemplate>  
                 </asp:UpdatePanel>  
                <div class="input-field-group">
                    <div class="input-field">
                        <label for="city-names-permanent" id="labelPermanentCity">City<span class="red">*</span>:</label>
                        <input  id="inputPermanentCity" 
                        type="text"
                        placeholder="Enter City"  fieldname="Permanent-City-Name" importantfield="true"  runat="server"/>
                       
                    </div>
                    <div class="input-field">
                        <label for="inputPermanentPincode" id="labelPermanentPincode"> pincode<span
                                class="red">*</span>:</label>
                        <input type="text" name="inputPermanentPincode" id="inputPermanentPincode" class="validateOnChange" fieldname="Permanent-Pincode" importantfield="true"  runat="server"/>
                    </div>
                </div>
            </div>
            <div class="input-field-group">
                 <div class="input-field">
                    <label for="inputHobbies">hobbies:</label>
                    
                   <input list="hobbyList" name="inputHobbies" id="inputHobbies" class="multidatalist" multiple="multiple" type="text" title="add more hobbies separated by commas" fieldname="Hobby-List"  importantfield="false" runat="server" />
                    <datalist id="hobbyList">
                        <option value="Dancing"/>
                        <option value="Singing"/>
                        <option value="Painting"/>
                        <option value="Play Instrument"/>
                        <option value="trecking"/>
                    </datalist>
                </div>
                <div class="input-field">
                    <label for="subscribe">Subscribe:</label>
                    <input type="checkbox" name="subscribe" id="subscribe" fieldname="subscribed"  runat="server"  />
                </div>
                  <div class="input-field">
                    <label for="password">Password:</label>
                    <input type = "password" name="password" id="password"   runat="server" clientidmode="Static" />
                </div>

            </div>
            <div class="input-field-group buttons">
                <div class="input-field">
                    <div>
                        <asp:Button runat="server" ID="btnSubmit" ClientIDMode="static" Text="submit" OnClick="SubmitUser"                      
                         UseSubmitBehavior="false" /> 
                    </div>
                    <div>
                       <asp:Button runat="server" ID="btnReset" ClientIDMode="static" Text="reset"/>
                    </div>
                     <div>
                       <asp:Button runat="server" ID="btnEdit" ClientIDMode="static" Text="Edit"  OnClick="UpdateUser" />
                    </div>
                     <div>
                       <asp:Button runat="server" ID="btnDelete" ClientIDMode="static" Text="Delete" 
                           OnClientClick="if (!ConfirmDelete()) {return false;}"
                           UseSubmitBehavior="false" 
                           OnClick="DeleteUser"
                           
                           />
                    </div>
                </div>
            </div>
            <div >
                 <div id="myModal" class="modal">
                <!-- Modal content -->
                <div class="modal-content" id="modalContent">
                  <span class="close">&times;</span>
                  <a><img src="https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png" alt="" id="ResultImage"/></a>
                  <p></p>
                </div>
              </div>
                <asp:Label runat="server" ID="Results" >
                </asp:Label>
            </div>
        </div>
</div>

       <div class="tabcontent" id="userFiles">
     <ContentTemplate>
  <%--   <uc:File ID="File1" runat="server" /> --%>
     </ContentTemplate>

         
</div>
   
        <div class="tabcontent" id="userList">
             <div>
            <h1>Users will be displayed here</h1>
            <div class="table-rows">
               <div class="row headers">
        <div class="col-cell headers">First Name</div>
          <div class="col-cell headers">Last Name</div>
          <div class="col-cell headers">Email</div>
          <div class="col-cell headers">Phone Number</div>
           <div class="col-cell headers">Roles</div>
                      <div class="col-cell headers"></div>
           </div>
            </div>
          
        </div>
        </div>
        
    
    </form>
    <script src="AdminDashboard.js"></script>
</body>
</html>
