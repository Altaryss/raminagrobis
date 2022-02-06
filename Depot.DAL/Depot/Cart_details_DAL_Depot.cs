using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Depot.DAL.Depot
{
    public class Cart_details_DAL_Depot : Depot_DAL<Cart_details_DAL>
    {
        public override List<Cart_details_DAL> GetAll()
        {
            CreerConnexionEtCommande();
            commande.CommandText = "select id_cart, id_references, id_global_details, quantity from cart_details";


            var reader = commande.ExecuteReader();
            var cart_list = new List<Cart_details_DAL>();

            while (reader.Read())
            {
                var add = new Cart_details_DAL(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
                cart_list.Add(add);
            }
            DetruireConnexionEtCommande();

            return cart_list;
        }

        public override Cart_details_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, id_cart, id_references, id_global_details, quantity where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", ID));

            var reader = commande.ExecuteReader();

            Cart_details_DAL Response;

            if (reader.Read())
            {
                Response = new Cart_details_DAL(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
            }
            else
            {
                throw new Exception($"pas d'ID pour global Cart");
            }

            DetruireConnexionEtCommande();

            return Response;
        }

        public List<Cart_details_DAL> GetByCart(int id_cart)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, id_cart, id_references, id_global_details, quantity where id_cart=@id_cart";
            commande.Parameters.Add(new SqlParameter("@id_cart", id_cart));

            var reader = commande.ExecuteReader();

            var response = new List<Cart_details_DAL>();

            while (reader.Read())
            {
                var add = new Cart_details_DAL(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));

                response.Add(add);
            }

            DetruireConnexionEtCommande();

            return response;
        }

        public override Cart_details_DAL Insert(Cart_details_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into cart_details(id_cart,id_references,id_global_details,quantity)" + " values (@id_cart, @id_references, @id_global_details,  @quantity";
            commande.Parameters.Add(new SqlParameter("@id_cart", item.Id_cart));
            commande.Parameters.Add(new SqlParameter("@id_references", item.Id_references));
            commande.Parameters.Add(new SqlParameter("@id_global_details", item.Id_global_details));
            commande.Parameters.Add(new SqlParameter("@quantity", item.Quantity));
            item.ID = Convert.ToInt32(commande.ExecuteScalar());

            DetruireConnexionEtCommande();

            return item;
        }

        public override Cart_details_DAL Update(Cart_details_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update cart_details SET id_cart=@id_cart, id_references=@id_references, id_global_details=@id_global_details, quantity=@quantity where id = @id";
            commande.Parameters.Add(new SqlParameter("@id", item.ID));
            commande.Parameters.Add(new SqlParameter("@id_cart", item.Id_cart));
            commande.Parameters.Add(new SqlParameter("@id_references", item.Id_references));
            commande.Parameters.Add(new SqlParameter("@id_global_details", item.Id_global_details));
            commande.Parameters.Add(new SqlParameter("@quantity", item.Quantity));

            var nb = (int)commande.ExecuteNonQuery();

            if (nb != 1)
            {
                throw new Exception($"impossible d'update Cart_details {item.ID}");
            }
            DetruireConnexionEtCommande();

            return item;
        }

        public override void Delete(Cart_details_DAL item)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "delete from cart_details where id=@ID ";
            commande.Parameters.Add(new SqlParameter("@ID", item.ID));

            if(commande.ExecuteNonQuery() == 0)
            {
                throw new Exception($"impossible de delete {item.ID}");
            }
        }



    }
}