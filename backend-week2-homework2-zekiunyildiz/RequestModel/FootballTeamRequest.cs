using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.RequestModel
{
    public class FootballTeamRequest
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public decimal MarktValue { get; set; }
        public string Captain { get; set; }
        public string Coach { get; set; }
    }
}
