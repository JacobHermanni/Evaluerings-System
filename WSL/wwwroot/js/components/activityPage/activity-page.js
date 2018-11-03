define(['knockout', 'broadcaster', 'dataservice'], function (ko, bc, dataservice) {
    return function (params) {

        var activities = ko.observable();

        var getActivities = function () {
            dataservice.getActivities(data => {
                activities(data);
            });
        };

        getActivities();

        var getEvaluation = function () {
            bc.publish(bc.events.changeView, { to: "evaluation-page", from: "activities", activity: this });
        };

        return {
            activities,
            getEvaluation
        };

    }

});