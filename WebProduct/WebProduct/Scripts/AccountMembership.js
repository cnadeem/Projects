$(document).ready(function () {

    //Close the bootstrap alert
    $('#linkClose').click(function () {
        $('#divError').hide('fade');
    });

    // Save the new user details
    $('#btnRegister').click(function () {
        $.ajax({
            url: 'http://localhost:59961/api/Account/Register',
            method: 'POST',
            data: {
                email: $('#txtEmail').val(),
                password: $('#txtPassword').val(),
                confirmPassword: $('#txtConfirmPassword').val()
            },
            success: function () {
                $('#successModal').modal('show');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown)
            {
                $('#divErrorText').text(XMLHttpRequest.responseText);
                alert(textStatus);
                alert(errorThrown);
                $('#divError').show('fade');
            }
        });
    });

    $('#linkClose').click(function () {
        $('#divError').hide('fade');
    });

    $('#btnLogin').click(function () {
        $.ajax({
            // Post username, password & the grant type to /token
            url: 'http://localhost:59961/token',
            crossDomain: true,
            headers:{
                "X-Requested-With":"XMLHttpRequest"
            },
            method: 'POST',
            contentType: 'application/json',
            data: {
                username: $('#txtUsername').val(),
                password: $('#txtPassword').val(),
                grant_type: 'password'
            },
            // When the request completes successfully, save the
            // access token in the browser session storage and
            // redirect the user to Data.html page. We do not have
            // this page yet. So please add it to the
            // EmployeeService project before running it
            success: function (response) {
                sessionStorage.setItem("accessToken", response.access_token);
                window.location.href = "Data.html";
            },
            // Display errors if any in the Bootstrap alert <div>
            error: function (jqXHR) {
                $('#divErrorText').text(jqXHR.responseText);
                $('#divError').show('fade');
            }
        });
    });
});