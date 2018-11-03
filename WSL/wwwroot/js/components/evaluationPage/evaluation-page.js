define(['knockout', 'broadcaster', 'dataservice'], function (ko, bc, dataservice) {
    return function (params) {

        var activityName = ko.observable(params.activity.course_name);
        var questionnaires = ko.observableArray(params.activity.evaluation.questionnaires);
        var report = ko.observable(params.activity.evaluation.report);
        var newReport = ko.observable("");
        var newQuestion = ko.observable("");

        var addQuestion = function () {
            // tjek for om spørgsmålet er for kort
            if (newQuestion().length < 1) {
                alert("Det spørgsmål du prøver at tilføje er for kort");
            } else {

                var n = params.activity.evaluation.questionnaires.length - 1;
                var lastQuestionnaire = params.activity.evaluation.questionnaires[n].questionnaire_id;
                var current = params.activity.course_id;

                dataservice.postQuestionOnQuestionnaire(lastQuestionnaire, newQuestion());

                dataservice.getActivities(data => {
                    for (var i = 0, len = data.length; i < len; i++) {
                        if (data[i].course_id === current) {
                            questionnaires(data[i].evaluation.questionnaires)
                        }
                    }
                });
            }
        }

        var input = document.getElementById("inputQuestion");

        input.addEventListener("keyup", function(event) {
            event.preventDefault();
            if (event.keyCode === 13) {
                addQuestion();
                newQuestion("");
            }
        });

        var saveReport = function() {
            console.log("TBD. Nuværende rapport tekst skrevet:", newReport());
        }

        return {
            activityName,
            addQuestion,
            questionnaires,
            report,
            saveReport,
            newReport,
            newQuestion
        };
    }
});