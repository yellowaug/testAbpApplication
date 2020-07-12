using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace MyAbpDemo.TestCache.Dto
{
    public class TestTableDto:EntityDto<int>
    {        
        public string FullName { get; set; }
        public string PhoneNum { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }

    }
}
