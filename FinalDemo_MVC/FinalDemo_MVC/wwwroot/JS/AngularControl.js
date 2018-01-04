
var app = angular.module('myApp', []);
app.controller('myCtrl', function ($scope) {
    $scope.detail = [
        { Documentnames: 'Pan Card', DocumentNo: '11', DocumentDate: new Date('2017-01-12'), DocumentExpire: new Date('2017-01-12') },
        { Documentnames: 'Passport', DocumentNo: '14', DocumentDate: new Date('2017-01-12'), DocumentExpire: new Date('2017-01-12') },
        { Documentnames: 'Driving Licence', DocumentNo: '13', DocumentDate: new Date('2017-01-12'), DocumentExpire: new Date('2017-01-12') },
        { Documentnames: 'College Id', DocumentNo: '18', DocumentDate: new Date('2017-01-12'), DocumentExpire: new Date('2017-01-12') },
        //{ Documentnames: $("#doclist").val(), DocumentNo: $("#txtdoccardno").val(), DocumentDate: $("#txtstartdate").val(), DocumentExpire: $("#txtlastdate").val() }
    ];
    $scope.sort = function (x) {
        $scope.myorderby = x;
    }
});
