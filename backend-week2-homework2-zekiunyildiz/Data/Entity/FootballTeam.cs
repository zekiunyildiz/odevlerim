using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Data.Entity
{
    public class FootballTeam
    {
        public int Id { get; set; }
        public decimal MarktValue { get; set; }
        public string Captain { get; set; }
        public string Coach { get; set; }

    }
}
