using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer;
using DataEntities;

namespace BussinesLayer
{
    public class BLLogin
    {
        DbContext db = new DbContext();

        public async Task<bool>Insert(UserModel user)
        {
            try
            {
                var response = await db.InsertUser(user);
                return response;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<UserModel> DoLogin(string User, string Password)
        {
            try
            {
                var response = await db.GetUser(User, Password);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> ValidateUser(string User, string email)
        {
            try
            {
                var result = await db.ValidateUser(User, email);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<List<UserModel>>ListUser()
        {
            try
            {
                var result = await db.ListUser();
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }

        }
        public async Task<bool> Update(UserModel user)
        {
            try
            {
                var response = await db.UpdateUser(user);
                return response;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int IdUser)
        {
            try
            {
                var result = await db.DeleteUser(IdUser);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
