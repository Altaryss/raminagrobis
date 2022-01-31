using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Depot.DAL.Depot
{
    public class Globlal_cart_details_DAL_Depot : Depot_DAL<Globlal_cart_details_DAL>
    {
        public override List<Globlal_cart_details_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id_global_cart, id_references, quantity, id from global_cart_details";
            var reader = commande.ExecuteReader();

            var nb = new List<Globlal_cart_details_DAL>();

            while (reader.Read())
            {
                var add = new Globlal_cart_details_DAL(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
                nb.Add(add);
            }

            DetruireConnexionEtCommande();

            return nb;
        }

        public List<Globlal_cart_details_DAL> GetByIdGlobalCart(int id_global_cart)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id_global_cart, id_references, quantity, id from global_cart_details where id_global_cart=@id_global_cart";
            commande.Parameters.Add(new SqlParameter("@id_global_cart", id_global_cart));
            var reader = commande.ExecuteReader();

            var nb = new List<Globlal_cart_details_DAL>();

            while (reader.Read())
            {
                var add = new Globlal_cart_details_DAL(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
                nb.Add(add);
            }

            DetruireConnexionEtCommande();

            return nb;
        }

        public override Globlal_cart_details_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id_global_cart, id_references, quantity, id from global_cart_details where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();

            Globlal_cart_details_DAL response;

            if (reader.Read())
            {
                response = new Globlal_cart_details_DAL(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
            }
            else
            {
                throw new Exception($"pas d'id {ID} pour le panier Global_Details");
            }
            DetruireConnexionEtCommande();

            return response;
        }

        public override Globlal_cart_details_DAL Insert(Globlal_cart_details_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into global_cart_details(id_global_cart, id_references, quantity)" + "value (@id_global_cart, @id_references, @quantity)";

            commande.Parameters.Add(new SqlParameter("@id_global_cart", item.Id_global_cart));
            commande.Parameters.Add(new SqlParameter("@id_references", item.Id_references));
            commande.Parameters.Add(new SqlParameter("@quantity", item.Quantity));
            commande.Parameters.Add(new SqlParameter("@id", item.ID));

            DetruireConnexionEtCommande();

            return item;
        }

        public override Globlal_cart_details_DAL Update(Globlal_cart_details_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update global_cart_details SET id_global_cart=@id_global_cart, id_references=@id_references, quantity=@quantity where id = @id";
            commande.Parameters.Add(new SqlParameter("@id_global_cart", item.Id_global_cart));
            commande.Parameters.Add(new SqlParameter("@id_references", item.Id_references));
            commande.Parameters.Add(new SqlParameter("@quantity", item.Quantity));
            commande.Parameters.Add(new SqlParameter ("@id", item.ID));

            var nb = (int)commande.ExecuteNonQuery();

            if (nb != 1)
            {
                throw new Exception($"impossible d'update Global_cart_details {item.ID}");
            }
            DetruireConnexionEtCommande();

            return item;

        }

        public override void Delete(Globlal_cart_details_DAL item)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "delete from cart_details where id=@ID ";
            commande.Parameters.Add(new SqlParameter("ID", item.ID));

            if (commande.ExecuteNonQuery() == 0)
            {
                throw new Exception($"impossible de delete  {item.ID} dans global_cart_details");
            }
            DetruireConnexionEtCommande();
        }


    }
}