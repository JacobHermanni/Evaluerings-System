using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using DAL;
using WebService.Models;

namespace WebService
{
    [Route("/api/questions")]
    public class QuestionController : Controller
    {
        
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;


        public QuestionController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetQuestions))]
        public IActionResult GetQuestions()
        {

            var questions = _dataService.GetQuestions();
            if (questions == null) return NotFound();

            var model = _mapper.Map<List<QuestionModel>>(questions);

            return Ok(model);
        }

        [HttpGet("{questionID}", Name = nameof(GetQuestion))]
        public IActionResult GetQuestion(int questionID)
        {
            var question = _dataService.GetQuestion(questionID);
            if (question == null) return NotFound();

            var model = _mapper.Map<QuestionModel>(question);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateQuestionInBank([FromBody]Question sentQuestion)
        {
            var question = _dataService.CreateQuestionInBank(sentQuestion.question_id, sentQuestion.description);

            if (question == null) return StatusCode(409);
            return Ok(question);
        }

        [HttpPost("questionnaire/{questionnaireID}", Name = nameof(CreateQuestionOnQuestionnaire))]
        public IActionResult CreateQuestionOnQuestionnaire(int questionnaireID, [FromBody]Question sentQuestion)
        {
            var question = _dataService.CreateQuestionOnQuestionnaire(questionnaireID, sentQuestion.question_id, sentQuestion.description);

            if (question == null) return StatusCode(409);
            return Ok(question);
        }

        [HttpDelete("{questionID}", Name = nameof(DeleteQuestion))]
        public IActionResult DeleteQuestion(int questionID)
        {
            // this is a boolean value
            var isQuestionDeleted = _dataService.DeleteQuestion(questionID);

            if (isQuestionDeleted) return Ok();
            return NotFound();
        }

        // TODO: Har ikke laveg en PUT (Update)
    }
}
