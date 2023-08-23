// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//import $ from "~/lib/jquery/dist/jquery.min.js"
function login() {
    var Student = {
        Email: 'rutvik@gmail.com',
        Password: '123',
    };
    $.ajax({
        type: "POST",
        url: "/Home/Login",
        data: JSON.stringify(Student),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            alert(data.message);
        },
        error: function () {
            alert("Error occured!!")
        }
    });
}