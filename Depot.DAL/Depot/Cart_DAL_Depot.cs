using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Depot.DAL.Depot
{
    public class Cart_DAL_Depot : Depot_DAL<Cart_DAL>
    {
        public override List<Cart_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            var reader = commande.ExecuteReader();

            var list_cart = new List<Cart_DAL>();

            while (reader.Read())
            {
                var rajouter = new Cart_DAL(reader.GetInt32(0), reader.GetString(1));
                list_cart.Add(rajouter);
            }

            DetruireConnexionEtCommande();
            return list_cart;
        }

        public override Cart_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, id_member, from Cart Where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();

            Cart_DAL rep;
            if (reader.Read())
            {
                rep = new Cart_DAL(reader.GetInt32(0), reader.GetString(1));
            }
            else
            {
                throw new Exception($"pas de fornisseur");
            }
            DetruireConnexionEtCommande();

            return rep;
        }

        public override Cart_DAL Insert(Cart_DAL cart)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into Panier (id_member)" + "values (@id_member); select scope_identity";
            commande.Parameters.Add(new SqlParameter("@id_member", cart.Id_Member));

            var id = Convert.ToInt32(commande.ExecuteScalar());

            cart.ID = id;
            var depot = commande.ExecuteNonQuery();
            foreach(var item in cart.Id_Member)
            {
                item.ID = id;
                depot.Insert(item);
            }

            DetruireConnexionEtCommande();

            return cart;
        }

        public override Cart_DAL Update(Cart_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update Panier SET id_member = @id_member where id =  @id";
            commande.Parameters.Add(new SqlParameter("@id_member", item.Id_Member));
            commande.Parameters.Add(new SqlParameter("@id", item.ID));

            var nb = (int)commande.ExecuteNonQuery();

            DetruireConnexionEtCommande();

            return item;
        }

        public override void Delete(Cart_DAL item)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "delet from Panier where ID =@ID";
            commande.Parameters.Add(new SqlParameter("@ID", item.ID));
            var reader = commande.ExecuteReader();

            DetruireConnexionEtCommande();
        }

    }
}