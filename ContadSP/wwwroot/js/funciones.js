
function showSweetAlert(title, message, type) {
    Swal.fire({
        title: title,
        text: message,
        icon: type
    })
}


function showSweetAlertConfirm(title, message, type) {
    return Swal.fire({
        title: title,
        text: message,
        icon: type,
        showCancelButton: true,
        confirmButtonColor: "btn btn-success",
        cancelButtonColor: "btn btn-danger",
        confirmButtonText: "Confirmar",
        cancelButtonText: "Cancelar"
    }).then((result) => {
        return result.isConfirmed;
    });
}

