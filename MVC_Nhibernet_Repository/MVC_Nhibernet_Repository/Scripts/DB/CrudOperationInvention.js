(function () {
    var app = angular.module('myApp', ["ngMessages"]);

    app.controller('CtrlSaveInvention', function ($scope, $http) {

        $scope.ScientistList = [];
        $scope.InventionList = [];

        $scope.init = function () {
            GetScientistList();
            GetInventionList();
        };
        var GetScientistList = function () {
            $http.get("/Home/GetScientists")
                .then(function (response) {
                    console.log(response);
                    angular.forEach(response.data, function (value, index) {
                        $scope.ScientistList.push({ "ID": value.ID, "FirstName": value.FirstName });
                    });
                });
        };
        var GetInventionList = function () {
            $http.get("/Home/GetInventions")
                .then(function (response) {
                    console.log(response);
                    angular.forEach(response.data, function (value, index) {
                        $scope.InventionList.push({ "InventionID": value.InventionID, "Description": value.Description, "ScientistID": value.ScientistID });
                    });
                });
        };

        $scope.send = function () {
            $http.post('/Home/Contact', $scope.Invention).then(function (response) {
                $scope.Invention = {};
                alert("Added Successfully");
                window.location.reload();
            });
        }; //Save operation

        $scope.remove = function () {
            var answer = confirm("Are you sure to delete the regarding row ?");
            if (answer == true) {
                angular.forEach($scope.InventionList, function (selected) {
                    if (selected.selected) {
                        $http.post('/Home/DeleteInvention', { id: selected.InventionID }).then(function (response) {
                            $scope.InventionList = {};
                        });
                        alert("Removed Successfully");
                    }
                    window.location.reload();
                });
                $scope.inventionDetail = newDataList;
            } else {

            }
        };

        $scope.update = function () {
            var answer = confirm("Are you sure to update the regarding row ?");
            if (answer==true) {
                angular.forEach($scope.InventionList, function (selected) {
                    if (selected.selected) {
                        $http.post('/Home/UpdateInvention', selected).then(function (response) {
                            $scope.InventionList = {};
                            alert("Updated Successfully");
                            window.location.reload();
                        });
                    }
                });

            } else {

            }
        };

        $scope.checkAll = function () {
            if (!$scope.selectedAll) {
                $scope.selectedAll = true;
            } else {
                $scope.selectedAll = false;
            }
            angular.forEach($scope.InventionList, function (inventionDetail) {
                inventionDetail.selected = $scope.selectedAll;
            });
        };

    });
})();


