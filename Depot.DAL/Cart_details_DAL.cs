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

        public Cart_details_DAL()
        {

        }

        public Cart_details_DAL(int id_cart, int id_references, int id_global_details , int quantity) 
                => (Id_cart, Id_references, Id_global_details, Quantity) = (id_cart, id_references, id_global_details, quantity);

        public Cart_details_DAL(int id,int id_cart, int id_references, int id_global_details, int quantity)
                => (ID, Id_cart, Id_references, Id_global_details, Quantity) = (id, id_cart, id_references, id_global_details, quantity);
    }
}