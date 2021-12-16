using System;
using System.Data.SqlClient;

namespace Raminagrobis.DAL
{
    public class Fournisseurs_DAL
    {
        public string company { get; private set; }
        public string civility { get; private set; }
        public string surname { get; private set; }
        public string name { get; private set; }
        public string email { get; private set; }
        public string address { get; private set; }

        public int ID { get; set; }

        public Fournisseurs_DAL(string company, string civility, string surname, string name, string email, string address) 
                => (Company, Civility, Surname, Name, Email, Address) = (company, civility, surname, name, email, address);

        public Fournisseurs_DAL(int id, string company, string civility, string surname, string name, string email, string address)
                => (ID, Company, Civility, Surname, Name, Email, Address) = (id, company, civility, surname, name, email, address);

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into supplier(company,civility,surname,name,email,address,id)"
                                + " values (@company, @civility, @surname, @name, @email, @address, @id )";

                commande.Parameters.Add(new SqlParameter("@company", Company));
                commande.Parameters.Add(new SqlParameter("@civility", Civility));
                commande.Parameters.Add(new SqlParameter("@surname", Surname));
                commande.Parameters.Add(new SqlParameter("@name", Name));
                commande.Parameters.Add(new SqlParameter("@email", Email));
                commande.Parameters.Add(new SqlParameter("@address", Address));
                commande.Parameters.Add(new SqlParameter("@id", ID));

                commande.ExecuteNonQuery();
            }
        }
    }
}