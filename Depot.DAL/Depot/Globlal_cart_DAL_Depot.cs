using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
namespace Depot.DAL.Depot
{
    public class Globlal_cart_DAL_Depot : Depot_DAL<Globlal_cart_DAL>
    {
        public override List<Globlal_cart_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id_cart, week_order, id from global_cart";
            var reader = commande.ExecuteReader();

            var global_cart_list = new List<Globlal_cart_DAL>();

            while (reader.Read())
            {
                var add = new Globlal_cart_DAL ( reader.GetInt32(0), reader.GetString(1) );
                global_cart_list.Add (add);
            }

            DetruireConnexionEtCommande();

            return global_cart_list;
        }

        public override Globlal_cart_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id_cart,week_order,id from global_cart where id=@]id";
            commande.Parameters.Add(new SqlParameter("@id", ID));

            var reader = commande.ExecuteReader();

            Globlal_cart_DAL response;

            if (reader.Read())
            {
                response = new Globlal_cart_DAL (reader.GetInt32(0),reader.GetString(1) );
            }
            else
            {
                throw new Exception($"pas d'id {ID} pour le panier Global");
            }

            DetruireConnexionEtCommande();
            return response;

        }

        public override Globlal_cart_DAL Insert(Globlal_cart_DAL item)
        {
            CreerConnexionEtCommande ();

            commande.CommandText = "insert into global_cart(week_order)" + "values (@week_order); select_identity()";
            commande.Parameters.Add(new SqlParameter("@week_order", item.Week_order));
            var id = Convert.ToInt32(commande.ExecuteScalar());

            item.ID = id;
            var d = new Cart_details_DAL();
            foreach (var i in item.Week_order)
            {
                i.IDcart_global = id;
                d.Insert(item);
            }

            DetruireConnexionEtCommande();

            return item;
        }

        public override Globlal_cart_DAL Update(Globlal_cart_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update global_cart SET week_order = @week_order where id = @id";
            commande.Parameters.Add (new SqlParameter("@week_order", item.Week_order));
            commande.Parameters.Add (new SqlParameter("@id", item.ID));

            var nb = (int)commande.ExecuteNonQuery();

            if (nb != 1)
            {
                throw new Exception($"impossible d'update Global_cart {item.ID}");
            }
            DetruireConnexionEtCommande ();

            return item;
        }

        public override void Delete(Globlal_cart_DAL item)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "delete from cart_details where id=@ID ";
            commande.Parameters.Add(new SqlParameter("ID", item.ID));

            if (commande.ExecuteNonQuery() == 0)
            {
                throw new Exception($"impossible de delete {item.ID} dans global cart");
            }
            DetruireConnexionEtCommande();
        }

    }
}