using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using MyAbpDemo.TestCache.Dto;

namespace MyAbpDemo.TestCache
{
    public class TestCacheAppService : ITestCacheAppService
    {
        private readonly IRepository<TestTable> _testTablerepository;
        public TestCacheAppService(IRepository<TestTable> testTablerepository)
        {
            _testTablerepository = testTablerepository;
        }

        public TestTableDto CreateTest(InputDto inputDto)
        {
            TestTable testTable = new TestTable()
            {
                FullName = inputDto.FullName,
                Address = inputDto.Address,
                Company = inputDto.Company,
                PhoneNum = inputDto.PhoneNum
            };

            var a=_testTablerepository.Insert(testTable);
            return new TestTableDto()
            {
                FullName = a.FullName,
                Address = a.Address,
                Company = a.Company,
                PhoneNum = a.PhoneNum
            };
        }

        public TestTableDto Getdata(int id)
        {
            var s= this._testTablerepository.Get(id);
            TestTableDto testTableDto = new TestTableDto()
            {
                Address = s.Address,
                PhoneNum = s.PhoneNum,
                Id = s.Id,
                FullName = s.FullName,
                Company = s.Company
            };
            int sum = 1 + 100;
            Console.WriteLine(sum);
            return testTableDto;

        }
    }
}
