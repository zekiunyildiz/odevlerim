using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Yedinci.Models;
namespace Yedinci.Controllers
{
    public class FootballTeamsController
    {
        [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
        [ApiController]
        [ApiVersion("1.0")]
        [ApiVersion("1.1")]
        public class FootballTeamsController : ControllerBase
        {
            private DatabaseContext _databaseContext;

            public FootballTeamsController(DatabaseContext databaseContext)
            {
                _databaseContext = databaseContext;
            }

            [HttpGet]
            [MapToApiVersion("1.0")]
            public IActionResult GetAll()
            {
                var footballPlayers = _databaseContext.FootballPlayers.ToList();
                return Ok(footballPlayers);
            }

            [HttpGet("{id}")]
            [MapToApiVersion("1.1")]
            public IActionResult GetById(int id)
            {
                var footballPlayer = _databaseContext.FootballPlayers.Find(id);
                return Ok(footballPlayer);
            }
        }
    }
}
