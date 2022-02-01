using System;
using System.Data.SqlClient;

namespace Raminagrobis.DAL
{
    public class Member_DAL
    {
        public string Company { get; private set; }
        public string Civility { get; private set; }
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public DateTime Create_at { get; private set; }

        public int ID { get; set; }

        public Member_DAL(string company, string civility, string surname, string name, string email, string address, DateTime create_at) 
                => (Company, Civility, Surname, Name, Email, Address, Create_at) = (company, civility, surname, name, email, address, create_at);

        public Member_DAL(int id, string company, string civility, string surname, string name, string email, string address, DateTime create_at)
                => (ID, Company, Civility, Surname, Name, Email, Address , Create_at) = (id, company, civility, surname, name, email, address, create_at);
    }
}