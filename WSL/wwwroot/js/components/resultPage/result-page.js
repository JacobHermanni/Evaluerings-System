define(['knockout', 'broadcaster', 'dataservice'], function (ko, bc, dataservice) {
    return function (params) {

        var result = ko.observable();
        var answers = ko.observable();

        console.log(params);

         var getAnswers = function () {
            dataservice.getAnswers(data => {
                answers(data);
            });
        };

        getAnswers();

        return {

        answers

        };

    }

});