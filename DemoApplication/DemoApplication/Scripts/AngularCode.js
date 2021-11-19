var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {
    $scope.InsertData = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.employes = {};
            $scope.employes.Name = $scope.EmpName;
            $scope.employes.Address = $scope.EmpAddress;
            $scope.employes.Email = $scope.EmpEmail;
            $scope.employes.Age = $scope.EmpAge;
            $scope.employes.Status = $scope.EmpStatus;
            $scope.employes.IsActive = $scope.EmpIsActive;
            $scope.employes.Rank = $scope.EmpRank;
            $scope.employes.Description = $scope.EmpDescription;
            $scope.employes.Create = $scope.EmpCreate;
            $scope.employes.CreatedBy = $scope.EmpCreatedBy;
            $http({
                method: "post",
                url: "https://localhost:44324/Employees/Insert_Employee",
                datatype: "json",
                data: JSON.stringify($scope.Employees)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.EmpName = "";
                $scope.EmpAddress = "";
                $scope.EmpEmail = "";
                $scope.EmpAge = "";
                $scope.EmpStatus = "";
                $scope.EmpIsActive = "";
                $scope.EmpRank = "";
                $scope.EmpDescription = "";
                $scope.EmpCreate = "";
                $scope.EmpCreatedBy = "";

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
    }
    $scope.GetAllData = function () {
        $http({
            method: "get",
            url: "https://localhost:44342/Employees/Get_AllEmployee",
        }).then(function (response) {
            $scope.employees = response.data;
        }, function (e) {
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