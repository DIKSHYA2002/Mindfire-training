$(document).ready(function () {

    detailBtn.style.backgroundColor = "white";
    detailBtn.style.color = "black";
    userDetails.style.display = "block";

    $("#detailBtn").click(function (e) {
        e.preventDefault();
        console.log("selected index is details tab")
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

    });

    $("#noteBtn").click(function (e) {
        e.preventDefault();
        console.log("selected index is note tab")
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
        console.log("selected index is files tab")
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
    })


    $('#usersBtn').click(function (e) {
        e.preventDefault();
        console.log("selected index is userlist tab")
        var i, tabcontent, tablinks;
        tablinks = document.getElementsByClassName("tablink");
        for (i = 0; i < tablinks.length; i++) {
            tablinks[i].style.backgroundColor = "black";
            tablinks[i].style.color = "white";
        }
        tabcontent = document.getElementsByClassName("tabcontent");
        for (i = 0; i < tabcontent.length; i++)
        {
            tabcontent[i].style.display = "none";
        }
        usersBtn.style.backgroundColor = "white";
        usersBtn.style.color = "black";
        tablinks = document.getElementsByClassName("tablink");
        userList.style.display = "block";
    })



    $.ajax({
        type: "POST",
        url: "AdminDashboard.aspx/GetUserList",
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: "false",
        success: function (response) {
            console.log(response.d);
            getuserdetails(response.d);
        },
        Error: function (response) {
            alert(response);
        }
    });



    function getuserdetails(d) {
        console.log(d)
        d.forEach((item => {
            var $newDiv = `<div class="row ">
        <div class="col-cell">${item.FirstName}</div>
          <div class="col-cell">${item.LastName}</div>
          <div class="col-cell">${item.Email}</div>
          <div class="col-cell">${item.PhoneNumber}</div>
           <div class="col-cell">${item.Roles}</div>
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
                window.location = "UserDashboard.aspx?ID=" + id;
                e.preventDefault();
            });

        }))
    }

})