using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Depot.DAL.Depot
{
    public class Price_DAL_Depot : Depot_DAL<Price_DAL>
    {
        public override List<Price_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, id_global_details, id_supplier, price from price";
            var reader = commande.ExecuteReader();

            var nb = new List<Price_DAL>();

            while (reader.Read())
            {
                var add = new Price_DAL(reader.GetInt32(0), reader.GetInt32(1), reader.GetFloat(2));
                nb.Add(add);
            }

            DetruireConnexionEtCommande();

            return nb;
        }

        public override Price_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, id_global_details, id_supplier, price from price where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();

            Price_DAL response;

            if (reader.Read())
            {
                response = new Price_DAL(reader.GetInt32(0), reader.GetInt32(1), reader.GetFloat(2));
            }
            else
            {
                throw new Exception($"pas d'id {ID} pour le price");
            }
            DetruireConnexionEtCommande();

            return response;
        }

        public override Price_DAL Insert(Price_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into price(id_global_details, id_supplier, price)" + "value (@id_global_details, @id_supplier, @price); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@id_global_details", item.Id_global_details));
            commande.Parameters.Add(new SqlParameter("@id_supplier", item.Id_supplier));
            commande.Parameters.Add(new SqlParameter("@price", item.Price));
            commande.ExecuteNonQuery();

            DetruireConnexionEtCommande();

            return item;
        }
        public override Price_DAL Update(Price_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update price SET id_global_details = @id_global_details, id_supplier = @id_supplier, price = @price where id = @id";
            commande.Parameters.Add(new SqlParameter("@id_global_details", item.Id_global_details));
            commande.Parameters.Add(new SqlParameter("@id_supplier", item.Id_supplier));
            commande.Parameters.Add(new SqlParameter("@price", item.Price));
            commande.Parameters.Add(new SqlParameter("@id", item.ID));

            var nb = commande.ExecuteNonQuery();

            if (nb != 1)
            {
                throw new Exception($"impossible d'update price {item.ID}");
            }

            DetruireConnexionEtCommande();

            return item;
        }

        public override void Delete(Price_DAL item)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "delete from cart_details where id=@ID ";
            commande.Parameters.Add(new SqlParameter("ID", item.ID));

            if (commande.ExecuteNonQuery() == 0)
            {
                throw new Exception($"impossible de delete {item.ID} dans Price");
            }
            DetruireConnexionEtCommande();
        }


    }


}