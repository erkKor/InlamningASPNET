
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



// MODAL
//function showUserInfoModal(firstName, lastName, email, phonenumber, adress, city, postalcode, company) {
//    $('#firstName').text(firstName);
//    $('#lastName').text(lastName);
//    $('#email').text(email);
//    $('#phonenumber').text(phonenumber);
//    $('#adress').text(adress);
//    $('#city').text(city);
//    $('#postalcode').text(postalcode);
//    $('#company').text(company);
//    // Set more fields here
//    $('#myModal').modal('show');
//}


//$(document).ready(function () {
//    $('.user-row').click(function () {
//        var firstName = $(this).data('firstname');
//        var lastName = $(this).data('lastname');
//        var email = $(this).data('email');
//        var phonenumber = $(this).data('phonenumber');
//        var adress = $(this).data('adress');
//        var city = $(this).data('city');
//        var postalcode = $(this).data('postalcode');
//        var company = $(this).data('company');
//        showUserInfoModal(firstName, lastName, email, phonenumber, adress, city, postalcode, company);

//        $('#myModal').modal('show');
//    });
//});

//$('#myModal').on('shown.bs.modal', function (e) {
//    var firstName = $(e.relatedTarget).data('firstname');
//    $('#firstName').text(firstName);
//});






document.getElementById("defaultBtn").click();

function openCity(evt, cityName) {
    // Declare all variables
    var i, tabcontent, tablinks;

    // Get all elements with class="tabcontent" and hide them
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    // Get all elements with class="tablinks" and remove the class "active"
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }

    // Show the current tab, and add an "active" class to the button that opened the tab
    document.getElementById(cityName).style.display = "block";
    evt.currentTarget.className += " active";
}



