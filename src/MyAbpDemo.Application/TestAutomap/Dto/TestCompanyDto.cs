using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpDemo.TestAutomap.Dto
{
    [AutoMapTo(typeof(TestCompany))]
    public class TestCompanyDto:EntityDto
    {
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
    }
}
