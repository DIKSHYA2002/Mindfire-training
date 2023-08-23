<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="EmployeeManagement.Web.Dashboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   
       <div class="button-links">
        <button class="tablink" opens="userDetails" id="detailBtn" >DETAILS</button>
        <button class="tablink" opens="userNotes" id="noteBtn">NOTES</button>
        <button class="tablink" opens="userFiles" id="fileBtn">FILES</button>
      </div>   

  
   <div class="tabcontent" id="userNotes" >
       <div class="notes-container">
            <div class="txt-notes">
                      <div class="Is-private"  runat="server" id="PrivateNotesw" clientidmode="static"> IsPrivate :<input type="checkbox"  id="chkPrivate" clientIdMode="static"/></div>
                      <input type= "text" id="txtNotes" />
                      <button id="btnAddNote">Add Notes</button>
            </div>
            <div id="PersonalNotes" runat="server" class="notes-container">
                 <div class= "personal-notes">
                 </div>
            </div>
            <div id="PrivateNotes" runat="server" class="notes-container" clientidmode="static">
                    <div class= "private-notes " runat="server">
                    </div>
             </div>
       </div>
     

      </div>
<div class="tabcontent" id="userDetails">
    details will be displayed
     <div class="form-container">
            <!-- header-part-html -->
            <div class="header">
                <div class="header-text">
                    <h1>registration-form</h1>
                </div>
                <div class="header-profile-container">
                    <asp:image id="image1" runat="server" imageurl="https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png" height="200px" width="200px" ClientIDMode="Static"/>
                </div>
            </div>
            <!-- personal-detail-part -->
            <div class="information">fields marked with <span class="red">*</span> are required </div>
            <div class="input-field-group">
                <div class="input-field">
                    <label for="inputfirstname" id="labelfirstname">first name<span class="red">*</span>:</label>
                    <input type="text" name="inputfirstname" id="inputfirstname" fieldname = "first-name"  importantfield="true" runat="server" clientidmode ="static" />
                </div>
                <div class="input-field">
                    <label for="inputlastname" id="labellastname">last name<span class="red">*</span>:</label>
                    <input type="text" name="inputlastname" id="inputlastname" fieldname = "last-name" importantfield="true" runat="server"  clientidmode ="static" />
                </div>
            </div>
            <div class="input-field-group">
                <div class="input-field">
                    <label for="inputdateofbirth">dob<span
                            class="red">*</span>:</label>
                    <input type="date" name="inputdateofbirth" id="inputdateofbirth"  max="2010-01-01" fieldname = "date-of-birth" importantfield="true" runat="server" clientidmode="static"/>
                </div>
                <div class="input-field">
                    <label for="gender" id="labelgender">gender <span class="red">*</span>:</label>
                    <div class="gender-field">
                        <label for="male"><i class='bx bx-male'></i><span>m:</span></label>
                        <input type="radio" name= "gender" id="male" value="male"  clientidmode ="static">
                    </div>
                    <div class="gender-field">
                        <label for="female"><i class='bx bx-female'></i> <span>f:</span></label>
                        <input type="radio" name="gender" id="female" value="female"    clientidmode ="static">
                    </div>
                    <div class="gender-field">
                        <label for="others"><i class='bx bx-male-female'></i> <span>o:</span></label>
                        <input type="radio" name="gender" id="others"   value="others" clientidmode ="static">
                    </div>
                </div>
            </div>
            <div class="input-field-group">
                <div class="input-field imagefield" >
                    <label for="inputimage">picture<span class="red">*</span>:</label>
                    <input type="file"  id="filImages" clientidmode="static"/>
                </div>
                <div class="input-field">
                    <label for="inputdropdownbloodgroup" id="labelbloodgroup">
                        role<span class="red">*</span>:
                    </label>
                    <div id="lbroles"  height="240px"  clientidmode="static" >           
                    </div> 
                </div>
            </div>
            <div class="input-field-group">
                <div class="input-field">
                    <label for="inputemail" id="labelemail">email<span>*</span>:</label>
                    <input type="email" name="inputemail" id="inputemail" fieldname = "email" importantfield="true"  runat="server" clientidmode="static" />
                </div>
                <div class="input-field">
                    <label for="inputphone" id="labelphone">phone<span
                            class="red">*</span>:</label>
                    <input type="number" name="inputphone" id="inputphone" fieldname ="phone-number" importantfield="true"  runat="server" clientidmode="static" />
                </div>
            </div>
        </div>
      
        <div class="form-container">
            <!-- present-address-details -->
            <div class="container-present-address">
                <div class="header-text">
                    <h3>present-address</h3>
                </div>
                <div class="input-field-group">
                    <div class="input-field">
                        <label for="inputpresentline1" id="labelpresentline1">line-1<span class="red">*</span>:</label>
                        <input type="text" name="inputpresentline1" id="inputpresentline1" fieldname ="present-line1"
                        importantfield="true"  runat="server" clientidmode="static"/>
                    </div>
                    <div class="input-field">
                        <label for="inputpresentline2" id="present-label-line2">line-2:</label>
                        <input type="text" name="inputpresentline2" id="inputpresentline2" fieldname ="present-line2" importantfield="false" runat="server" clientidmode="static" />
                    </div>
                </div>
              
                <div class="input-field-group">
                  
                    <div class="input-field">
                        <label for="inputdropdowncountry" id="labelpresentcountry">country<span class="red">*</span>
                            :</label>
                       <Select id="ddlcountrynamespresent" clientidmode="static" >
                        <option value="0" >Select Country</option>
                        </Select>
                      
                    </div>
                    <div class="input-field">
                          <label for="statenamespresent" id="labelpresentstate">state<span class="red">*</span>
                            :</label>
                        <Select id="ddlstatenamespresent" clientidmode="static" >
                        <option value="0" >Select State</option>
                        </Select>
                    </div>
                </div>
                   
                <div class="input-field-group">
                    <div class="input-field">
                        <label for="city-names-present" id="label-present-city"> city <span class="red">*</span>:</label>
                        <input placeholder="enter city" id="inputcitypresent" type="text" fieldname ="present-city-name" importantfield="true"  runat="server" clientidmode="static"/>
                       
                    </div>
                    <div class="input-field">
                        <label for="inputpresentpincode" id="labelpresentpincode"> pincode<span class="red">*</span>
                            :</label>
                        <input type="text" name="inputpresentpincode" id="inputpresentpincode" class="validateonchange" fieldname ="present-pincode" importantfield="true"  runat="server" clientidmode="static"/>
                    </div>
                </div>
            </div>

            <!-- permanent-address-details -->
            <div class="container-permanent-address">
                <div class="header-text" >
                    <h3  title="to change the permanent address uncheck the checkbox first">permanent-address <label for="sameas">(same as present </label><span><input type="checkbox" name="sameas" id="sameas" /></span>)</h3>
                </div>

                <div class="input-field-group">
                    <div class="input-field">
                        <label for="inputpermanentline1" id="labelpermanentline1">line-1<span
                                class="red">*</span>:</label>
                        <input type="text" name="inputpermanentline1" id="inputpermanentline1" fieldname = "permanent-line1" importantfield="true"  runat="server" clientidmode="static"/>
                    </div>
                    <div class="input-field">
                        <label for="inputpermanentline2">line-2:</label>
                        <input type="text" name="inputpermanentline2" id="inputpermanentline2" fieldname = "permanent-line2"  importantfield="false"  runat="server" clientidmode="static"/>
                    </div>
                </div>
                <asp:updatepanel id="updatepanel1" runat="server">  
                     <contenttemplate>
                <div class="input-field-group">
                    <div class="input-field">
                        <label for="countrynamespermanent" id="labelpermanentcountry">country<span
                                class="red">*</span>:</label>

                          <Select id="ddlcountrynamespermanent"  fieldname="permanent-country-name" importantfield="true" clientidmode="static">
                           <option value="0">select country</option>
                         </Select>
                    </div>
                   <div class="input-field">
                          <label for="statenamespermanent" id="labelpermanentstate">state<span class="red">*</span>
                            :</label>
                       <Select id="ddlstatenamespermanent" clientidmode="static" >
                           <option value="0">select State</option>
                       </Select>
                    </div>
                </div>
                  </contenttemplate>  
                 </asp:updatepanel>  
                <div class="input-field-group">
                    <div class="input-field">
                        <label for="city-names-permanent" id="labelpermanentcity">city<span class="red">*</span>:</label>
                        <input  id="inputpermanentcity" 
                        type="text"
                        placeholder="enter city"  fieldname="permanent-city-name" importantfield="true" clientidmode="static" runat="server"/>
                    </div>
                    <div class="input-field">
                        <label for="inputpermanentpincode" id="labelpermanentpincode"> pincode<span
                                class="red">*</span>:</label>
                        <input type="text" name="inputpermanentpincode" id="inputpermanentpincode" class="validateonchange" fieldname="permanent-pincode" clientidmode="static" importantfield="true"  runat="server"/>
                    </div>
                </div>
            </div>
            <div class="input-field-group">
                 <div class="input-field">
                    <label for="inputhobbies">hobbies:</label>
                    
                   <input list="hobbylist" name="inputhobbies" id="inputhobbies" class="multidatalist" multiple="multiple" type="text" title="add more hobbies separated by commas" fieldname="hobby-list"  importantfield="false" runat="server" clientidmode="static"/>
                    <datalist id="hobbylist">
                        <option value="dancing"/>
                        <option value="singing"/>
                        <option value="painting"/>
                        <option value="play instrument"/>
                        <option value="trecking"/>
                    </datalist>
                </div>
                <div class="input-field">
                    <label for="subscribe">subscribe:</label>
                    <input type="checkbox" name="subscribe" id="subscribe" fieldname="subscribed" clientidmode="static"  runat="server"  />
                </div>
                 <div class="input-field">
                    <label for="password">Password:</label>
                    <input type="password" name="password" id="txtpassword" fieldname="password"  runat="server" clientIdMode ="Static" />
                </div>
            </div>
            <div class="input-field-group buttons">
                <div class="input-field">
                    <div class="btn-submit" id="SubmitDiv" runat="server" clientIdmode="static">
                         <button id="btnsubmit" >Submit</button>
                    </div>
                     <div class="btn-edit">
                       <button  id="btnedit" clientidmode="static"  >Edit</button>
                    </div>
                     <div class="btn-delete" id="DeleteDiv" runat="server" clientidmode="static">
                        <button  id="btnDelete" >Delete</button>
                    </div>
                </div>
            </div>
        </div>
</div>

   <div class="tabcontent" id="userFiles">
       <div class="notes-container">
            <div class="txt-notes">
            <a>Upload File:</a>
       <input type="file" id="userfile" />
       <button value="upload" id="btnUploadFile" >Upload</button>
       </div>
        <div class="personal-files">

        </div>
       </div>
      
    </div>
</asp:Content>

