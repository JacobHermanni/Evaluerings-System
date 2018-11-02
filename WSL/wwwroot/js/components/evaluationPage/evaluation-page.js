define(['knockout', 'broadcaster', 'dataservice'], function (ko, bc, dataservice) {
    return function (params) {
        var courseName = ko.observable();
        courseName(params.course.course_name);


        return {
            courseName
        };

    }

});