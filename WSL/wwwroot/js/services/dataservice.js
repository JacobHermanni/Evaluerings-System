define([], function () {
  
    var getQuestion = function (url, callback) {
        $.getJSON(url, function (data) {
            callback(data);
        });
    };

    var getAnswers = function (callback) {
        $.getJSON("http://localhost:5001/api/answers/", function (data) {
            callback(data);
        });
    };
    
    var getActivities = function (callback) {
        $.getJSON("http://localhost:5001/api/courses/", function (data) {
            if (data !== undefined) {
                callback(data);
            }
        });
    };

    var postAnswer = function (answer, callback) {
        var jsonData = JSON.stringify(answer);
        $.ajax("http://localhost:5001/api/answers", {
            data: jsonData,
            contentType: 'application/json',
            type: 'POST',
            success: callback
        });
    };

    var postQuestionOnQuestionnaire = function (questionnaireID, questionString, callback) {
        var jsonData = JSON.stringify({ description: questionString });
        $.ajax("http://localhost:5001/api/questions/questionnaire/" + questionnaireID, {
            data: jsonData,
            contentType: 'application/json',
            type: 'POST',
            success: callback
        });
    };

    var getQuestionsOnQuestionnaire = function (questionnaireID, callback) {
        $.getJSON("http://localhost:5001/api/questionBank/" + questionnaireID, function (data) {
            if (data !== undefined) {
                callback(data);
            }
        });
    };

    var getAnswersFromQuestionnaire = function(questionnaireID, callback) {
        $.getJSON("http://localhost:5001/api/answers/questionnaire/" + questionnaireID, function (data) {
            if (data !== undefined) {
                callback(data);
            }
        });
    };

    var putReportOnEvaluation = function(evaluationID, report, callback) {
        var jsonData = JSON.stringify({ evaluation_id: evaluationID, report: report });
        $.ajax("http://localhost:5001/api/evaluation/report/", {
            data: jsonData,
            contentType: 'application/json',
            type: 'PUT',
            success: callback
        });
    }

    return {
        getActivities,
        postQuestionOnQuestionnaire,
        getQuestionsOnQuestionnaire,
        getQuestion,
        getAnswers,
        getAnswersFromQuestionnaire,
        postAnswer,
        putReportOnEvaluation
    };

});