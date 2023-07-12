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
                    obj1.innerHTML = "";
                    obj1.innerHTML = `<option value=''>Select State</option>`;
                    response.forEach(element => {
                        var $options = $('<option/>').attr('value', `${element.country_name}`).text(`${element.country_name}`);
                        $(`#${obj.id}`).append($options);
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
                        var $options = $('<option/>').attr('value', `${element.state_name}`).text(`${element.state_name}`);
                        $(`#${obj2.id}`).append($options);
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
                        var $options = $('<option/>').attr('value', `${element.city_name}`).text(`${element.city_name}`);
                        $(`#${city.id}`).append($options);
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
    $('form').submit(function (e) {
        e.preventDefault();
        let error = 0;
        $('input ,select').each(function () {
            if (($(this).attr('type') !== "file") && ($(this).attr('type') !== "checkbox") && ($(this).attr('type') !== "radio")) 
            {

                if ($(this).val() == '') 
                {
                    error=1;
                    $(this).css({  'border': `2px red solid` } )}
                else 
                {
                     $(this).css({'border': `2px green solid`} )
                }
            }
        });
        let span = document.getElementsByClassName("close")[0];
        showModal();
        function showModal() {
            if (error == 1) {
                $('#myModal').css('display', 'block');
                document.querySelector('#modalContent p').innerHTML = '<h1 class="errormessage"> Please Complete the form</h1>';
            }
            else if (error == 0) {
                var user = new Object();
                var presentAddress = new Object();
                var permanentAddress = new Object();
                $('input ,select').each(function () {
                    if (($(this).attr('type') !== "file") && ($(this).attr('type') !== "checkbox") && ($(this).attr('type') !== "radio") && ($(this).attr('type') !== "submit") && ($(this).attr('type') !== "reset")) {
                       
                        if($(this).attr('fieldName').includes("Present"))
                        {
                            presentAddress[`${$(this).attr('fieldName')}`]= `${$(this).val()}`;
                        }
                       else if(`${$(this).attr('fieldName')}`.includes("Permanent"))
                        {
                              permanentAddress[`${$(this).attr('fieldName')}`]= `${$(this).val()}`;
                        }
                        else{
                        user[`${$(this).attr('fieldName')}`] = `${$(this).val()}`;
                        }

                    }
                });
                user['present-Address']= presentAddress;
                user['permanent-Address']= permanentAddress;
                console.log(user)
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
                        document.querySelector('#modalContent p #results').innerHTML += `<div class="input-field-group"><div class="input-field">${element}:</div><div class="input-field-answer">${ user['present-Address'][element]}</div></div>`
                    }
                    )
                   }
                 else   if(element== "permanent-Address")
                   {
                    document.querySelector('#modalContent p #results').innerHTML +=`<h3>Permanent Address:</h3>`
                    let newt = Object.keys(user['permanent-Address'])
                    newt.forEach(element=>{
                        document.querySelector('#modalContent p #results').innerHTML += `<div class="input-field-group"><div class="input-field">${element}:</div><div class="input-field-answer">${ user['permanent-Address'][element]}</div></div>`
                    }
                    )
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
                    'border': `${($(this).val() == '') ? ('2px red solid') : ('2px green solid')}`,
                })
}
});
$(".multidatalist").focusin(function () { $(this).attr("type", "email"); });
$(".multidatalist").focusout(function () { $(this).attr("type", "textbox"); });
});