using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpDemo.TestHttp.Dto
{
    public class GetHistoryDataDto
    {
        public string sensorId { get; set; }
        public string page { get; set; }
        public string pageSize { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string userApiKey { get; set; }
        public string companyKey { get; set; }
        public string flagCode { get; set; }



    }
}
