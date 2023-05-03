    //$(function() {
    //    $('.roles-wrapper .edit-btn').on('click', function () {
    //        // Get the user ID from the data attribute
    //        var userId = $(this).closest('.roles-wrapper').data('user-id');
    //        // Hide the role names and show the role select
    //        $(this).closest('.role-names').hide();
    //        $(this).closest('.roles-wrapper').find('.role-select').show();
    //    });

    //$('.roles-wrapper .cancel-btn').on('click', function() {
    //        // Get the user ID from the data attribute
    //        var userId = $(this).closest('.roles-wrapper').data('user-id');
    //// Show the role names and hide the role select
    //$(this).closest('.role-select').hide();
    //$(this).closest('.roles-wrapper').find('.role-names').show();
    //    });

    //$('.roles-wrapper .save-btn').on('click', function() {
    //        // Get the user ID from the data attribute
    //        var userId = $(this).closest('.roles-wrapper').data('user-id');
    //// Get the selected role
    //var role = $(this).closest('.role-select').find('select[name="roles"]').val();
    //// Send an AJAX request to update the user's role
    //$.ajax({
    //    url: '/users/update-role',
    //method: 'POST',
    //data: {userId: userId, role: role },
    //success: function() {
    //    // Show a success message or refresh the page
    //},
    //error: function() {
    //    // Show an error message or handle the error
    //}
    //        });
    //    });
    //});


$(function () {
    $('.roles-wrapper .edit-btn').on('click', function () {
        // Hide the role names and show the role select
        $(this).closest('.role-names').hide();
        $(this).closest('.roles-wrapper').find('.role-select').show();
    });

    $('.roles-wrapper .cancel-btn').on('click', function () {
        // Show the role names and hide the role select
        $(this).closest('.role-select').hide();
        $(this).closest('.roles-wrapper').find('.role-names').show();
    });

    $('.roles-wrapper .save-btn').on('click', function () {
        // Get the selected role
        var role = $(this).closest('.role-select').find('select[name="roles"]').val();
        // Update the user's role using a form submit
        $(this).closest('form').append('<input type="hidden" name="role" value="' + role + '">');
        $(this).closest('form').submit();
    });
});