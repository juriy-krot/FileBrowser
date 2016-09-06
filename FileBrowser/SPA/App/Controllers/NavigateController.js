
browserApp.controller("NavigateController", function NavigateController($scope, $http) {
    $http.get(defUrl+'/api/navigate').success(function (data) {
        $scope.files = data;
        $scope.CurrentPath = data[0].CurrentPath;

        $scope.goEnter = function(text) {
            $http.get(defUrl+'/api/navigate?path=' + encodeURIComponent(text)).success(function (data) {
                $scope.goBack = data[0].LastPath;
                $scope.files = data;
                $scope.CurrentPath = data[0].CurrentPath;
                       
            })};
            
        });
});

