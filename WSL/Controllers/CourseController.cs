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
    [Route("/api/course")]
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
            var lort = "..lort";
            if (courses == null) return Ok(lort);

            // mapper enkelt objekt og derefter indsætter enkel url
            var model = _mapper.Map<List<CourseModel>>(courses);
            var json = courses[0].course_name;

            return Ok(model);
        }
    }
}
