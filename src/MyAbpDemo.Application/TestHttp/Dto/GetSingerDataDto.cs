using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpDemo.TestHttp.Dto
{
    public class GetSingerDataDto
    {
        public string userApiKey { get; internal set; }
        public string flagCode { get; internal set; }
        public string deviceNo { get; internal set; }
    }
}
