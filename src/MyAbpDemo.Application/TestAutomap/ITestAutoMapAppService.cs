using Abp.Application.Services;
using MyAbpDemo.TestAutomap.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpDemo.TestAutomap
{
    public interface ITestAutoMapAppService:IApplicationService
    {
        TestCompanyDto CreateCompany(CompanyInput companyInput);
    }
}
