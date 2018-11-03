﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DAL;
using WebService.Models;

namespace WebService
{
    [Route("/api/answer")]
    public class AnswerController : Controller
    {

        private readonly IDataService _dataService;
        private readonly IMapper _mapper;


        public AnswerController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetAnswer))]
        public IActionResult GetAnswer()
        {

            var answer = _dataService.GetAnswers();
            if (answer == null) return NotFound();

            var model = _mapper.Map<List<AnswerModel>>(answer);

            return Ok(model);
        }
    }
}