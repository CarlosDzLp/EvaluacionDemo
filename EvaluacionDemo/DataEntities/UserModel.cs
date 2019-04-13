using System;
using SQLite;

namespace DataEntities
{
    public class UserModel
    {
        [PrimaryKey,AutoIncrement]
        public int IdUser { get; set; }

        public string Email { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public bool Status { get; set; }

        public string Sex { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
