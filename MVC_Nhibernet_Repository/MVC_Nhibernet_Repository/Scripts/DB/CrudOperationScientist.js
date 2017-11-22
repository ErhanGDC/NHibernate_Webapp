(function () {
    var app = angular.module('myApp', ["ngMessages"]);
    app.controller('CtrlSaveScientist', function ($scope, $http) {

        $scope.scientistList = [];
        $scope.inventionList = [];


        $scope.init = function () {
            getScientistList();
            getInventionList();
        }; //Get info

        var getScientistList = function () {
            $http.get("/Scientist/GetScientists").then(function(response) {
                angular.forEach(response.data,
                    function(value, index) {
                        $scope.scientistList.push({"ID":value.ID,"FirstName":value.FirstName,"LastName":value.LastName,"Title":value.Title});
                    });
            });
        };
        var getInventionList = function () {
            $http.get("/Scientist/GetInventions").then(function(response) {
                angular.forEach(response.data,
                    function(value, index) {
                        $scope.inventionList.push({ "InventionID": value.InventionID, "Description": value.Description,"ScientistID":value.ScientistID});
                    });
            });
        };

        $scope.send = function () {
            debugger;
            $http.post('/Scientist/Save', $scope.Scientists).then(function (response) {
                $scope.Scientists = {};
                alert("Added Successfully");
                window.location.load();
            });
        };  //Save Scientist

        $scope.remove = function () {
            var answer = confirm("Are you sure to delete the regarding row ?");
            if (answer == true) {
                angular.forEach($scope.scientistList, function (selected) {
                    if (selected.selected) {
                        $http.post('/Scientist/DeleteScientist', { id: selected.ID }).then(function (response) {
                            $scope.scientistList = {};
                        });
                        alert("Removed Successfully");
                    }
                    window.location.reload();
                });
            } else {

            }
        }; // Remove Scientist

        $scope.update = function () {
            var answer = confirm("Are you sure to update the regarding row ?");
            if (answer == true) {
                angular.forEach($scope.scientistList, function (selected) {
                    if (selected.selected) {
                        $http.post('/Scientist/UpdateScientist', selected).then(function (response) {
                            $scope.scientistList = {};
                            alert("Updated Successfully");
                        });
                    }
                    window.location.reload();
                });
            } else {

            }
        }; //Update Scientist

        $scope.checkAll = function () {
            if (!$scope.selectedAll) {
                $scope.selectedAll = true;
            } else {
                $scope.selectedAll = false;
            }
            angular.forEach($scope.scientistList, function (scientistDetail) {
                scientistDetail.selected = $scope.selectedAll;
            });
        }; //Check the selected row

    });
})();
