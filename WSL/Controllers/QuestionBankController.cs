using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DAL;
using WebService.Models;

namespace WebService
{
    [Route("/api/questionBank")]
    public class QuestionBankController : Controller
    {

        private readonly IDataService _dataService;
        private readonly IMapper _mapper;


        public QuestionBankController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet("{questionnaireID}", Name = nameof(GetQuestionsFromQuestionBank))]
        public IActionResult GetQuestionsFromQuestionBank(int questionnaireID)
        {

            var questions = _dataService.GetQuestionsFromQuestionBank(questionnaireID);
            if (questions == null) return NotFound();

            var model = _mapper.Map<List<QuestionModel>>(questions);

            return Ok(model);
        }
    }
}