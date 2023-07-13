const user = JSON.parse(localStorage.getItem('personalD'));
const thumbnail = localStorage.getItem('user-image');
const previewImage = document.getElementById('ImageResult');
if (thumbnail) {
    previewImage.setAttribute('src', thumbnail);
} else {
    previewImage.setAttribute('src', 'https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png');
}
let Titles = Object.keys(user);
document.querySelector('#modalContent p.second').innerHTML += `<div id="results"></div>`
Titles.forEach(element => {
   if(element== "present-Address")
   {
    document.querySelector('#modalContent p.second #results').innerHTML +=`<h3>Present Address:</h3>`
    let newt = Object.keys(user['present-Address'])
    newt.forEach(element=>{
        document.querySelector('#modalContent p.second #results').innerHTML += `<div class="input-field-group"><div class="input-field">${element}:</div><div class="input-field-answer">${user['present-Address'][element]}</div></div>`
    }
    )
   }
 else  if(element== "permanent-Address")
   {
    document.querySelector('#modalContent p.second #results').innerHTML +=`<h3>Permanent Address:</h3>`
    let newt = Object.keys(user['permanent-Address'])
    newt.forEach(element=> document.querySelector('#modalContent p.second #results').innerHTML += `<div class="input-field-group"><div class="input-field">${element}:</div><div class="input-field-answer">${ user['permanent-Address'][element]}</div></div>` )
   }
     else  
        document.querySelector('#modalContent p.second #results').innerHTML += `<div class="input-field-group"><div class="input-field">${element}:</div><div class="input-field-answer">${user[element]}</div></div>`
});