function ConfirmDelete() {
   
    if (confirm("Are you sure you want to delete the user !")) {
        return true;
    } else {
        return false;
    }
}