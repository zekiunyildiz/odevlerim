using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Mapping;
using MyProject.RequestModel;
using Newtonsoft.Json;

namespace MyProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {

        private DbContextOptions<DatabaseContext> option;
        public TeamController()
        {
            option = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options;
        }



        [HttpGet]
        public IActionResult Get()
        {
            List<FootballTeamModel> result = new List<FootballTeamModel>();
            using(DatabaseContext dbContext = new DatabaseContext(option))
            {

                var entityList = dbContext.FootballTeam.ToList();
                result = entityList.FootballTeamModelResponse();
                
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] FootballTeamRequest request)
        {
            #region validation1

            List<string> validations = new List<string>();

            if (request.ClientId == string.Empty)
            {
                validations.Add("Client Id Boş Geçilmez");
            }
            if (request.MarktValue<0)
            {
                validations.Add("Geçersiz Bonservis değeri");
            }

            if (validations.Any())
                return BadRequest(validations);

            #endregion validation1

            #region validation2

            var request2 = JsonConvert.DeserializeObject<FootballTeamRequestV2>(JsonConvert.SerializeObject(request));

            var validate2_1 = request2.Validate2();
            if (!validate2_1.isValid)
                return BadRequest(validate2_1.validationErrors);

            #endregion validation2

            #region validation3

            var request3 = JsonConvert.DeserializeObject<FootballTeamRequestV3>(JsonConvert.SerializeObject(request));

            var validation3 = request3.Validation();
            if (!validation3.isValid)
                return BadRequest(validation3.validationErrors);

            #endregion validation3



            return Ok();
        }

    }
}
