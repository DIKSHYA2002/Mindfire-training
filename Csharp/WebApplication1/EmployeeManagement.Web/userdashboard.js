
$(document).ready(function () {
   
    $(".button-links").on('click', "#detailBtn" , (function (e) {
        e.preventDefault();
        var i, tabcontent, tablinks;
        tablinks = document.getElementsByClassName("tablink");
        for (i = 0; i < tablinks.length; i++) {
            tablinks[i].style.backgroundColor = "black";
            tablinks[i].style.color = "white";
        }
        tabcontent = document.getElementsByClassName("tabcontent");
        for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].style.display = "none";
        }
        detailBtn.style.backgroundColor = "white";
        detailBtn.style.color = "black";
        userDetails.style.display = "block";
    }))

    $('.imagefield').on("change", "#filImages" , function () {
        const file = this.files[0];
        console.log(file);
        if (file) {
            let reader = new FileReader();
            reader.onload = function (event) {
                console.log(event.target.result);
                $('#image1').attr('src', event.target.result);
            }
            reader.readAsDataURL(file);
        }
    });
    $('#btnsubmit').click(function (e) {

        var u = {};
        u.UserFirstName = inputfirstname.value;
        u.UserLastName = inputlastname.value;
        u.UserEmail = inputemail.value;
        u.UserPhone = inputphone.value;
        u.UserGender = $("input[name='gender']:checked").attr('id');
        u.Userpassword = txtpassword.value;
        u.UserHobbies = inputhobbies.value;
        u.UserPresentLine1 = inputpresentline1.value;
        u.UserPresentLine2 = inputpresentline2.value;
        u.UserPresentPincode = parseInt(inputpresentpincode.value);
        u.UserDateOfBirth = inputdateofbirth.value;
        u.UserPresentCountryID = parseInt($('#ddlcountrynamespresent :selected').val());
        u.UserPresentStateID = parseInt($('#ddlstatenamespresent :selected').val());
        u.UserPermanentLine1 = inputpermanentline1.value;
        u.UserPermanentLine2 = inputpermanentline2.value;
        u.UserPermanentCountryID = parseInt($('#ddlcountrynamespermanent :selected').val());
        u.UserPermanentStateID = parseInt($('#ddlstatenamespermanent :selected').val());
        u.UserPermanentPincode = parseInt(inputpermanentpincode.value);
        u.Imagename = "none";
        u.UserSubscribed = $("#subscribe").attr("checked") ? "true" : "false";
        u.UserPermanentCity = inputpermanentcity.value;
        u.UserPresentCity = inputcitypresent.value;
        
        const fileInput = document.querySelector('#filImages');
        const file = fileInput.files[0];
        var userroles = [];
        $('.user-role input[type=checkbox]').each(function () {
            if (this.checked) {
                userroles.push($(this).val());
            }
        });
        var formdata = new FormData();
        formdata.append("userfile", file, file.name);
        userroles.forEach((value) => {
            formdata.append('userroles[]', value);
        });

        let userkeys = Object.keys(u);

        userkeys.forEach((userattributes) => {
            formdata.append(userattributes, u[userattributes]);
        });

            $.ajax({
                type: "POST",
                url: "SubmitUserHandler.ashx",
                data: formdata,
                contentType: false,
                processData: false,
                success: function (response) {
                    alert("succesfully submitted");
                },
                Error: function (response) {
                    alert(response);
                }
            });
        console.log(u);
        e.preventDefault();
    });

    function SubmitValidation(em) {

        var flag = 1;
        Object.keys(em).forEach(key => {
            console.log(em[key], key, em);
            if (em[key] === '' || em[key] === NaN || em[key] === undefined) {
                flag = 0;
            }
        });



    }

    $("#noteBtn").click(function (e) {
        e.preventDefault();

        var i, tabcontent, tablinks;
        tablinks = document.getElementsByClassName("tablink");
        for (i = 0; i < tablinks.length; i++) {
            tablinks[i].style.backgroundColor = "black";
            tablinks[i].style.color = "white";
        }

        tabcontent = document.getElementsByClassName("tabcontent");
        for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].style.display = "none";
        }
        noteBtn.style.backgroundColor = "white";
        noteBtn.style.color = "black";
        tablinks = document.getElementsByClassName("tablink");
        userNotes.style.display = "block";

    });
    $("#fileBtn").click(function (e) {
        e.preventDefault();
        var i, tabcontent, tablinks;
        tablinks = document.getElementsByClassName("tablink");
        for (i = 0; i < tablinks.length; i++) {
            tablinks[i].style.backgroundColor = "black";
            tablinks[i].style.color = "white";
        }
        tabcontent = document.getElementsByClassName("tabcontent");
        for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].style.display = "none";
        }
        fileBtn.style.backgroundColor = "white";
        fileBtn.style.color = "black";
        tablinks = document.getElementsByClassName("tablink");
        userFiles.style.display = "block";
        const queryString = window.location.search;
        let params = new URLSearchParams(queryString);
        var userId = parseInt(params.get('ID'));
        var arr = { id: userId };
        FetchFiles(arr);
    })
    getAllCountry();
    GetRoles();
    function GetRoles() {
        $.ajax({
            type: "POST",
            url: "Dashboard.aspx/GetAllRoles",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: "false",
            success: function (response) {

                response.d.forEach((item => {
                    var $newDiv = `<div class="user-role"><input id="userRole${item.RoleID}" type="checkbox" class="UserRole" value="${item.RoleID}" /><label for="userRole${item.RoleID}">${item.RoleName}</label></div>`
                    $("#lbroles").append($newDiv);
                }))
            },
            Error: function (response) {
                alert(response);
            }
        });
    }
    function getAllCountry() {
        $.ajax({
            type: "POST",
            url: "Dashboard.aspx/GetAllCountry",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: "false",
            success: function (response) {
                response.d.forEach((item => {
                    var $newDiv = `<option value="${item.CountryId}">${item.CountryName}</option>`
                    $("#ddlcountrynamespresent").append($newDiv);
                    $("#ddlcountrynamespermanent").append($newDiv);
                }
                ))
                getAllStates();
            },
            Error: function (response) {
                alert(response);
            }
        });
    }

    $("#ddlcountrynamespresent").on("change", function (e){
        getAllStates();
    })

    $("#ddlcountrynamespermanent").on("change", function (e) {
        getAllPermanentStates();
    })
   
    GetUserDetails();
    getUserList();

    function GetUserDetails()
    {
        const queryString = window.location.search;
        let params = new URLSearchParams(queryString);
        var userId = parseInt(params.get('ID'));
        var arr = { id: userId };
        $.ajax({
            type: "POST",
            url: "Dashboard.aspx/GetUser",
            data: JSON.stringify(arr),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: "false",
            success: function (response) {

                FillUserData(response.d);
                FillUserRoles(response.d.UserID);
            },
            Error: function (response) {
                alert(response);
            }
        });
        function FillUserRoles(userid) {
           
            var arr = { id: userid };
            $.ajax({
                type: "POST",
                url: "Dashboard.aspx/GetUserRoles",
                data: JSON.stringify(arr),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: "false",
                success: function (response) {
                    response.d.forEach(item => {
                        $(`#userRole${item.RoleID}`).prop("checked", true);
                    })
                },
                Error: function (response) {
                    alert(response);
                }
            });
        }
        function FillUserData(user) {
            inputfirstname.value = user.UserFirstName;
            inputlastname.value = user.UserLastName;
            var str = user.UserDateOfBirth.toString();
            var num = parseInt(str.replace(/[^0-9]/g, ""));
            var date = new Date(num);
            var ndate = date.toISOString().substring(0,10);
            inputdateofbirth.value = ndate;
            $('input[name="gender"]').filter(`[value='${user.UserGender.toLowerCase()}']`).attr('checked', 'checked');
            inputemail.value = user.UserEmail;
            inputphone.value = parseInt(user.UserPhone);
            inputpresentline1.value = user.UserPresentLine1;
            inputpresentline2.value = user.UserPresentLine2;
            inputpresentpincode.value = user.UserPresentPincode;
            $('#ddlcountrynamespresent').val(user.UserPresentCountryID);
            getAllStates(user.UserPresentStateID);
            inputcitypresent.value = user.UserPresentPincode;
            inputpermanentline1.value = user.UserPermanentLine1;
            inputpermanentline2.value = user.UserPermanentLine2;
            ddlcountrynamespermanent.value = user.UserPermanentCountryID;
            getAllPermanentStates(user.UserPermanentStateID);
            inputpermanentcity.value = user.UserPermanentCity;
            inputpermanentpincode.value = user.UserPermanentPincode;
            inputhobbies.value = user.UserHobbies;
            subscribe.checked = (user.subscribe == 'true') ? "true" : "false";
            $('#image1').attr('src', "./ImageFolder/" + user.Imagename);
        }
    }
    function getAllStates(stateid = -1) {

        var $countryid = $("#ddlcountrynamespresent").val();
        var arr = { countryid: $countryid }
        $.ajax({
            type: "POST",
            url: "Dashboard.aspx/GetStates",
            data: JSON.stringify(arr),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: "false",
            success: function (response) {
                response.d.forEach((item) => {
                    var $newDiv = `<option value="${item.StateId}">${item.StateName}</option>`
                    $("#ddlstatenamespresent").append($newDiv);
                })
                if (stateid != -1) {
                    $("#ddlstatenamespresent").val(stateid);
                }
            },
            Error: function (response) {
                alert(response);
            }
        });
    }
    function getAllPermanentStates(stateid = -1) {

        var $countryid = $("#ddlcountrynamespermanent").val();
        var arr = { countryid: $countryid }
        $.ajax({
            type: "POST",
            url: "Dashboard.aspx/GetStates",
            data: JSON.stringify(arr),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: "false",
            success: function (response) {
                response.d.forEach((item) => {
                    var $newDiv = `<option value="${item.StateId}">${item.StateName}</option>`
                    $("#ddlstatenamespermanent").append($newDiv);
                })
                if (stateid != -1) {
                    $("#ddlstatenamespermanent").val(stateid);
                }
            },
            Error: function (response) {
                alert(response);
            }
        });
    }

    
    function FetchFiles(arr) {
        $.ajax({
            type: "POST",
            url: "Dashboard.aspx/GetFiles_Employee",
            data: JSON.stringify(arr),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: "false",
            success: function (response) {
                getFiles(response.d);
                
            },
            Error: function (response) {
                alert(response);
            }
        });
        function getFiles(d) {

            $(".personal-files").empty();
            d.forEach((item => {
                var str = item.CreatedOn.toString();
                var num = parseInt(str.replace(/[^0-9]/g, ""));
                var date = new Date(num);
                var ndate = date.toLocaleDateString();
                var $newDiv = `<div id='${item.FileId}' class="file-section txt-notes"> ${ndate} : ${item.ActualFileName} <button targetName ="${item.StoredFileName}" value="download" class="btnDownloadFile" >Download</button> <button targetid ="${item.FileId}" value="delete" class="btnDeleteFile">Delete</button></div>`
                $(".personal-files").append($newDiv);
            })
            )
            $(".file-section").on("click", ".btnDeleteFile", function (e) {
                var fileid = $(this).attr("targetid");
                var data = new FormData();
                data.append("ID", fileid);

                $.ajax({
                    url: `FileDelete.ashx`,
                    type: "POST",
                    data:  data,
                    contentType: false,
                    processData: false,
                    success: function (response) {
                        alert("succesfully deleted");
                        const queryString = window.location.search;
                        let params = new URLSearchParams(queryString);
                        var userId = parseInt(params.get('ID'));
                        var arr = { id: userId };
                        FetchFiles(arr);
                    },
                    Error: function (response) {
                        alert(response);
                    }
                });
                e.preventDefault();
            })

            $(".file-section").on("click", ".btnDownloadFile", function (e) {
                e.preventDefault();
                window.location.href = "FileDownload.ashx?filename=" + $(this).attr('targetName');
            });
        }



    }

    $("#btnUploadFile").click(function (e) {
        let files = $("#userfile")[0].files;
        var createdOn = Date.now;
        var data = new FormData();
        data.append(files[0].name, files[0]);
        const params = new URLSearchParams(window.location.search);
        data.append("ID", params.get('ID'));
        $.ajax({
            url: "FileHandler.ashx",
            type: "POST",
            data: data,
            contentType: false,
            processData: false,
            success: function (result) {
                alert("files uploaded succesfully");
                const queryString = window.location.search;
                let params = new URLSearchParams(queryString);
                var userId = parseInt(params.get('ID'));
                var arr = { id: userId };
                FetchFiles(arr);
            },
            error: function (err) {
                alert(err.statusText)
            }
        });

        e.preventDefault();
    }
    );
    function getUserList() {
        $.ajax({
            type: "POST",
            url: "About.aspx/GetUserList",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: "false",
            success: function (response) {
                console.log(response.d);
                getuserLISTS(response.d);
            },
            Error: function (response) {
                alert(response);
            }
        });
    }
    function getuserLISTS(d) {
        console.log(d)
        d.forEach((item => {
            var $newDiv = `<div class="row ">
        <div class="col-cell">${item.UserFirstName}</div>
          <div class="col-cell">${item.UserLastName}</div>
          <div class="col-cell">${item.UserEmail}</div>
          <div class="col-cell">${item.UserPhone}</div>
           <div class="col-cell ">
           <button id="editbutton" runat="server" clientIDmode="static" targetid=${item.UserID}><span class="material-symbols-outlined">
            edit
            </span></button>
           </div>
           </div>
        `
            $(".table-rows").append($newDiv);

            $('.col-cell').on("click", "#editbutton", function (e) {
                var id = $(this).attr("targetid");
                window.location = "Dashboard.aspx?ID=" + id;
                e.preventDefault();
            });

        }))
    }

    getNotes();
    getPrivateNotes();

    function getNotes() {
        const queryString = window.location.search;
        let params = new URLSearchParams(queryString);
        var userId = parseInt(params.get('ID'));
        var arr = { id: userId };
        $.ajax({
            type: "POST",
            url: "Dashboard.aspx/GetNotes_Employees",
            data: JSON.stringify(arr),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: "false",
            success: function (response) {
                $(".personal-notes").empty();
                response.d.forEach((item => {
                    var $newDiv = `<div class ="note-part" ><div class="note-text">${item.Note}</div><div class="note-button"><button class="note-delete" targetid="${item.ID}"  id="BtnDelete">Delete</button></div></div>`
                    $(".personal-notes").append($newDiv);
                }))


                $(".note-button").on("click", "#BtnDelete", function (e) {
                    var userid = $(this).attr("targetid");
                    var arr = { id: userid };

                    $.ajax({
                        type: "POST",
                        url: "Dashboard.aspx/DeleteNote",
                        data: JSON.stringify(arr),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: "false",
                        success: function (response) {
                            alert("note deleted succesfully");
                            getNotes();
                            getPrivateNotes();
                        },

                        Error: function (response) {
                            alert(response);
                        }
                    });
                    e.preventDefault();
                })
            },
            Error: function (response) {
                alert(response);
            }
        });


      

    }

 
   
    

    function getPrivateNotes()
    {
        const queryString = window.location.search;
        let params = new URLSearchParams(queryString);
        var userId = parseInt(params.get('ID'));
        var arr = { id: userId };
        $.ajax({
            type: "POST",
            url: "Dashboard.aspx/GetNotes_Private",
            data: JSON.stringify(arr),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: "false",
            success: function (response) {
                $(".private-notes").empty();
                response.d.forEach((item => {
                    var $newDiv = `<div class ="note-part" ><div class="note-text">${item.Note}</div><div class="note-button"><button class="note-delete" targetid="${item.ID}"  id="BtnDelete">Delete</button></div></div>`
                    $(".private-notes").append($newDiv);
                }))
            },
            Error: function (response) {
                alert(response);
            }
        });
    }

    $(".txt-notes").on("click", "#btnAddNote", function (e) {
        e.preventDefault();
        const queryString = window.location.search;
        let params = new URLSearchParams(queryString);
        var userId = parseInt(params.get('ID'));
        if (document.getElementById("chkPrivate") == undefined) {
            var Types = "User";
            var notetext = txtNotes.value;
        }
       
        else { 
            if (chkPrivate.checked) {
                var Types = "Company";
                var notetext = txtNotes.value;
            }
            else {
                var Types = "User";
                var notetext = txtNotes.value;
            }
           
        }
        var arr = { toid : userId, note: notetext, type: Types };
     
        $.ajax({
            type: "POST",
            url: "Dashboard.aspx/SetNotes",
            data: JSON.stringify(arr),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: "false",
            success: function (response) {
                alert("succesfully added note");
                getNotes();  
                getPrivateNotes();
            },
            Error: function (response) {
                alert(response);
            }
        });

    })

    $(".btn-delete").on("click", "#btnDelete", function (e) {
        const queryString = window.location.search;
        let params = new URLSearchParams(queryString);
        var userId = parseInt(params.get('ID'));
        var arr = { id: userId };
        $.ajax({
            type: "POST",
            url: "Dashboard.aspx/DeleteUser",
            data: JSON.stringify(arr),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: "false",
            success: function (response) {
                    
                    window.location.href = "About.aspx";

            },

            Error: function (response) {
                alert(response);
            }
        });
    })

    $('.btn-edit').on("click", "#btnedit", function (e) {
        const queryString = window.location.search;
        let params = new URLSearchParams(queryString);
        var userId = parseInt(params.get('ID'));

        var u = {};
        u.UserID = userId;
        u.UserFirstName = inputfirstname.value;
        u.UserLastName = inputlastname.value;
        u.UserEmail = inputemail.value;
        u.UserPhone = inputphone.value;
        u.UserGender = $("input[name='gender']:checked").attr('id');
        u.Userpassword = txtpassword.value;
        u.UserHobbies = inputhobbies.value;
        u.UserPresentLine1 = inputpresentline1.value;
        u.UserPresentLine2 = inputpresentline2.value;
        u.UserPresentPincode = parseInt(inputpresentpincode.value);
        u.UserDateOfBirth = inputdateofbirth.value;
        u.UserPresentCountryID = parseInt($('#ddlcountrynamespresent :selected').val());
        u.UserPresentStateID = parseInt($('#ddlstatenamespresent :selected').val());
        u.UserPermanentLine1 = inputpermanentline1.value;
        u.UserPermanentLine2 = inputpermanentline2.value;
        u.UserPermanentCountryID = parseInt($('#ddlcountrynamespermanent :selected').val());
        u.UserPermanentStateID = parseInt($('#ddlstatenamespermanent :selected').val());
        u.UserPermanentPincode = parseInt(inputpermanentpincode.value);
        u.Imagename = "none";
        u.UserSubscribed = $("#subscribe").attr("checked") ? "true" : "false";
        u.UserPermanentCity = inputpermanentcity.value;
        u.UserPresentCity = inputcitypresent.value;

        var userroles = [];
        $('.user-role input[type=checkbox]').each(function () {
            if (this.checked) {
                userroles.push($(this).val());
            }
        });
        var formdata = new FormData();

        const fileInput = document.querySelector('#filImages');
        if (fileInput.files.length !== 0) {
            const file = fileInput.files[0];
            formdata.append("userfile", file, file.name);
        }
        userroles.forEach((value) => {
            formdata.append('userroles[]', value);
        });


        let userkeys = Object.keys(u);

        userkeys.forEach((userattributes) => {
            formdata.append(userattributes, u[userattributes]);
        });

        $.ajax({
            type: "POST",
            url: "EditUserHandler.ashx",
            data: formdata,
            contentType: false,
            processData: false,
            success: function (response) {
                alert("Succesfully Edited Form");
            },
            Error: function (response) {
                alert(response);
            }
        });
        console.log(u);
        e.preventDefault();

    })

})


