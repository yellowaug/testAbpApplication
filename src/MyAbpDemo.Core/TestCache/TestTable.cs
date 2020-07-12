using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace MyAbpDemo.TestCache
{
    public class TestTable:Entity<int>
    {
        public string FullName { get; set; }
        public string PhoneNum { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }


    }
}
