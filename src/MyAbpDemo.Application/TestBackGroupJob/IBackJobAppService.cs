using Abp.Application.Services;
using MyAbpDemo.TestHttp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpDemo.TestBackGroupJob
{
    public interface IBackJobAppService:IApplicationService
    {
        Task GetToken(LoginInput loginInput);
    }
}
