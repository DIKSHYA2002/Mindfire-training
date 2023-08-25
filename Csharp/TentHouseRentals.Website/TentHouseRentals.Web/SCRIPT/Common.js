
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

    function getFormattedDate(datetimestring) {
        const date = new Date(datetimestring);
        const hours = date.getHours();
        const minutes = date.getMinutes();
        const seconds = date.getSeconds();
        const amOrPm = hours >= 12 ? 'PM' : 'AM';
        const hours12 = hours % 12 || 12;
        const timeString = `${hours12}:${String(minutes).padStart(2, '0')}:${String(seconds).padStart(2, '0')} ${amOrPm}`;
        const dateString = `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`;
        const resultString = `${dateString} ${timeString}`;
        return resultString;
    }
    function validateProductSubmit(formId) {
        var noerror;
        $(`#${formId} .input-field input ,#${formId} .input-field select`).each(function () {

            if ($(this).attr("type") == "text" || $(this).attr("type") == "number" || $(this).attr("type") == "datetime-local" || $(this).attr("type") == "password" || $(this).attr("type") == "email") {
                if ($(this).val().trim() == "") {
                    var labelId = $(this).attr("refto");
                    $(`#${labelId}`).css("color", "red");
                    noerror = false;
                }
                else {
                    var labelId = $(this).attr("refto");
                    $(`#${labelId}`).css("color", "green");
                    noerror = true;
                }
            }
            if ($(this).attr("type") == "file") {
                const fileInput = document.querySelector('#flImage');
                const file = fileInput.files[0];
                if (file == undefined) {
                    noerror = false;
                    var labelId = $("#flImage").attr("refto");
                    $(`#${labelId}`).css("color", "red");
                }
                else {
                    var labelId = $("#flImage").attr("refto");
                    $(`#${labelId}`).css("color", "green");
                    noerror = true;
                }

            }
            else {
                var selectedProductId = parseInt($('#id_select2_example').find(":selected").prop("id"));
                if (selectedProductId == -1) {
                    noerror = false;
                    $(`#lblProducts`).css("color", "red");
                }
                else {
                    noerror = true;
                    $(`#lblProducts`).css("color", "green");
                }
            }
        })
        return noerror;
    }


