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
            $http.get("/Scientist/GetScientists").then(function (response) {
                angular.forEach(response.data,
                    function (value, index) {
                        $scope.scientistList.push({ "ID": value.ID, "FirstName": value.FirstName, "LastName": value.LastName, "Title": value.Title });
                    });
            });
        };
        var getInventionList = function () {
            $http.get("/Scientist/GetInventions").then(function (response) {
                angular.forEach(response.data,
                    function (value, index) {
                        $scope.inventionList.push({ "InventionID": value.InventionID, "Description": value.Description, "ScientistID": value.ScientistID });
                    });
            });
        };

        $scope.send = function () {
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
                        $http.post('/Scientist/DeleteScientist', { Id: selected.ID }).then(function (response) {
                            $scope.scientistList = {};

                            if (response.data.Result === true) {
                                alert(response.data.ResultMessage);
                            } else {
                                alert(response.data.ResultMessage);
                            }
                            window.location.reload();
                        });
                    }
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
                            if (response.data.result === true) {
                                alert(response.data.ResultMessage);
                            } else {
                                alert("An Error Occured");
                            }
                            window.location.reload();
                        });
                    }
                });
            } else {

            }
        }; // Update Scientist

        $scope.checkAll = function () {
            debugger;
            $scope.selectedAll = false;
            if (!$scope.selectedAll) {
                $scope.selectedAll = true;
            } else {
                $scope.selectedAll = false;
            }
            angular.forEach($scope.scientistList, function (scientistDetail) {
                scientistDetail.selected = $scope.selectedAll;
            });
        }; // Check the selected row

    });

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
                        $scope.ScientistList.push({ "ID": value.ID, "FirstName": value.FirstName, "LastName": value.LastName, "Title": value.Title });
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
                            if (response.data.Result === true) {
                                alert(response.data.ResultMessage);
                            } else {
                                alert("An Error Occured");
                            }
                            window.location.reload();
                        });
                    }
                });
            } else {
            }
        };

        $scope.update = function () {
            var answer = confirm("Are you sure to update the regarding row ?");
            if (answer == true) {
                angular.forEach($scope.InventionList, function (selected) {
                    if (selected.selected) {
                        $http.post('/Home/UpdateInvention', selected).then(function (response) {
                            $scope.InventionList = {};
                            if (response.data.Result === true) {
                                alert(response.data.ResultMessage);
                            } else {
                                alert("An Error Occured");
                            }
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
            var keepGoing = true;

            angular.forEach($scope.InventionList, function (inventionDetail) {
                if (keepGoing) {
                    inventionDetail.selected = $scope.selectedAll;
                    keepGoing = false;
                }
            });
            //$('#selectedItem').prop('checked', false);
        };

    });

})();
