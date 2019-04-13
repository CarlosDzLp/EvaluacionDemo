using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Helpers;
using DataEntities;
using SQLite;
using Xamarin.Forms;

namespace DataAccessLayer
{
    public class DbContext
    {
        #region Contructor
        private readonly SQLiteConnection connection;
        public DbContext()
        {
            try
            {
                //creacion de la coneccion
                var dbPath = DependencyService.Get<IPathString>().StringPath();
                connection = new SQLiteConnection(dbPath, true);
                connection.CreateTable<UserModel>();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        #endregion

        #region CRUDUser
        public async Task<bool> InsertUser(UserModel user)
        {
            try
            {
                var query = connection.Insert(user);
                if(query>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ValidateUser(string user,string email)
        {
            try
            {
                var query = connection.Table<UserModel>().Where(c => c.Email == email && c.User == user).FirstOrDefault();
                if (query != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateUser(UserModel user)
        {
            try
            {
                var query = connection.Update(user);
                if(query > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<UserModel> GetUser(string user,string Password)
        {
            try
            {
                var query = connection.Table<UserModel>().Where(c => c.User == user && c.Password == Password && c.Status==true).FirstOrDefault();
                return query;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public async Task<List<UserModel>> ListUser()
        {
            try
            {
                var response = connection.Table<UserModel>().ToList();
                return response;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public async Task<bool> DeleteUser(int IdUser)
        {
            try
            {
                var query = connection.Table<UserModel>().Where(c => c.IdUser == IdUser).FirstOrDefault();
                if(query != null)
                {
                    query.Status = false;
                    var queryResult = connection.Update(query);
                    if(queryResult > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
