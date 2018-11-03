define(['knockout', 'broadcaster', 'dataservice'], function (ko, bc, dataservice) {
    return function (params) {
        var activityName = ko.observable(params.activity.course_name);
        var questionnaires = ko.observableArray(params.activity.evaluation.questionnaires);
        var report = ko.observable(params.activity.evaluation.report);
        var newReport = ko.observable("");



        var saveReport = function() {
            console.log("TBD. Nuværende rapport tekst skrevet:", newReport());
        }

        return {
            activityName,
            questionnaires,
            report,
            saveReport,
            newReport
        };
    }
});