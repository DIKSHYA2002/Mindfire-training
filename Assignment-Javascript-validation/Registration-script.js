// API_TOKEN
let BearerToken = "";
getApiKey();
//PICTURE_PREVIEW
function previewFile() {
  var preview = document.querySelector('img');
  var file = document.querySelector('input[type=file]').files[0];
  var reader = new FileReader();
  reader.onloadend = function () {
    preview.src = reader.result;
  }
  if (file) {
    reader.readAsDataURL(file);
  } else {
    preview.src = "";
  }
}
//ONCHANGE FUNCTION FROM  PRESENT TO PERMANENT
function presenttopermanent(value) {
  return function () {
    if (value.checked == true) {
      const line1 = document.getElementById("inputPresentLine1").value;
      const line2 = document.getElementById("inputPresentLine2").value;
      const present_country = document.getElementById("countryNamesPresent").value;
      const present_state = document.getElementById("stateNamesPresent").value;
      const present_city = document.getElementById("inputCityPresent").value;
      const pincode = document.getElementById("inputPresentPincode").value;
      document.getElementById('inputPermanentLine1').value = line1;
      document.getElementById('inputPermanentLine2').value = line2;
      document.getElementsByName('inputPermanentPincode')[0].value = pincode;

      const options = document.createElement('option');
      options.value = present_country;
      options.innerText = present_country;
      document.getElementById('countryNamesPermanent').appendChild(options);
      document.getElementById('countryNamesPermanent').value = present_country;
      const options2 = document.createElement('option');
      options2.value = present_state;
      options2.innerText = present_state;
      document.getElementById('stateNamesPermanent').appendChild(options2);
      document.getElementById('stateNamesPermanent').value = present_state;
      document.getElementById('inputPermanentCity').value = present_city;
      document.getElementById('inputPermanentLine1').disabled = true;
      document.getElementById('inputPermanentLine2').disabled = true;
      document.getElementById('inputPermanentPincode').disabled = true;
      document.getElementById('countryNamesPermanent').disabled = true;
      document.getElementById('stateNamesPermanent').disabled = true;
      document.getElementById('inputPermanentCity').disabled = true;
    }
    else {

      document.getElementById('inputPermanentLine1').disabled = false;
      document.getElementById('inputPermanentLine2').disabled = false;
      document.getElementById('inputPermanentPincode').disabled = false;
      document.getElementById('countryNamesPermanent').disabled = false;
      document.getElementById('stateNamesPermanent').disabled = false;
      document.getElementById('inputPermanentCity').disabled = false;
    }
  }


}
//GET_API FUNCTION
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
//FORM_SUBMIT
document.querySelector('form').addEventListener('submit', formsubmit);
async function formsubmit(e) {
  let error = 0;
  const onlyInputs = document.querySelectorAll('#registrationForm input');
  for (let index = 0; index < onlyInputs.length; index++) {

    if (onlyInputs[index].type == 'text' || onlyInputs[index].type == "date" || onlyInputs[index].type == "number" || onlyInputs[index].type == "email") {
      if (onlyInputs[index].value === "") {
        error=1;
        let id = onlyInputs[index].id;
        document.getElementById(id).style.border = '2px red solid';
       
      }
      else {
        let id = onlyInputs[index].id;
        document.getElementById(id).style.border = '2px green solid';
      }
    }
  }
  const onlySelects = document.querySelectorAll('select');
  for (let index = 0; index < onlySelects.length; index++) {
    if (onlySelects[index].value === "") {
    error=1;
      let id = onlySelects[index].id;
      document.getElementById(id).style.border = '2px red solid';
    }
    else {
      let id = onlySelects[index].id;
      document.getElementById(id).style.border = '2px green solid';
    }
  }
  var modal = document.getElementById("myModal");
  var btn = document.getElementById("btn-submit");
  var span = document.getElementsByClassName("close")[0];
  showModal();
   function showModal () {
    if (error == 1) 
    {
      modal.style.display = "block";
      document.querySelector('#modalContent p').innerHTML = '<h1 class="errormessage"> Please Complete the form</h1>';
    }
    else if(error==0){
      const user = {
        FirstName: inputFirstName.value,
        LastName: inputLastName.value,
        Email: inputEmail.value,
        DOB: inputDateOfBirth.value,
        Phone: inputPhone.value,
        BloodGroup: inputDropdownBloodGroup.value,
        hobbies: inputHobbies.value,
        Subscribed: subscribe.checked,
      }
      const presentAddress = {
        present_country: countryNamesPresent.value,
        present_line1: inputPresentLine1.value,
        present_line2: inputPresentLine2.value,
        present_state: stateNamesPresent.value,
        present_city: inputCityPresent.value,
        present_pincode: inputPresentPincode.value
      }
      const permanentAddress = {
        permanent_country: countryNamesPermanent.value,
        permanent_line1: inputPermanentLine1.value,
        permanent_line2: inputPermanentLine2.value,
        permanent_state: stateNamesPermanent.value,
        permanent_city: inputPermanentCity.value,
        permanent_pincode: inputPermanentPincode.value
      }
      modal.style.display = "block";
      document.querySelector('#modalContent p').innerHTML = '<h1 id="Heading-modal">Form Submitted Succesfully!</h1>'
      let Titles = Object.keys(user);
      let TitlesAddress = Object.keys(presentAddress);
      let TitlesAddress2 = Object.keys(permanentAddress);
      document.querySelector('#modalContent p').innerHTML +=`<div id="results"></div>`
      Titles.forEach(element => {
        document.querySelector('#modalContent p #results').innerHTML += `<div class="input-field-group"><div class="input-field">${element}:</div><div class="input-field-answer">${user[element]}</div></div>`
      });
      document.querySelector('#modalContent p #results').innerHTML +=`<h3>Present Address:</h3>`
      TitlesAddress.forEach(element => {
        document.querySelector('#modalContent p #results').innerHTML += `<div class="input-field-group"><div class="input-field">${element}:</div><div class="input-field-answer">${presentAddress[element]}</div></div>`
      });
      document.querySelector('#modalContent p #results').innerHTML +=`<h3>Permanent Address:</h3>`
      TitlesAddress2.forEach(element => {
        document.querySelector('#modalContent p #results').innerHTML += `<div class="input-field-group"><div class="input-field">${element}:</div><div class="input-field-answer">${permanentAddress[element]}</div></div>`
      });
      console.log("no error");
    }
  }
  span.onclick = function () {
    modal.style.display = "none";
  }
  window.onclick = function (event) {
    if (event.target == modal) {
      modal.style.display = "none";
    }
  }

  // console.log(user);
  e.preventDefault();

}
//GET_COUNTRIES_API_CALL
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
          const options = document.createElement('option');
          options.value = element.country_name;
          options.innerText = element.country_name;
          obj.appendChild(options);
        });
      })
      .catch(err => console.error(err));

  }


}
//GET_STATES_API_CALL
function getStates(obj1, obj2) {
  return async () => {
    const country = obj1.value;
    await fetch(`https://www.universal-tutorial.com/api/states/${country}`, {
      method: 'GET',
      headers: {
        "Authorization": `Bearer ${BearerToken}`,
      },
    })
      .then(response => response.json())
      .then(response => {

        response.forEach(element => {
          const options = document.createElement('option');
          options.value = element.state_name;
          options.innerText = element.state_name;
          obj2.appendChild(options);
        });

      })
      .catch(err => console.error(err));
  }
}

//GET_CITY_API CALL
function getCity(statename, city) {
  return async () => {
    if(statename.value !== "")
    await fetch(`https://www.universal-tutorial.com/api/cities/${statename.value}`, {
      method: 'GET',
      headers: {
        "Authorization": `Bearer ${BearerToken}`,
      },
    })
      .then(response => response.json())
      .then(response => {
        response.forEach(element => {
          const options = document.createElement('option');
          options.value = element.city_name;
          options.innerText = element.city_name;
          city.appendChild(options);
        });
      })
      .catch(err => console.error(err));
  }

}

//CHANGE INPUT_COLOUR AND VALIDATION
function changeInput(obj) {
  return function () {
    obj.style.border = (obj.value == "") ? '2px red solid' : '2px green solid';
    obj.placeholder = (obj.value == '' && obj.type == 'text') ? 'this field is required' : '';
  }
};

//CHANGE WHENEVER SAME AS FIELD IS SELECTED (PRESENT TO PERMANENT)
function changeLine(obj2, obj) {
  return function () {
    if (document.getElementById('sameas').checked) {
      obj.disabled = false;
      obj.value = obj2.value;
      obj.disabled = true;
    }
  }
}
//ITERATTING ALL THE INPUT FIELD AND VALIDATING
const inputfieldselectors = document.querySelectorAll('.validateOnChange');
for (let index = 0; index < inputfieldselectors.length; index++) 
{
  inputfieldselectors[index].addEventListener('change' , changeInput( inputfieldselectors[index]))
}

const  selectfields = document.querySelectorAll('select');
for (let index = 0; index < selectfields.length; index++) 
{
  selectfields[index].addEventListener('change' , changeInput( selectfields[index]))
}


//ONCLICK AND ONCHANGE EVENTS
document.getElementById('inputImage').addEventListener('change', previewFile);
document.getElementById('inputPresentLine1').addEventListener('change', changeLine(inputPresentLine1, inputPermanentLine1));
document.getElementById('inputPresentLine2').addEventListener('change', changeLine(inputPresentLine2, inputPermanentLine2));
document.getElementById('inputPresentPincode').addEventListener('change', changeLine(inputPresentPincode, inputPermanentPincode));
document.getElementById('inputCityPresent').addEventListener('change', changeLine(inputCityPresent, inputPermanentCity));
document.getElementById('countryNamesPresent').addEventListener('click', getCountries(countryNamesPresent));
document.getElementById('countryNamesPermanent').addEventListener('click', getCountries(countryNamesPermanent));
document.getElementById('stateNamesPresent').addEventListener('click', getStates(countryNamesPresent, stateNamesPresent))
document.getElementById('stateNamesPermanent').addEventListener('click', getStates(countryNamesPermanent, stateNamesPermanent))
document.getElementById('inputCityPresent').addEventListener('change', getCity(stateNamesPresent, citynamespresentDatalist))
document.getElementById('inputPermanentCity').addEventListener('change', getCity(stateNamesPermanent, citynamespermanentDatalist))
document.getElementById('sameas').addEventListener('change', presenttopermanent(sameas));