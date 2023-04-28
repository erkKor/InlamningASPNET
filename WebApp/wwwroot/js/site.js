$(document).ready(function () {
    $('#myForm').submit(function (event) {
        event.preventDefault(); // prevent default form submission
        // make AJAX request to submit form data
        $.ajax({
            url: '/my-controller/my-action', // replace with your controller and action
            type: 'POST',
            data: $('#myForm').serialize(), // serialize form data
            success: function (response) {
                // show the div on success
                $('#myDiv').show();
            },
            error: function () {
                // handle error
            }
        });
    });
});
