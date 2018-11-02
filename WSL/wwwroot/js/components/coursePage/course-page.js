define(['knockout', 'broadcaster', 'dataservice'], function (ko, bc, dataservice) {
    return function (params) {

        var courses = ko.observable();

        var getCourses = function () {
            dataservice.getCourses(data => {
                courses(data);
                console.log(data);
            });
        }

        getCourses();

        return {
            courses
        };

    }

});