function ValidateLogin() {
    var error;
    $(".login-container input[type='email'] ,.login-container input[type='password'] ").each(function () {
        if ($(this).val().trim() == "") {
            var labelId = $(this).attr("refto");
            $(`#${labelId}`).css("color", "red");
            error = true;
        }
        else {
            error = false;
        }
    })
    if (error == true) {
        alert("complete the form");
    }
    return error;
}