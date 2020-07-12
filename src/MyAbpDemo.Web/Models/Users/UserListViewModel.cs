using System.Collections.Generic;
using MyAbpDemo.Roles.Dto;
using MyAbpDemo.Users.Dto;

namespace MyAbpDemo.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}