using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.RequestModel
{
    public interface IRequestModel
    {
        (bool isValid, List<string> validationErrors) Validation();
    }

    public class FootballTeamRequestV3 : IRequestModel
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

        public (bool isValid, List<string> validationErrors) Validation()
        {
            List<string> validateList = new List<string>();
            if (ClientId.Trim() == string.Empty)
                validateList.Add("Client Id Boş Geçilemez");


            if (MarktValue < -50)
                validateList.Add("geçersiz Bonservis değeri");

            return (validateList.Count <= 0, validateList);

        }
    }
}
