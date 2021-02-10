var app = angular.module("MyApp", []);

app.controller("PortCtrl", function ($scope, $http) {
    $scope.portfoliodata = [];
    $scope.Getportfolio = function () {
        $http({
            method: "GET",
            url: "../Home/GetPortfolio"
        }).then(function mySuccess(response) {
            $scope.portfoliodata = response.data;
            //$('#portfoliodiv').html('');

            for (var i = 0; i < response.data.length; i++) {

                var portstr = "<div class= 'col-lg-3 col-md-6 col-sm-6 portfolio-item " + response.data[i].PortfolioType + "' > " +
                    "<div class='portfolio-wrap'>" +
                    "<figure>" +
                    "<img src='" + response.data[i].ImagePath + "' alt='" + response.data[i].ImageName + "'>" +
                    "<a href='" + response.data[i].ImagePath + "' class='link-preview' data-lightbox='portfolio'><i class='fa fa-eye'></i></a>" +
                    "<a href='" + response.data[i].PortfolioLink + "' class='link-details' target='_blank'><i class='fa fa-link'></i></a>" +
                    "<a class='portfolio-title' href='" + response.data[i].PortfolioLink + "' target='_blank'>" + response.data[i].PortfolioName + "</a>" +
                    "</figure>" +
                    "</div>" +
                    "</div>" 



                $('#portfoliodiv').append(portstr);

            }


        }, function myError(response) {
             $scope.portfoliodata = response.statusText;
        });


       
    
    }


   

});