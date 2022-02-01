using System;
using System.Data.SqlClient;

namespace Raminagrobis.DAL
{
    public class Cart_DAL
    {
        public int Id_Member { get; private set; }
        public string Week_order { get; private set; }

        public int ID { get; set; }

        public Cart_DAL(int id_member, string week_order)
                => (Id_Member, Week_order) = (id_member, week_order);

        public Cart_DAL(int id,int id_member, string week_order)
                => (ID, Id_Member, Week_order) = (id, id_member, week_order);

        }
    }
}