using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace HomeWork2.BL
{
    public class User
    {
        string firstName;
        string lastName;
        string email;
        string password;

        public User(string firstName, string lastName, string email, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
        }

        public User() { }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }

        // insert user - registration
        public int Insert()
        {
            DBservices dbs = new DBservices();

            List<User> users = Read();

            foreach (var user in users)
            {
                if(user.email == this.email) { return -1; }
            }

            return dbs.InsertUser(this);
        }

        // get all users
        public List<User> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadUsers();
        }

        //update user

        public User Update()
        {
            DBservices dbs = new DBservices();
            return dbs.UpdateUser(this);

        }

        // login user
        public User Login(string email, string password)
        {
            DBservices dbs = new DBservices();
            return dbs.LoginUser(email, password);
               
        }

        //delete user
        public int Delete(string email)
        {
            DBservices dbs = new DBservices();
            return dbs.DeleteUserByEmail(email);
        }
        
    }
}
