using System;
using System.Data.SqlClient;

namespace Raminagrobis.DAL
{
    public class References_DAL
    {
        public string References { get; private set; }
        public string Wording { get; private set; }
        public string Brand { get; private set; }
        public bool Status { get; private set; }

        public int ID { get; set; }

        public References_DAL(string references, string wording, string brand, bool status)
                => (References, Wording, Brand, Status) = (references, wording, brand, status);

        public References_DAL(int id,string references, string wording, string brand, bool status)
                => (ID, References, Wording, Brand, Status) = (id ,references, wording, brand, status);

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into supplier(references,wording,brand,status,id)"
                                + " values (@references, @wording, @brand, @id)";

                commande.Parameters.Add(new SqlParameter("@references", References));
                commande.Parameters.Add(new SqlParameter("@wording", Wording));
                commande.Parameters.Add(new SqlParameter("@brand", Brand));
                commande.Parameters.Add(new SqlParameter("@id", ID));

                commande.ExecuteNonQuery();
            }
        }
    }
}