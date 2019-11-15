using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_WebAPI.Models;

namespace MVC_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private List<Person> people = new List<Person>()
        {
            new Person() {ID = 1, firstName = "Spot", email = "spot@pet.com"},
            new Person() {ID = 2, firstName = "Rover", email = "rover@pet.com"},
            new Person() {ID = 3, firstName = "Daisy", email = "daisy@pet.com"}
        };

        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult(people);
        }

        [HttpGet ("{id}", Name="GetPerson")]
        public IActionResult Get(int id)
        {
            Person person = (from p in people
                            where p.ID == id
                            select p).FirstOrDefault();
                            
            return new ObjectResult(person);
        }
    }
}
