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


        public int Insert()
        {
            DBservices dbs = new DBservices();
            return dbs.InsertUser(this);
        }



        public List<User> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadUsers();
        }

        public int Update()
        {
            DBservices dbs = new DBservices();
            return dbs.UpdateUser(this);

        }
    }
}
