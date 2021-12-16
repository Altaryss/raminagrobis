using System;
using System.Data.SqlClient;

namespace Raminagrobis.DAL
{
    public class Supplier_DAL
    {
        public string Company { get; private set; }
        public string Civility { get; private set; }
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public DateTime Create_at { get; private set; }  

        public int ID { get; set; }

        public Supplier_DAL(string company, string civility, string surname, string name, string email, string address, DateTime create_at) 
                => (Company, Civility, Surname, Name, Email, Address, Create_at) = (company, civility, surname, name, email, address, create_at);

        public Supplier_DAL(int id, string company, string civility, string surname, string name, string email, string address, DateTime create_at)
                => (ID, Company, Civility, Surname, Name, Email, Address, Create_at) = (id, company, civility, surname, name, email, address, create_at);

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into supplier(company,civility,surname,name,email,address,create_at,id)"
                                + " values (@company, @civility, @surname, @name, @email, @address, @create_at, @id )";

                commande.Parameters.Add(new SqlParameter("@company", Company));
                commande.Parameters.Add(new SqlParameter("@civility", Civility));
                commande.Parameters.Add(new SqlParameter("@surname", Surname));
                commande.Parameters.Add(new SqlParameter("@name", Name));
                commande.Parameters.Add(new SqlParameter("@email", Email));
                commande.Parameters.Add(new SqlParameter("@address", Address));
                commande.Parameters.Add(new SqlParameter("@create_at", Create_at));
                commande.Parameters.Add(new SqlParameter("@id", ID));

                commande.ExecuteNonQuery();
            }
        }
    }
}