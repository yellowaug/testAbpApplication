using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using MyAbpDemo.TestHttp.Dto;

namespace MyAbpDemo.TestHttp
{
    public interface IHttpRequestAppService:IApplicationService
    {
        Task<ResponDto> TestLogin(LoginInput input);
        Task<string> TestInterface();
        Task<string> TestHistoryData(ParameteInput paramete);
        Task<string> TestHumidityHistoryData(ParameteInput paramete);
    }
}
