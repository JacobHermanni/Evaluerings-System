define(['knockout', 'broadcaster', 'dataservice', 'bootstrap'], function (ko, bc, dataservice) {
    return function (params) {

        var activities = ko.observable();
        var currentActivity = ko.observable();
        var answers = ko.observableArray([]);
        var questionnaires = ko.observable();
        var questions = ko.observableArray([]);
        var question = ko.observable();

        // console.log("params", params);

        var getAnswers = function (questionnaireID) {
            dataservice.getAnswersFromQuestionnaire(questionnaireID, data => {
                // console.log(data);
                for (i = 0; i < data.length; i++) {
                    answers.push(data[i]);
                }
                // forfærdeligt sted at sætte funktionen men det er ikke muligt, at iterere på observable arrayet hvis den ikke er her
                calculateAvg(answers(), questions());
            });
        }

        var calculateAvg = function (answers, questions) {
            // console.log("answers:", answers, "questions:", questions);
             
            questions.forEach(q => {
                var sum = 0;
                var count = 0;
                var answerArray = [];
                answers.forEach(a => {
                    if (q.id == a.question_id) {
                        sum += a.answer;
                        count++;
                        answerArray.push(a);
                    }
                });
                var avg = sum/count;
                q.numberOfAnswers = count;
                q.answerAvg = avg.toFixed(2);
                q.answers = answerArray;
            });
        }

        var getQuestionForModal = function () {
            question(this);
            console.log(this);
            getChart(this.answers);
        }

        var getActivities = function () {
            dataservice.getActivities(data => {
                activities(data);
            });
        }

        var loadResults = function () {
            questions([]);
            questionnaires().forEach(questionnaire => {
                questionnaire.questions.forEach(question => {
                    questions.push({
                        id: question.question_id,
                        question: question.description,
                        questionnaire_id: questionnaire.questionnaire_id,
                        answerAvg: 0,
                        numberOfAnswers: 0,
                        answers: []
                    });
                });
                getAnswers(questionnaire.questionnaire_id);
            });
            calculateAvg(answers(), questions());
            console.log(questions());
        }

        var getEvaluation = function (activity) {
            currentActivity(activity);
            questionnaires(activity.evaluation.questionnaires);
            loadResults();
            console.log("got evaluation", activity);
        }

        var loadResultPage = function () {
            if (params.activity != undefined) {
                getEvaluation(params.activity);
            } else {
                getActivities();
            }
        }

        loadResultPage();

        var getChart = function (answers) {

            var answerData = [];

            console.log("from getChart:", answers);

            var sum = 0;
            var count = answers.length;

            var sum1 = 0;
            var sum2 = 0;
            var sum3 = 0;
            var sum4 = 0;
            var sum5 = 0;


            for (i = 0; i < answers.length; i++) {
                sum += answers[i].answer;
                if (answers[i].answer == 1) {
                    sum1 ++;
                }
                if (answers[i].answer == 2) {
                    sum2 ++;
                }
                if (answers[i].answer == 3) {
                    sum3 ++;
                }
                if (answers[i].answer == 4) {
                    sum4 ++;
                }
                if (answers[i].answer == 5) {
                    sum5 ++;
                }
            }

            sum1 = sum1/count*100;
            var sum1percent = sum1.toFixed(2);

            sum2 = sum2/count*100;
            var sum2percent = sum2.toFixed(2);

            sum3 = sum3/count*100;
            var sum3percent = sum3.toFixed(2);

            sum4 = sum4/count*100;
            var sum4percent = sum4.toFixed(2);

            sum5 = sum5/count*100;
            var sum5percent = sum5.toFixed(2);

            answerData.push({
                    name: '1',
                    y: parseInt(sum1percent),
                },{
                    name: '2',
                    y: parseInt(sum2percent),
                },{ 
                    name: '3',
                    y: parseInt(sum3percent),
                },{
                    name: '4',
                    y: parseInt(sum4percent),
                },{
                    name: '5',
                    y: parseInt(sum5percent),
            });

            console.log("answerData:", answerData);

            console.log("sum:", sum);
            console.log("count:", count);

            Highcharts.chart('pieDiagram', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: {
                    text: 'Hvor mange har svaret hvad?'
                },
                credits: {
                    enabled: false
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                            style: {
                                color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                            }
                        }
                    }
                },
                series: [{
                    name: 'Brands',
                    colorByPoint: true,
                    data: answerData
                }]
            });

        }


        return {
            getEvaluation,
            activities,
            currentActivity,
            answers,
            getAnswers,
            questions,
            getQuestionForModal,
            question
        };

    }

});