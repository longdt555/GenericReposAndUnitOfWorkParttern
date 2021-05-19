using System;
using System.Diagnostics;
using System.Linq;
using GenericReposAndUnitOfWorkPattern.DataContext;
using GenericReposAndUnitOfWorkPattern.Models;
using GenericReposAndUnitOfWorkPattern.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GenericReposAndUnitOfWorkPattern.Controllers
{
    [ApiController]
    [Route("v1/home")]

    public class HomeController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public HomeController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ResponseCache(Duration = 60 * 3600, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult Index()
        {
            return Ok("Run");
        }

        [HttpGet("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return Ok(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
