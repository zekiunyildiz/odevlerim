using MyProject.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Mapping
{
    public static class MappingExtensions
    {
        public static List<FootballTeamModel> FootballTeamModelResponse(this List<FootballTeam> footballTeams)
        {
            List<FootballTeamModel> result = new List<FootballTeamModel>();

            for (int i = 0; i < footballTeams.Count; i++)
            {
                result.Add(new FootballTeamModel
                {
                    Id = footballTeams[i].Id,
                    Captain = footballTeams[i].Captain,
                    Coach = footballTeams[i].Coach,
                    MarktValue = footballTeams[i].MarktValue
                });
            }

            return result;


        }


    }
}
