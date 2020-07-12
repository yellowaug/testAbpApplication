using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpDemo.TestHttp.Dto
{
    public class ParameteInput
    {
        //public string UriPath { get; set; }
        public int SensorCode { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
