using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpDemo.TestCache.Dto
{
    [AutoMapFrom(typeof(TestTable))]
    public class TestTableCacheDto
    {
        public string FullName { get; set; }
        public string PhoneNum { get; set; }
    }
}
