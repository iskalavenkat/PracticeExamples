using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessModifiers
{
    [ApiController]
    [Route("")]
    public class Controller
    {
        [HttpGet("s")]
        public int Get(int A,int B)
        {
            var k = PublicExamples.Class.Add(A,B);
            return k;
        }
    }
}
