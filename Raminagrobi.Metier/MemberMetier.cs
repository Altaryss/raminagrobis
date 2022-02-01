using System;

namespace Raminagrobi.Metier
{
    public class MemberMetier
    {
        public int ID { get; private set; }
        public string Company { get; private set; }
        public string Civility { get; private set; }
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public DateTime CreateAt { get; private set; }

        public MemberMetier(int id, string company, string civility, string surname, string name, string email, string address, DateTime createAt)
        {
            ID = id;
            Company = company;
            Civility = civility;
            Surname = surname;
            Name = name;
            Email = email;
            Address = address;
            CreateAt = createAt;
        }

        public void Insert()
        {
            Member_DAL member = new Member_DAL(Company, Civility, Surname, Name, Email, Address, CreateAt);
            Member_Depot_DAL memberDepot = new Member_Depot_DAL();
            memberDepot.Insert(member);
        }

    }
}
