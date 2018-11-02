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
    [Route("/api/courses")]
    public class CourseController : Controller
    {

        private readonly IDataService _dataService;
        private readonly IMapper _mapper;


        public CourseController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetCourses))]
        public IActionResult GetCourses()
        {

            var courses = _dataService.GetCourses();
            if (courses == null) return NotFound();

            var model = _mapper.Map<List<CourseModel>>(courses);

            return Ok(model);
        }
    }
}
