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
     function getCountries(obj) {
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
              response.forEach(element => {
                var $options = $('<option/>').attr('value' , `${element.country_name}`).text(`${element.country_name}`);
                $(`#${obj.id}`).append($options);
              });
            })
            .catch(err => console.error(err));
        }
    }
    $('#countryNamesPresent').click(getCountries(countryNamesPresent));
    $('#countryNamesPermanent').click(getCountries(countryNamesPermanent));
    $('form').submit(function (e) {
        e.preventDefault();
        $('input ,select').each(function () {
            if (($(this).attr('type') !== "file") && ($(this).attr('type') !== "checkbox") && ($(this).attr('type') !== "radio")) {
                $(this).css(
                    {
                        'border': `${($(this).val() == '') ? ('2px red solid') : ('2px green solid')}`,
                    }
                )
            }
        });
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
});