using ClassroomAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomAPI.Repository
{
    public interface IUserRepository
    {
        bool InsertUser(UserModel model);
        List<UserModel> GetAllUser();
        UserModel GetUserById(Guid id);
        bool DeleteUser(Guid id);
        UserModel LoginUser(UserModel model);
        List<RoleModel> GetAllRoles();
    }
}
