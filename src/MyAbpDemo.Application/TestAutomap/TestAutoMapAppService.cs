using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Json;
using Abp.ObjectMapping;
using MyAbpDemo.TestAutomap.Dto;
using MyAbpDemo.TestCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpDemo.TestAutomap
{
    public class TestAutoMapAppService : ITestAutoMapAppService
    {
        private readonly IRepository<TestCompany> companyrepository;
        private readonly IObjectMapper _objectMapper;
        private AbpRedisManager redisManager;
        public TestAutoMapAppService(IRepository<TestCompany> companyrepository, IObjectMapper objectMapper, AbpRedisManager redisManager)
        {
            this.companyrepository = companyrepository;
            _objectMapper = objectMapper;
            this.redisManager = redisManager;
        }
        public TestCompanyDto CreateCompany(CompanyInput companyInput)
        {
            var redisdb= this.redisManager.redisDb("10.12.2.61");
            if (companyInput != null)
            {
                var aaa = _objectMapper.Map<TestCompanyDto>(companyInput);
                var sss = _objectMapper.Map<TestCompany>(aaa);
                this.companyrepository.Insert(sss);
                redisdb.StringSet("test2", aaa.ToJsonString());
                //var aaa=companyInput.Obje
                //this.companyrepository.Insert()
                return aaa;
            }
            else
                return null;
        }
    }
}
