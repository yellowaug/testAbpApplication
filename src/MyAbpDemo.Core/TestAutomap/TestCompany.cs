using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpDemo.TestAutomap
{
    public class TestCompany:Entity
    {
        public string  CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }

    }
}
