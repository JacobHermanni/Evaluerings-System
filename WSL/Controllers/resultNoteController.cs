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
    [Route("/api/evaluation/report")]

    public class resultNotesController : Controller
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public resultNotesController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }
        [HttpPut]
        public IActionResult AddReport([FromBody]EvaluationModel evaluation)
        {
            var report = _dataService.AddReport(evaluation.evaluation_id, evaluation.report);

            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }

    }
}
