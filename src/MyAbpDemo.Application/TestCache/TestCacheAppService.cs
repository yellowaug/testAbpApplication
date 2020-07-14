using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Json;
using MyAbpDemo.TestCache.Dto;

namespace MyAbpDemo.TestCache
{
    public class TestCacheAppService : ITestCacheAppService
    {
        private readonly IRepository<TestTable> _testTablerepository;
        private readonly AbpRedisManager abpRedis;
        public TestCacheAppService(IRepository<TestTable> testTablerepository, AbpRedisManager abpRedis)
        {
            _testTablerepository = testTablerepository;
            this.abpRedis = abpRedis;
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
            var db = abpRedis.redisDb("10.12.2.61:6379");
            db.StringSet("test1", testTable.ToJsonString());
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
