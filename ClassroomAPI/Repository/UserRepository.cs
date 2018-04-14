using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomAPI.Models;
using ClassroomAPI.DomainModels;
using ClassroomAPI.Data;

namespace ClassroomAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext bContext)
        {
            context = bContext;
        }
        bool IUserRepository.DeleteUser(Guid id)
        {
            try
            {
                var record = context.Users.Where(x => x.ID == id && x.IsActive == true).FirstOrDefault();
                if (record != null)
                {
                    record.IsActive = false;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        List<UserModel> IUserRepository.GetAllUser()
        {
            try
            {
                var query = context.Users.ToList();
                List<UserModel> list = new List<UserModel>();
                if (query != null)
                {
                    foreach (var item in query)
                    {
                        UserModel userModel = new UserModel();
                        userModel.ID = item.ID;
                        userModel.FirstName = item.firstName;
                        userModel.Email = item.Email;
                        userModel.LastName = item.lastName;
                        userModel.UserRoleID = item.UserRoleID;
                        userModel.CreatedDate = item.CreatedDate;
                        userModel.IsActive = item.IsActive;
                        list.Add(userModel);
                    }
                    return list;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        UserModel IUserRepository.GetUserById(Guid id)
        {
            try
            {
                var item = context.Users.FirstOrDefault(x => x.ID == id && x.IsActive == true);
                if (item != null)
                {
                    UserModel userModel = new UserModel();
                    userModel.ID = item.ID;
                    userModel.FirstName = item.firstName;
                    userModel.Email = item.Email;
                    userModel.LastName = item.lastName;
                    userModel.UserRoleID = item.UserRoleID;
                    userModel.CreatedDate = item.CreatedDate;
                    userModel.IsActive = item.IsActive;
                    return userModel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        bool IUserRepository.InsertUser(UserModel model)
        {
            try
            {
                User user = new User();
                user.ID = Guid.NewGuid();
                user.firstName = model.FirstName;
                user.lastName = model.LastName;
                user.Password = model.Password;
                user.CreatedDate = DateTime.Now;
                user.Email = model.Email;
                user.IsActive = true;
                user.UserRoleID = model.UserRoleID;
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        UserModel IUserRepository.LoginUser(UserModel model)
        {
            try
            {
                var record = context.Users.Where(x => x.Email == model.Email && 
                             x.Password == model.Password && x.IsActive == true).FirstOrDefault();

                if (record != null)
                {
                    UserModel mod = new UserModel();
                    mod.ID = record.ID;
                    mod.FirstName = record.firstName;
                    mod.LastName = record.lastName;
                    mod.Email = record.Email;
                    
                    return mod;
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        List<RoleModel> IUserRepository.GetAllRoles()
        {
            try
            {
                var query = context.UserRoles.ToList();
                List<RoleModel> list = new List<RoleModel>();
                if (query != null)
                {
                    foreach (var item in query)
                    {
                        RoleModel model = new RoleModel();
                        model.Id = item.ID;
                        model.Role = item.Role;
                        list.Add(model);
                    }
                    return list;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
