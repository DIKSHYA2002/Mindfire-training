
    $.ajax({
        type: "POST",
        url: "userlist2.aspx/GetUserList",
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async:"false",
        success: function (response) {
            console.log(response.d);
            getuserdetails(response.d);
        }   ,
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
                window.location = "default.aspx?ID=" + id;
                e.preventDefault();
            });

    }))
}



$(document).ready(function () {
$('.col-cell').on("click", "#editbutton", function (e) {
    var id = $(this).attr("targetid");
    window.location = "default.aspx?ID=" + id;
    e.preventDefault();
});
});


/*datat2.foreach((item => {
    var $newDiv = `<div>
        <div>${item.FirstName}</div>
          <div>${item.LastName}</div>
          <div>${item.Email}</div>
          <div>${item.PhoneNumber}</div>
           <div>${item.Roles}</div>
        `
    $(".table-rows").append($newDiv);
}))*/