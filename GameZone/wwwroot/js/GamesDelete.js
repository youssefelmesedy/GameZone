//$(document).ready(function () {
//    $('.js-delete').on('click', function () {
//        var btn = $(this);

//        const swal = Swal.mixin({
//            customClass: {
//                confirmButton: "btn btn-success",
//                cancelButton: "btn btn-danger"
//            },
//            buttonsStyling: false
//        });
//        swal.fire({
//            title: "Are you sure?",
//            text: "You won't be able to revert this!",
//            icon: "warning",
//            showCancelButton: true,
//            confirmButtonText: "Yes, delete it!",
//            cancelButtonText: "No, cancel!",
//            reverseButtons: true
//        }).then((result) => {
//            if (result.isConfirmed) {
//                swalWithBootstrapButtons.fire({
//                    title: "Deleted!",
//                    text: "Your file has been deleted.",
//                    icon: "success"
//                });
//            } else if (
//                /* Read more about handling dismissals below */
//                result.dismiss === Swal.DismissReason.cancel
//            ) {
//                swalWithBootstrapButtons.fire({
//                    title: "Cancelled",
//                    text: "Your imaginary file is safe :)",
//                    icon: "error"
//                });
//            }
//        });
//        //$.ajax({
//        //    url: `/Games/Delete/${btn.data('id')}`,
//        //    method: 'Delete',
//        //    success: function () {
//        //        alert('Success')
//        //    },
//        //    error: function () {
//        //        alert('error')
//        //    }
//        //});
//    });
//});
$(document).ready(function () {
    $('.js-delete').on('click', function () {
        var btn = $(this);

        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-success',
                cancelButton: 'btn btn-danger'
            },
            buttonsStyling: false
        });

        swalWithBootstrapButtons.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, delete it!',
            cancelButtonText: 'No, cancel!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Games/Delete/${btn.data('id')}`,
                    method: 'DELETE',
                    success: function () {
                        swalWithBootstrapButtons.fire(
                            'Deleted!',
                            'Your file has been deleted.',
                            'success'
                        );
                        // يمكنك تحديث الجدول أو الصفحة هنا لإزالة العنصر المحذوف
                        btn.parents('tr').fadeOut();
                    },
                    error: function () {
                        swalWithBootstrapButtons.fire(
                            'Error!',
                            'There was an issue deleting the item.',
                            'error'
                        );
                    }
                });
            } else if (
                result.dismiss === Swal.DismissReason.cancel
            ) {
                swalWithBootstrapButtons.fire(
                    'Cancelled',
                    'Don Cancelleted Delete game :)',
                    'error'
                );
            }
        });
    });
});

