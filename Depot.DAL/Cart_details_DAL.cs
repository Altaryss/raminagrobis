using System;
using System.Data.SqlClient;

namespace Raminagrobis.DAL
{
    public class Cart_details_DAL
    {
        public int Id_cart { get; private set; }
        public int Id_references { get; private set; }
        public int Id_global_details { get; private set; }
        public int Quantity { get; private set; }
        public int ID { get; set; }

        public Cart_details_DAL(int id_cart, int id_references, int id_global_details , int quantity) 
                => (Id_cart, Id_references, Id_global_details, Quantity) = (id_cart, id_references, id_global_details, quantity);

        public Cart_details_DAL(int id,int id_cart, int id_references, int id_global_details, int quantity)
                => (ID, Id_cart, Id_references, Id_global_details, Quantity) = (id, id_cart, id_references, id_global_details, quantity);

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into supplier(id_cart,id_references,id_global_details,quantity,id)"
                                + " values (@id_cart, @id_references, @id_global_details, @quantity, @id )";

                commande.Parameters.Add(new SqlParameter("@id_cart", Id_cart));
                commande.Parameters.Add(new SqlParameter("@id_references", Id_references));
                commande.Parameters.Add(new SqlParameter("@id_global_details", Id_global_details));
                commande.Parameters.Add(new SqlParameter("@quantity", Quantity));
                commande.Parameters.Add(new SqlParameter("@id", ID));

                commande.ExecuteNonQuery();
            }
        }
    }
}