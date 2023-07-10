
function previewFile() {
    var preview = document.querySelector('img');
    var file    = document.querySelector('input[type=file]').files[0];
    var reader  = new FileReader();
    reader.onloadend = function () {
      preview.src = reader.result;
    }
    if (file) {
      reader.readAsDataURL(file);
    } else {
      preview.src = "";
    }
  }
 function presenttopermanent(value)
{
    if(value==true)
    {
    const line1 = document.getElementById("inputPresentLine1").value;
    const line2 = document.getElementById("inputPresentLine2").value;
    const present_country = document.getElementById("country-names-present").value;
    const present_state = document.getElementById("state-names-present").value;
    const present_city = document.getElementById("inputCityPresent").value;
    const pincode = document.getElementById("inputPresentPincode").value;
    document.getElementById('inputPermanentLine1').value = line1;
    document.getElementById('inputPermanentLine2').value = line2;
    document.getElementsByName('inputPermanentPincode')[0].value = pincode;
    document.getElementById('country-names-permanent').value = present_country;
    document.getElementById('state-names-permanent').value = present_state;
    document.getElementById('inputPermanentCity').value = present_city;
  }
  else
  {
    document.getElementById('inputPermanentLine1').value = "";
    document.getElementById('inputPermanentLine2').value = "";
    document.getElementsByName('inputPermanentPincode')[0].value = "";
    document.getElementById('country-names-permanent').value = "";
    document.getElementById('state-names-permanent').value = "";
    document.getElementById('inputPermanentCity').value = "";
  }
   
}
 function checkSpecialNumberforFirstName(firstname) {
    const specialChars = /[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/;
    const check =( /[0-9]/.test(firstname)) || (specialChars.test(firstname));
    document.getElementById('inputFirstName').style.border = (check) ? '2px red solid' : '2px green solid';
    document.querySelector('#labelFirstName').style.color = (check) ? 'red' : 'green';
    document.getElementById('inputFirstName').placeholder = (check) ? 'Numbers or special characters are not allowed' : '';
}
 function checkSpecialNumberforLastName(firstname) {
    const specialChars = /[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/;
    const check =( /[0-9]/.test(firstname)) || (specialChars.test(firstname));
    document.getElementById('inputLastName').style.border = (check) ? '2px red solid' : '2px green solid';
    document.querySelector('#labelLastName').style.color = (check) ? 'red' : 'green';
    document.getElementById('inputLastName').placeholder = (check) ? 'Numbers or special characters are not allowed' : '';
}

document.querySelector('form').addEventListener('submit', formsubmit);
 async function formsubmit(e) {         
    const firstname = document.getElementById('inputFirstName').value;
    const lastname = document.getElementById('inputLastName').value;
    const dob = document.getElementById('inputDateOfBirth').value;
    const gender = (document.querySelector('input[name="inputGender"]:checked')) ? document.querySelector('input[name="inputGender"]:checked').id : "";
    const email = document.getElementById('inputEmail').value; 
    const phone = document.getElementById('inputPhone').value;
    const bloodgroup = document.getElementById('inputDropdownBloodGroup').value;
    const line1 = document.getElementById('inputPresentLine1').value;
    const line2 = document.getElementById('inputPresentLine2').value;
    const presentcountry = document.getElementById('country-names-present').value;
    const presentstate = document.getElementById('state-names-present').value;
    const presentcity = document.getElementById('inputCityPresent').value;
    const presentpincode = document.getElementsByName('inputPresentPincode')[0].value;
    const permline1 = document.getElementById('inputPermanentLine1').value;
    const permline2 = document.getElementById('inputPermanentLine2').value;
    const permstate = document.getElementById('state-names-permanent').value;
    const permcity = document.getElementById('inputPermanentCity').value;
    const permcountry = document.getElementById('country-names-permanent').value;
    const permanentpincode = document.getElementsByName('inputPermanentPincode')[0].value;
    const user = {
                FirstName: "",
                LastName: "",
                Email: "",
                DOB: "",
                Phone: "",
                BloodGroup: "",
                Gender: "",
       
                presentAddress:
                {
                    present_country: "",
                    present_line1: "",
                    present_line2: "",
                    present_state: "",
                    present_city: "",
                    present_pincode:""
                },
                permanentAddress:
                {
                    permanent_country: "",
                    permanent_line1: "",
                    permanent_line2: "",
                    permanent_state: "",
                    permanent_city: "",
                    permanent_pincode:""
                },
                hobbies: "",
                Subscribed: "",
    }

    user.FirstName = firstname;
    user.LastName = lastname;
    user.DOB = dob;
    user.Gender = gender;
    user.Email = email;
    user.Phone = phone;
    user.BloodGroup = bloodgroup;
    // user.PresentAddress.line1 = line1;
    // user.PresentAddress.line2 = line2;
    // user.PresentAddress.present_country = presentcountry;
    // user.PresentAddress.present_city = presentcity;
    // user.presenAddress.presentstate = presentstate;
    
    
    document.getElementById('inputFirstName').style.border = (firstname == "") ? '2px red solid' : '2px green solid';
    document.querySelector('#labelFirstName').style.color = (firstname == "") ? 'red' : 'green';
    document.getElementById('inputFirstName').placeholder = (firstname == "") ? 'this field is required' : '';

    document.getElementById('inputLastName').style.border = (lastname == "") ? '2px red solid' : '2px green solid';
    document.querySelector('#labelLastName').style.color = (lastname == "") ? 'red' : 'green';
    document.getElementById('inputLastName').placeholder = (lastname == "") ? 'this field is required' : '';

        document.getElementById('inputDateOfBirth').style.border = (dob == "")? '2px red solid':'2px green solid';
        document.querySelector('#label-dob').style.color = (dob=="")?'red':'green';


        document.getElementById('inputEmail').style.border = (email == "")? '2px red solid':'2px green solid';
        document.querySelector('#labelEmail').style.color = (email=="")?'red':'green';
        document.getElementById('inputEmail').placeholder = (email=="")?'this field is required':'';

        document.getElementById('inputPhone').style.border = (phone == "")? '2px red solid':'2px green solid';
        document.getElementById('inputPhone').placeholder = (phone=="")?'this field is required':'';
        document.getElementById('labelPhone').style.color = (phone=="")?'red':'green';

        document.getElementById('inputDropdownBloodGroup').style.border = (bloodgroup == "")? '2px red solid':'2px green solid';
        document.getElementById('labelBloodGroup').style.color = (bloodgroup=="")?'red':'green';

        document.getElementById('inputPresentLine1').style.border =(line1 == "")? '2px red solid':'2px green solid';
        document.getElementById('inputPresentLine1').placeholder = (line1=="")?'this field is required':'';
        document.getElementById('labelPresentLine1').style.color =  (line1=="")?'red':'green';

        document.getElementsByName('inputPresentPincode')[0].style.border = (presentpincode == "")? '2px red solid':'2px green solid';
        document.getElementsByName('inputPresentPincode')[0].placeholder = (presentpincode=="")?'this field is required':'';
        document.getElementById('labelPresentPincode').style.color = (presentpincode=="")?'red':'green';

        document.getElementById('labelGender').style.color = (gender=="")?'red':'green';


        document.getElementById('country-names-present').style.border=(presentcountry == "")? '2px red solid':'2px green solid';
        document.getElementById('labelPresentCountry').style.color=(presentcountry=="")?'red':'green';
        document.getElementById('state-names-present').style.border=(presentstate == "")? '2px red solid':'2px green solid';;
        document.getElementById('labelPresentState').style.color=(presentstate=="")?'red':'green';

        document.getElementById('inputCityPresent').style.border=(presentcity == "")? '2px red solid':'2px green solid';;
        document.getElementById('label-present-city').style.color=(presentcity=="")?'red':'green';
   
 
        document.getElementById('inputPermanentLine1').style.border =(permline1 == "")? '2px red solid':'2px green solid';
        document.getElementById('inputPermanentLine1').placeholder = (permline1=="")?'this field is required':'';
        document.getElementById('labelPermanentLine1').style.color =  (permline1=="")?'red':'green';

        document.getElementsByName('inputPermanentPincode')[0].style.border = (permanentpincode == "")? '2px red solid':'2px green solid';
        document.getElementsByName('inputPermanentPincode')[0].placeholder = (permanentpincode=="")?'this field is required':'';
        document.getElementById('labelPermanentPincode').style.color = (permanentpincode=="")?'red':'green';


        document.getElementById('country-names-permanent').style.border=(permcountry == "")? '2px red solid':'2px green solid';
        document.getElementById('labelPermanentCountry').style.color=(permcountry=="")?'red':'green';
        document.getElementById('state-names-permanent').style.border=(permstate == "")? '2px red solid':'2px green solid';
        document.getElementById('labelPermanentState').style.color=(permstate=="")?'red':'green';
        document.getElementById('inputPermanentCity').style.border=(permcity == "")? '2px red solid':'2px green solid';
        document.getElementById('labelPermanentCity').style.color=(permcity=="")?'red':'green';
    console.log(user);
    e.preventDefault();

}

function changeCountry()
 {
    getCountries();
 }
 function changeCountryPermanent() {
    getCountriesPermanent();
 }
function changeStates(statename) 
{
    getCity(statename);
}
function changeStatePermanent(state) {
    getCityPermanent(state);
}
 async function getCountries () {
    await  fetch('https://www.universal-tutorial.com/api/countries/', {
     method: 'GET',
     headers: {
         "Authorization": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjp7InVzZXJfZW1haWwiOiJkZGlrc2h5YS5hZ2Fyd2FsMjAwMkBnbWFpbC5jb20iLCJhcGlfdG9rZW4iOiJCZjc0bWU3WVp2R0pmRUlSdHRIWXUydmJCUUM2aXZ2R0VidW5GVnJxZDBKdjJHcDNUTFlLSFJkV0pSYjl2UzFBdjJJIn0sImV4cCI6MTY4OTAwNjk5M30.MuNUwGB6qIsbjsHbIMirqkrgMFbae5YEIdSFrDiIteU",
         "Accept": "application/json"
     },
 })
     .then(response => response.json())
     .then(response => {
         response.forEach(element => {
             const options= document.createElement('option');
             options.value = element.country_name;
             options.innerText = element.country_name;
             document.getElementById("country-names-present").appendChild(options);
           });
           const countryname = document.getElementById("country-names-present").value;
           document.getElementById("state-names-present").innerHTML = "";
           const option2= document.createElement('option');
           option2.value = "";
           option2.innerText = "Select States";
           document.getElementById("state-names-present").appendChild(option2);
           getStates(countryname);
     })
     .catch(err => console.error(err));

}

async function getCountriesPermanent () {
    await  fetch('https://www.universal-tutorial.com/api/countries/', {
     method: 'GET',
     headers: {
         "Authorization": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjp7InVzZXJfZW1haWwiOiJkZGlrc2h5YS5hZ2Fyd2FsMjAwMkBnbWFpbC5jb20iLCJhcGlfdG9rZW4iOiJCZjc0bWU3WVp2R0pmRUlSdHRIWXUydmJCUUM2aXZ2R0VidW5GVnJxZDBKdjJHcDNUTFlLSFJkV0pSYjl2UzFBdjJJIn0sImV4cCI6MTY4OTAwNjk5M30.MuNUwGB6qIsbjsHbIMirqkrgMFbae5YEIdSFrDiIteU",
         "Accept": "application/json"
     },
 })
     .then(response => response.json())
     .then(response => {
         response.forEach(element => {
             const options= document.createElement('option');
             options.value = element.country_name;
             options.innerText = element.country_name;
             document.getElementById("country-names-permanent").appendChild(options);
           });
           const countryname = document.getElementById("country-names-permanent").value;
           document.getElementById("state-names-permanent").innerHTML = "";
           const option2= document.createElement('option');
           option2.value = "";
           option2.innerText = "Select State";
           document.getElementById("state-names-permanent").appendChild(option2);
           getStatesPermanent(countryname);
     })
     .catch(err => console.error(err));

}


async function  getStatesPermanent(countryname) {
    await  fetch(`https://www.universal-tutorial.com/api/states/${countryname}`, {
          method: 'GET',
          headers: {
              "Authorization": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjp7InVzZXJfZW1haWwiOiJkZGlrc2h5YS5hZ2Fyd2FsMjAwMkBnbWFpbC5jb20iLCJhcGlfdG9rZW4iOiJCZjc0bWU3WVp2R0pmRUlSdHRIWXUydmJCUUM2aXZ2R0VidW5GVnJxZDBKdjJHcDNUTFlLSFJkV0pSYjl2UzFBdjJJIn0sImV4cCI6MTY4OTAwNjk5M30.MuNUwGB6qIsbjsHbIMirqkrgMFbae5YEIdSFrDiIteU",
              "Accept": "application/json"
          },
      })
          .then(response => response.json())
          .then(response => {
            
              response.forEach(element => {
                  const options= document.createElement('option');
                  options.value = element.state_name;
                  options.innerText = element.state_name;
                  document.getElementById("state-names-permanent").appendChild(options);
                });
                const statename = document.getElementById("state-names-permanent").value;
                getCityPermanent(statename);
          })
          .catch(err => console.error(err));
  }

  async function getCityPermanent(statename) {
    await  fetch(`https://www.universal-tutorial.com/api/cities/${statename}`, {
         method: 'GET',
         headers: {
             "Authorization": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjp7InVzZXJfZW1haWwiOiJkZGlrc2h5YS5hZ2Fyd2FsMjAwMkBnbWFpbC5jb20iLCJhcGlfdG9rZW4iOiJCZjc0bWU3WVp2R0pmRUlSdHRIWXUydmJCUUM2aXZ2R0VidW5GVnJxZDBKdjJHcDNUTFlLSFJkV0pSYjl2UzFBdjJJIn0sImV4cCI6MTY4OTAwNjk5M30.MuNUwGB6qIsbjsHbIMirqkrgMFbae5YEIdSFrDiIteU",
             "Accept": "application/json"
         },
     })
         .then(response => response.json())
         .then(response => {
             document.getElementById("city-names-permanent").innerHTML = "";
             response.forEach(element => {
                 const options= document.createElement('option');
                 options.value = element.city_name;
                 options.innerText = element.city_name;
                 document.getElementById("city-names-permanent").appendChild(options);
               });
         })
         .catch(err => console.error(err));
 }
async function  getStates(countryname) {
    await  fetch(`https://www.universal-tutorial.com/api/states/${countryname}`, {
          method: 'GET',
          headers: {
              "Authorization": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjp7InVzZXJfZW1haWwiOiJkZGlrc2h5YS5hZ2Fyd2FsMjAwMkBnbWFpbC5jb20iLCJhcGlfdG9rZW4iOiJCZjc0bWU3WVp2R0pmRUlSdHRIWXUydmJCUUM2aXZ2R0VidW5GVnJxZDBKdjJHcDNUTFlLSFJkV0pSYjl2UzFBdjJJIn0sImV4cCI6MTY4OTAwNjk5M30.MuNUwGB6qIsbjsHbIMirqkrgMFbae5YEIdSFrDiIteU",
              "Accept": "application/json"
          },
      })
          .then(response => response.json())
          .then(response => {
            
              response.forEach(element => {
                  const options= document.createElement('option');
                  options.value = element.state_name;
                  options.innerText = element.state_name;
                  document.getElementById("state-names-present").appendChild(options);
                });
                const statename = document.getElementById("state-names-present").value;
                getCity(statename);
          })
          .catch(err => console.error(err));
  }

  async function getCity(statename) {
    await  fetch(`https://www.universal-tutorial.com/api/cities/${statename}`, {
         method: 'GET',
         headers: {
             "Authorization": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjp7InVzZXJfZW1haWwiOiJkZGlrc2h5YS5hZ2Fyd2FsMjAwMkBnbWFpbC5jb20iLCJhcGlfdG9rZW4iOiJCZjc0bWU3WVp2R0pmRUlSdHRIWXUydmJCUUM2aXZ2R0VidW5GVnJxZDBKdjJHcDNUTFlLSFJkV0pSYjl2UzFBdjJJIn0sImV4cCI6MTY4OTAwNjk5M30.MuNUwGB6qIsbjsHbIMirqkrgMFbae5YEIdSFrDiIteU",
             "Accept": "application/json"
         },
     })
         .then(response => response.json())
         .then(response => {
             document.getElementById("city-names-present").innerHTML = "";
             response.forEach(element => {
                 const options= document.createElement('option');
                 options.value = element.city_name;
                 options.innerText = element.city_name;
                 document.getElementById("city-names-present").appendChild(options);
                
               });
         })
         .catch(err => console.error(err));
 }






