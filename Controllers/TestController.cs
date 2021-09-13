using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iRepair_BE_NET.Models;
using iRepair_BE_NET.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace iRepair_BE_NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly ITestServices _itestservice;

        public TestController(ILogger<TestController> logger,
                              ITestServices itestservice){
            _logger = logger;
            _itestservice = itestservice ?? throw new ArgumentNullException(nameof(itestservice));
        }

        [HttpGet]
        public async Task<IActionResult> GetAdminList(){
            var accounts = await _itestservice.GetAll();

            return Ok(accounts);
        }

        



    }
}