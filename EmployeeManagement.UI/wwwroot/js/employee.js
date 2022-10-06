$(document).ready(function () {
    bindEvents();
    hideEmployeeDetailCard();
});
var employeeUrl = "https://localhost:44383/";
function bindEvents() {
    $(".employeeDetails").on("click", function (event) {
        var employeeId = event.currentTarget.getAttribute("data-id");

        $.ajax({
            url: employeeUrl + 'api/internal/employee/' + employeeId,
            type: 'GET',
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                var newEmployeeCard = `<div class="card">
                                          <h1>${result.name}</h1>
                                         <b>Id :</b> <p>${result.id}</p>
                                         <b>Department:</b><p>${result.department}</p>
                                         <b>Age:</b><p>${result.age}</p>
                                         <b>Address:</b><p>${result.address}</p>
                                        </div>`

                $("#EmployeeCard").html(newEmployeeCard);
                showEmployeeDetailCard();
            },
            error: function (error) {
                console.log(error);
            }
        });
    });

    $(".employeeDelete").on("click", function (event) {
        var employeeId = event.currentTarget.getAttribute("data-id");
        var conformation = confirm("Are you sure you want to remove item ?")
        if (conformation) {
            $.ajax({
                url: employeeUrl + 'api/internal/employee/delete/' + employeeId,
                type: 'DELETE',
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    location.reload();
                },
                error: function (error) {
                    console.log(error);
                }
            });
            alert("Successfully Deleted");
        }
        else {
            alert("Delete Action Cancelled");
        }
    });

    $("#createform").submit(function (event) {
        

        var employeeDetailedViewModel = {};

        employeeDetailedViewModel.Name = $("#name").val();
        employeeDetailedViewModel.Department = $("#department").val();
        employeeDetailedViewModel.Age = Number($("#age").val());
        employeeDetailedViewModel.Address = $("#address").val();

        var data = JSON.stringify(employeeDetailedViewModel);

        $.ajax({
            url: employeeUrl + 'api/internal/employee/insert-employees',
            type: 'POST',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: data,
            async: false,
            success: function (result) {

                location.reload();
                
            },
            error: function (error) {
                console.log(error);
            }
        });
        
    });




    $(".employeeEdit").on("click", function (event) {
        console.log("clicked");
        var employeeId = event.currentTarget.getAttribute("data-id");

        $.ajax({
            url: employeeUrl+'api/internal/employee/' + employeeId,
            type: 'GET',
            contentType: "application/json; charset=utf-8",
            success: function (result) {



                $("#updateid").val(result.id)
                $("#updatename").val(result.name)
                $("#updatedepartment").val(result.department)
                $("#updateage").val(result.age)
                $("#updateaddress").val(result.address)
            },
            error: function (error) {
                console.log(error);
            }
        });
        $("#updateform").submit(function (event) {
            console.log("clicked");


            var employeeUpdate = {};
            employeeUpdate.Id = Number($("#updateid").val());
            employeeUpdate.Name = $("#updatename").val();
            employeeUpdate.Department = $("#updatedepartment").val();
            employeeUpdate.Age = Number($("#updateage").val());
            employeeUpdate.Address = $("#updateaddress").val();

            var data = JSON.stringify(employeeUpdate);


            $.ajax({
                url: employeeUrl + 'api/internal/employee/update-employees',
                type: 'PUT',
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                data: data,
                async: false,
                success: function (result) {

                    location.reload();
                    
                },
                error: function (error) {
                    console.log(error);
                }
            });
            



        });
        


    });

}


function hideEmployeeDetailCard() {
    $("#EmployeeCard").hide();
}

function showEmployeeDetailCard() {
    $("#EmployeeCard").show();
}