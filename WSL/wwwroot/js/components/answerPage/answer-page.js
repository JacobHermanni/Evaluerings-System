define(['knockout', 'broadcaster', 'dataservice'], function (ko, bc, dataservice) {
    return function (params) {

        var activities = ko.observable();
        var currentActivity = ko.observable();
        var questionnaires = ko.observable();
        var questions = ko.observableArray([]);
        var error = ko.observable();

        // initate questions
        var loadQuestions = function () {
            questions([]);
            questionnaires().forEach(questionnaire => {
                questionnaire.questions.forEach(question => {
                    questions.push({
                        id: question.question_id,
                        question: question.description,
                        answer: "",
                        questionnaire_id: questionnaire.questionnaire_id
                    });
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

        var submitAnswers = function () {
            var answers = [];
            var error = false;

            questions().forEach(question => {
                if (!question.answer) {
                    error = true;
                    return;
                }
                answers.push({
                    question_id: question.id,
                    questionnaire_id: question.questionnaire_id,
                    answer: Number(question.answer),
                    answer_id: 0,
                    student_id: 0
                })
            });

            if (error) {
                this.error(true);
            }
            else {
                this.error(null);

                answers.forEach(answer => {
                    dataservice.postAnswer(answer, () => {});
                })

                // bc.publish(bc.events.changeView, { to: "result-page", from: "answer", activity: currentActivity() });
                bc.publish(bc.events.changeView, { to: "result-page", from: "answer" });
            }

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
            error(null);
        };

        return {
            activities,
            getEvaluation,
            currentActivity,
            questionnaires,
            back,
            questions,
            answerOptions,
            submitAnswers,
            error
        };

    }

});