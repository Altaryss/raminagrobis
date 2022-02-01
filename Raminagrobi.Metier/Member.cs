using System;

namespace Raminagrobi.Metier
{
    public class Member
    {
        public string Company { get; private set; }
        public string Civility { get; private set; }
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public DateTime Create_at { get; private set; }
        public int ID { get; set; }

        public Member(int id, string company, string civility, string surname, string name, string email, string address, DateTime create_at)
        {
            ID = id;
            Company = company;
            Civility = civility;
            Surname = surname;
            Name = name;
            Email = email;
            Address = address;
            Create_at = create_at;
        }
        public void Insert ()
        {

        }
    }
}
