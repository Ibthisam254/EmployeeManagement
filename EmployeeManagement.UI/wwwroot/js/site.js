// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//$(document).ready(function () {
//    bindEventsnew();
    
//});

//function bindEventsnew() {
//    $("#createform").submit(function (event) {
//        console.log("click");

//        var employeeDetailedViewModel = {};

//        employeeDetailedViewModel.Name = $("#name").val();
//        employeeDetailedViewModel.Department = $("#department").val();
//        employeeDetailedViewModel.Age = Number($("#age").val());
//        employeeDetailedViewModel.Address = $("#address").val();

//        var data = JSON.stringify(employeeDetailedViewModel);

//        $.ajax({
//            url: 'https://localhost:44383/api/internal/employee/insert-employees',
//            type: 'POST',
//            dataType: 'json',
//            contentType: "application/json; charset=utf-8",
//            data: data,
//            success: function (result) {

//                location.reload();
//            },
//            error: function (error) {
//                console.log(error);
//            }
//        });
//    });
//}