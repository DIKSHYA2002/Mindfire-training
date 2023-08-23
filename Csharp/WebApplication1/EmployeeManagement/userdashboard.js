
$(document).ready(function () {

    detailBtn.style.backgroundColor = "white";
    detailBtn.style.color = "black";
    userDetails.style.display = "block";
    $("#detailBtn").click(function (e) {
        e.preventDefault();
        console.log("selected index is details tab")
        var i, tabcontent, tablinks;
        tablinks = document.getElementsByClassName("tablink");
        for (i = 0; i < tablinks.length; i++) {
            tablinks[i].style.backgroundColor = "black";
            tablinks[i].style.color = "white";
        }
        tabcontent = document.getElementsByClassName("tabcontent");
        for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].style.display = "none";
        }
        detailBtn.style.backgroundColor = "white";
        detailBtn.style.color = "black";
      
        userDetails.style.display = "block";
    
    });
    
    $("#noteBtn").click(function (e) {
        e.preventDefault();
        console.log("selected index is note tab")
        var i, tabcontent, tablinks;
        tablinks = document.getElementsByClassName("tablink");
        for (i = 0; i < tablinks.length; i++) {
            tablinks[i].style.backgroundColor = "black";
            tablinks[i].style.color = "white";
        }

        tabcontent = document.getElementsByClassName("tabcontent");
        for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].style.display = "none";
        }
        noteBtn.style.backgroundColor = "white";
        noteBtn.style.color = "black";
        tablinks = document.getElementsByClassName("tablink");
        userNotes.style.display = "block";
    });
    
    $("#fileBtn").click(function (e) {
        e.preventDefault();
        console.log("selected index is files tab")
        var i, tabcontent, tablinks;
        tablinks = document.getElementsByClassName("tablink");
        for (i = 0; i < tablinks.length; i++) {
            tablinks[i].style.backgroundColor = "black";
            tablinks[i].style.color = "white";
        }
        tabcontent = document.getElementsByClassName("tabcontent");
        for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].style.display = "none";
        }
        fileBtn.style.backgroundColor = "white";
        fileBtn.style.color = "black";
        tablinks = document.getElementsByClassName("tablink");
        userFiles.style.display = "block";
    })
    
   




})

//function openPage(pageName, elmnt, color) {
//    // Hide all elements with class="tabcontent" by default */
//   
//    

//}
