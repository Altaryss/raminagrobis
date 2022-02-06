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



    }
}