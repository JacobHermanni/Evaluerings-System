define(['knockout', 'broadcaster', 'dataservice'], function (ko, bc, dataservice) {
    return function (params) {

        var activities = ko.observable();
        var currentActivity = ko.observable();
        var questionnaires = ko.observable();
        var questions = ko.observableArray([]);

        // initate questions
        var loadQuestions = function () {
            questions([]);
            questionnaires().forEach(questionnaire => {
                questionnaire.questions.forEach(question => {
                    questions.push({ id: ko.observable(question.question_id), question: question.description });
                });
            });
        }

        var answerOptions = [
            { key: "1", value: "1" },
            { key: "2", value: "2" },
            { key: "3", value: "3" },
            { key: "4", value: "4" },
            { key: "5", value: "5" }
        ];

        var printAnswers = function () {
            questions().forEach(element => {
                console.log(element);
            });
        };


        var isChecked = function () {
            console.log(this);
            return true;
        };

        var chooseAnswer = function (value) {
            console.log("value should be value of 2:", value);
            console.log("this should be this:", this);
        };

        var back = function () {
            currentActivity(null);
        };

        var getActivities = function () {
            dataservice.getActivities(data => {
                activities(data);
            });
        };

        getActivities();

        console.log("student id:", params.studentId);

        var getEvaluation = function () {
            currentActivity(this);
            questionnaires(this.evaluation.questionnaires);
            loadQuestions();
        };

        return {
            activities,
            getEvaluation,
            currentActivity,
            questionnaires,
            back,
            chooseAnswer,
            isChecked,
            questions,
            answerOptions,
            printAnswers
        };

    }

});