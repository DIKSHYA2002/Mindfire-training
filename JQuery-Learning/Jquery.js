$(document).ready(function () {
    var BearerToken = "";
    getApiKey();
    async function getApiKey() {
        await fetch('https://www.universal-tutorial.com/api/getaccesstoken', {
            method: 'GET',
            headers: {
                "Accept": "application/json",
                "api-token": "Bf74me7YZvGJfEIRttHYu2vbBQC6ivvGEbunFVrqd0Jv2Gp3TLYKHRdWJRb9vS1Av2I",
                "user-email": "ddikshya.agarwal2002@gmail.com"
            }
        })
            .then(response => response.json())
            .then(response => {
                BearerToken = response.auth_token;
            })
            .catch(err => console.error(err));
    }
    function previewFile() {
        var preview = document.querySelector('img');
        var file = document.querySelector('input[type=file]').files[0];
        var reader = new FileReader();
      reader.onloadend = function () {
        preview.src = reader.result;
        }
    if (file) {
      reader.readAsDataURL(file);
      localStorage.removeItem('user-image');
      reader.addEventListener('load', () => {
        localStorage.setItem('user-image', reader.result);
    });
    } else {
      preview.src = "";
    }
  }
    function getCountries(obj, obj1) {
        return async () => {
            await fetch('https://www.universal-tutorial.com/api/countries/', {
                method: 'GET',
                headers: {
                    "Authorization": `Bearer ${BearerToken}`,
                    "Accept": "application/json"
                },
            })
                .then(response => response.json())
                .then(response => {
                    obj1.innerHTML = ""; obj1.innerHTML = `<option value=''>Select State</option>`;
                    response.forEach(element => {
                        $(`#${obj.id}`).append( $('<option/>').attr('value', `${element.country_name}`).text(`${element.country_name}`));
                    });
                })
                .catch(err => console.error(err));
        }
    }
    function getStates(obj1, obj2, obj3) {
        return async () => {
            await fetch(`https://www.universal-tutorial.com/api/states/${$(obj1).val()}`, {
                method: 'GET',
                headers: {
                    "Authorization": `Bearer ${BearerToken}`,
                },
            })
                .then(response => response.json())
                .then(response => {
                    obj3.innerHTML = "";
                    response.forEach(element => {
                        $(`#${obj2.id}`).append($('<option/>').attr('value', `${element.state_name}`).text(`${element.state_name}`));
                    });
                    getCity(obj3, obj2);
                })
                .catch(err => console.error(err));
        }
    }
    function getCity(city, state) {
        return async () => {
            await fetch(`https://www.universal-tutorial.com/api/cities/${$(state).val()}`, {
                method: 'GET',
                headers: {
                    "Authorization": `Bearer ${BearerToken}`,
                },
            })
                .then(response => response.json())
                .then(response => {
                    city.innerHTML = ''
                    response.forEach(element => {
                        $(`#${city.id}`).append($('<option/>').attr('value', `${element.city_name}`).text(`${element.city_name}`));
                    });
                })
                .catch(err => console.error(err));
        }

    }
    $('#countryNamesPresent').click(getCountries(countryNamesPresent, stateNamesPresent));
    $('#countryNamesPermanent').click(getCountries(countryNamesPermanent, stateNamesPermanent));
    $('#stateNamesPresent').click(getStates(countryNamesPresent, stateNamesPresent, citynamespresentDatalist));
    $('#stateNamesPermanent').click(getStates(countryNamesPermanent, stateNamesPermanent, citynamespermanentDatalist))
    $('#inputCityPresent').click(getCity(citynamespresentDatalist, stateNamesPresent));
    $('#inputPermanentCity').click(getCity(citynamespermanentDatalist, stateNamesPermanent));
    function presenttopermanent(value) {
        return function () {
          if (value.checked == true) {
            var valuesTextBox= $('.container-present-address input[type="text"]');
            var permanentFields =   $('.container-permanent-address input[type="text"]');  
            for(var i = 0; i < valuesTextBox.length; i++){
                $(permanentFields[i]).val($(valuesTextBox[i]).val()); 
                $(permanentFields[i]).attr('disabled' ,'disabled');
            }
          var valuesSelectBox = $('.container-present-address select'); 
          var permanentFields =   $('.container-permanent-address select');
          for(var i = 0; i < valuesSelectBox.length; i++){
            $(permanentFields[i]).empty();
            var option= $('<option/>')
            $(option).val($(valuesSelectBox[i]).val());
            $(option).text($(valuesSelectBox[i]).val());
            $(permanentFields[i]).append($(option)); 
            $(permanentFields[i]).attr('disabled' ,'disabled');
            }
          }
          else{
            var permanentFields = $('.container-permanent-address input[type="text"],.container-permanent-address select');  
            for(var i = 0; i < permanentFields.length; i++){
                $(permanentFields[i]).removeAttr('disabled');
            }
          }
      }
    }
    $('form').submit(function (e) {
        e.preventDefault();
         let error = 0;
         let user = new Object();
         let presentAddress = new Object();
         let permanentAddress = new Object();
        $('input ,select').each(function () {
            if (($(this).attr('type') !== "file") && ($(this).attr('type') !== "checkbox") && ($(this).attr('type') !== "radio") && ($(this).attr('type') !== "submit") && ($(this).attr('type') !== "reset")) 
            {
                if($(this).val() == '' && ($(this).attr('importantField')=='false'))
                {
                    if($(this).attr('fieldName').includes("Present"))
                    {
                        presentAddress[`${$(this).attr('fieldName')}`]= `NA`;
                    }
                   else if(`${$(this).attr('fieldName')}`.includes("Permanent"))
                    {
                        permanentAddress[`${$(this).attr('fieldName')}`]= `NA`;
                    } 
                    else
                    {
                        user[`${$(this).attr('fieldName')}`] = `NA`;
                    }
                }
               else if ($(this).val() == '' && ($(this).attr('importantField')=='true') )
                {
                    error=1;
                }
                else 
                {
                    if($(this).attr('fieldName').includes("Present"))
                    {
                        presentAddress[`${$(this).attr('fieldName')}`]= `${$(this).val()}`;
                    }
                    else if(`${$(this).attr('fieldName')}`.includes("Permanent"))
                    {
                        permanentAddress[`${$(this).attr('fieldName')}`]= `${$(this).val()}`;
                    }
                    else
                    {
                        user[`${$(this).attr('fieldName')}`] = `${$(this).val()}`;
                    }
                }
            }
        });
        if($("input[name='Gender']:checked").attr('id') === undefined)
        {
            error=1;
            $("#labelGender").css('color','red');
        }
        let span = document.getElementsByClassName("close")[0];
        showModal();
        function showModal() {
            if (error == 1) {
                $('#myModal').css('display', 'block');
                document.querySelector('#modalContent p').innerHTML = '<h1 class="errormessage"> Please Complete the form</h1>';
            }
            else if (error == 0) {
                user['gender']=$("input[name='Gender']:checked").prop('id');
                user['present-Address']= presentAddress;
                user['permanent-Address']= permanentAddress;
                localStorage.setItem('personalD', JSON.stringify(user));
                $('#myModal').css('display', 'block');
                document.querySelector('#modalContent p').innerHTML = '<h1 id="Heading-modal">Form Submitted Succesfully!</h1>'
                let Titles = Object.keys(user);
                document.querySelector('#modalContent p').innerHTML += `<div id="results"></div>`
                Titles.forEach(element => {
                   if(element== "present-Address")
                   {
                    document.querySelector('#modalContent p #results').innerHTML +=`<h3>Present Address:</h3>`
                    let newt = Object.keys(user['present-Address'])
                    newt.forEach(element=>{
                        document.querySelector('#modalContent p #results').innerHTML += `<div class="input-field-group"><div class="input-field">${element}:</div><div class="input-field-answer">${user['present-Address'][element]}</div></div>`
                    }
                    )
                   }
                 else  if(element== "permanent-Address")
                   {
                    document.querySelector('#modalContent p #results').innerHTML +=`<h3>Permanent Address:</h3>`
                    let newt = Object.keys(user['permanent-Address'])
                    newt.forEach(element=> document.querySelector('#modalContent p #results').innerHTML += `<div class="input-field-group"><div class="input-field">${element}:</div><div class="input-field-answer">${ user['permanent-Address'][element]}</div></div>` )
                   }
                     else  
                        document.querySelector('#modalContent p #results').innerHTML += `<div class="input-field-group"><div class="input-field">${element}:</div><div class="input-field-answer">${user[element]}</div></div>`
                });
                console.log("no error");
            }
        }
        span.onclick = function () {
            $('#myModal').css('display', 'none');
        }
        window.onclick = function (event) {
            if (event.target == $('#myModal')) {
                $('#myModal').css('display', 'none');
            }
        }
    }
    )
    $("input ,select").on("change", function () {
        if (($(this).attr('type') !== "file") && ($(this).attr('type') !== "checkbox") && ($(this).attr('type') !== "radio")) {
            $(this).css(
                {
                    'border': `${($(this).val() == '') && ($(this).attr('importantField') == 'true') ? ('2px red solid') : ('2px green solid')}`,
                })
}
});
document.getElementById('inputImage').addEventListener('change', previewFile);
$("#sameas").change(presenttopermanent(sameas));
$(".multidatalist").focusin(function () { $(this).attr("type", "email"); });
$(".multidatalist").focusout(function () { $(this).attr("type", "textbox"); });
});