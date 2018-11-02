define(['knockout', 'broadcaster', 'dataservice'], function (ko, bc, dataservice) {
    return function (params) {

        var courses = ko.observable();

        var getCourses = function () {
            dataservice.getCourses(data => {
                courses(data);
            });
        }

        getCourses();

        var getEvaluation = function () {
            bc.publish(bc.events.changeView, { to: "evaluation-page", from: "courses", course: this });
        }

        return {
            courses,
            getEvaluation
        };

    }

});