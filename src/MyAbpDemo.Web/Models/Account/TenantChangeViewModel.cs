using Abp.AutoMapper;
using MyAbpDemo.Sessions.Dto;

namespace MyAbpDemo.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}