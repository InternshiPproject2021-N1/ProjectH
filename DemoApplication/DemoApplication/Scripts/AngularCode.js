var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {
    debugger;
/*    $scope.InsertData = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.Employe = {};
            $scope.Employe.EmpName = $scope.EmpName;
            $scope.Employe.EmpAddress = $scope.EmpAddress;
            $scope.Employe.EmpEmail = $scope.EmpEmail;
            $http({
                method: "post",
                url: "http://localhost:39209/Employee/Insert_Employee",
                datatype: "json",
                data: JSON.stringify($scope.Employe)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.EmpName = "";
                $scope.EmpAddress = "";
                $scope.EmpEmail = "";
            })
        } else {
            $scope.Employe = {};
            $scope.Employe.EmpName = $scope.EmpName;
            $scope.Employe.EmpAddress = $scope.EmpAddress;
            $scope.Employe.EmpEmail = $scope.EmpEmail;
            $scope.Employe.EmpId = document.getElementById("EmpID_").value;
            $http({
                method: "post",
                url: "http://localhost:39209/Employee/Update_Employee",
                datatype: "json",
                data: JSON.stringify($scope.Employe)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.EmpName = "";
                $scope.EmpCity = "";
                $scope.EmpAge = "";
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Employee";
            })
        }
    }*/
    $scope.GetAllData = function () {
        $http({
            method: "get",
            url: "https://localhost:44342/Employees/Get_AllEmployee",
        }).then(function (response) {
            $scope.employees = response.data;
        }, function () {
            alert("Error Occur");
        })
    };
/*    $scope.DeleteEmp = function (Emp) {
        $http({
            method: "post",
            url: "http://localhost:39209/Employee/Delete_Employee",
            datatype: "json",
            data: JSON.stringify(Emp)
        }).then(function (response) {
            alert(response.data);
            $scope.GetAllData();
        })
    };
    $scope.UpdateEmp = function (Emp) {
        document.getElementById("EmpID_").value = Emp.EmpId;
        $scope.EmpName = Emp.EmpName;
        $scope.EmpCity = Emp.EmpAddress;
        $scope.EmpAge = Emp.EmpEmail;
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").style.backgroundColor = "Yellow";
        document.getElementById("spn").innerHTML = "Update Employee Information";
    }*/
})