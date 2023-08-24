const loadingGif = `<img src="./ImageFolder/Loading.gif" style="width:5rem; height:5rem">`;
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
