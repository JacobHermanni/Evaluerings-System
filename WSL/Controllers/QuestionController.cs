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
    public class NoteController : Controller
    {
        
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;


        public NoteController(IDataService dataService, IMapper mapper)
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
        public IActionResult CreateQuestion([FromBody]Question sentQuestion)
        {
            //var question = _dataService.CreateQuestion(sentQuestion.question_id, sentQuestion.description);
            return Ok(sentQuestion);

            //if (question == null) return StatusCode(409);
            //return Created(Url.Link(nameof(GetQuestion), new {questionID = question.question_id }), question);
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
