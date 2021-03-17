using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.RequestModel
{
    public class FootballTeamRequestV2
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public decimal MarktValue { get; set; }
        public string Captain { get; set; }
        public string Coach { get; set; }

        public (bool isValid, List<string> validationErrors) Validate2()
        {
            List<string> validateList = new List<string>();
            if (ClientId.Trim() == string.Empty)
                validateList.Add("Client Id Boş Geçilemez");


            if (MarktValue < 0)
                validateList.Add("geçersiz Bonservis değeri");

            return (validateList.Count <= 0, validateList);
        }
    }
}
