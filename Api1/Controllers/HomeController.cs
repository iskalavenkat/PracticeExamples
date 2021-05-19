using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using Api1.Startup;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;

namespace Api1.Controllers
{
    [ApiController]
    [Route("g")]
    public class HomeController:ControllerBase
    {
       // private readonly ModelClass model1;
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //model1 = model;
        }
        //IApplicationBuilder app;
        //[HttpPost("w")]
        //public void GH()
        //{
        //   app.Use(async (context,next) =>
        //        {
        //            await context.Response.WriteAsync("sss");
        //        });
        //}
        // public IConfiguration Configuration { get; }
        [HttpPost("logger ")]
         public IActionResult Post([FromBody] ModelClass model)
        {
            Log.Logger = new LoggerConfiguration()
           //.WriteTo.ColoredConsole()
           .WriteTo.Seq("http://localhost:5341")
           .CreateLogger();
            // throw new Exception("exception Do not run");

            // return Configuration["Mykey"];
            _logger.LogInformation("logging started");
            RequestModelClass request = new RequestModelClass();
            _logger.LogError("Error");
            return Ok(request.Emp(model));
        }
        [HttpGet("Iaction result")]
        public IActionResult get()
        {
            int a = 10;
            var result = new OkObjectResult(new {message = "200 OK", a });
            return result;
            //we can use return Ok(a);
        }
        [HttpGet("task<>")]
        public async Task<int>  GetV()
        {
            //ask uma akka
            int a = 10;
            if(a==10)
            {
                _logger.LogError("dd");
            }
            else
            {
                return await Task.FromResult(a);
            }
            return 0;
        }
        [HttpGet("task")]
        public async Task Gett()
        {
            int a = 20;
            await Task.FromResult(a); //it will not return anything
        }
        [HttpGet("File reading")]
        public async Task gethj()
        {
            string filePath = "D:\\sampleFile.txt";
            Task<int> task = ReadFile(filePath);
           int length = await task;
             await Task.FromResult(length); 
        }
        static async Task<int> ReadFile(string file)
        {
            int length = 0;

           
            using (StreamReader reader = new StreamReader(file))
            {
                // Reads all characters from the current position to the end of the stream asynchronously    
                // and returns them as one string.    
                string s = await reader.ReadToEndAsync();

                length = s.Length;
            }
           
            return length;
        }
        [HttpPost("hj")]

        public async Task<ActionResult<ModelClass>> Example([FromBody] ModelClass model)
        {
            // ModelClass j = new ModelClass();

            return Ok(model);
            // return j.name+"\n"+j.id+"\n"+j.salary + "\n" + j.phonenumber;

        }
    }
}
