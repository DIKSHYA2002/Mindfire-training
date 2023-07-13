const user = JSON.parse(document.cookie);
console.log(user)
const thumbnail = localStorage.getItem('user-image');

if (thumbnail) {
    $('#ImageResult').attr('src',thumbnail);
    } 
else 
{
  $('#ImageResult').attr('src','https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png');
}
let Titles = Object.keys(user);
$('#modalContent p.second').html( `<div id="results"></div>`);
Titles.forEach(element => {
   if(element== "present-Address")
   {
    $('#results').append(`<h3>Present Address:</h3>`);
    let newt = Object.keys(user['present-Address'])
    newt.forEach(element=>{
      $('#modalContent p.second #results').append( `<div class="input-field-group"><div class="input-field">${element}:</div><div class="input-field-answer">${user['present-Address'][element]}</div></div>`);
    }
    )
   }
 else if(element== "permanent-Address")
   {
    $('#modalContent p.second #results').append(`<h3>Permanent Address:</h3>`);
    let newt = Object.keys(user['permanent-Address']);
    newt.forEach(element=> 
      $('#modalContent p.second #results').append(`<div class="input-field-group"><div class="input-field">${element}:</div><div class="input-field-answer">${ user['permanent-Address'][element]}</div></div>` ))
   }
     else
       $('#modalContent p.second #results').append(`<div class="input-field-group"><div class="input-field">${element}:</div><div class="input-field-answer">${user[element]}</div></div>`);
      });