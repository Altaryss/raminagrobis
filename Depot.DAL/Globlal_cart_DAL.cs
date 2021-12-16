using System;
using System.Data.SqlClient;

namespace Raminagrobis.DAL
{
    public class Globlal_cart_DAL
    {
        public int Id_cart { get; private set; }
        public string Week_order { get; private set; }

        public int ID { get; set; }

        public Globlal_cart_DAL(int id_cart, string week_order)
                => (Id_cart, Week_order) = (id_cart, week_order);

        public Globlal_cart_DAL(int id,int id_cart, string week_order)
                => (ID,Id_cart, Week_order) = (id,id_cart, week_order);

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into supplier(id_cart,week_order,id)"
                                + " values (@id_cart, @week_order,@id )";

                commande.Parameters.Add(new SqlParameter("@id_cart", Id_cart));
                commande.Parameters.Add(new SqlParameter("@week_order", Week_order));
                commande.Parameters.Add(new SqlParameter("@id", ID));

                commande.ExecuteNonQuery();
            }
        }
    }
}