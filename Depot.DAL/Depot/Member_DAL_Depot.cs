using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Depot.DAL.Depot
{
    public class Member_DAL_Depot : Depot_DAL<Member_DAL>
    {
        public override List<Member_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT id,company,civility,surname,name,email,address,create_at FROM member";
            var reader = commande.ExecuteReader();

            var response = new List<Member_DAL>();

            while (reader.Read())
            {
                var member = new Member_DAL(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetString(4),
                reader.GetString(5),
                reader.GetString(6),
                reader.GetDateTime(7)
                );

                response.Add(member);
            }

            DetruireConnexionEtCommande();

            return response;
        }

        public override Member_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT id,company,civility,surname,name,email,address,create_at FROM member Where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();

            Member_DAL rep;

            if (reader.Read())
            {
                rep = new Member_DAL(


                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetString(4),
                reader.GetString(5),
                reader.GetString(6),
                reader.GetDateTime(7)
                    );
            }
            else
            {
                throw new Exception($"pas d'adheran à l'id {ID}");
            }

            DetruireConnexionEtCommande();

            return rep;


        }

        public override Member_DAL Insert(Member_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO member (company,civility,surname,name,email,address,create_at)" + "VALUES (@company,@civility,@surname,@name,@email,@address,@create_at); select scope_identity()";

            commande.Parameters.Add(new SqlParameter("@company", item.Company));
            commande.Parameters.Add(new SqlParameter("@civility", item.Civility));
            commande.Parameters.Add(new SqlParameter("@surname", item.Surname));
            commande.Parameters.Add(new SqlParameter("@name", item.Name));
            commande.Parameters.Add(new SqlParameter("@email", item.Email));
            commande.Parameters.Add(new SqlParameter("@address", item.Address));
            commande.Parameters.Add(new SqlParameter("@create_at", item.Create_at));

            Member_DAL result = null;
            if (commande.ExecuteNonQuery() > 0)
                result = item;

            DetruireConnexionEtCommande();

            return result;
        }

        public override Member_DAL Update(Member_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE member set company = @company, civility = @civility, surname = @surname, name = @name, email = @email, address = @address, create_at = @create_at WHERE id = @id";

            commande.Parameters.Add(new SqlParameter("@company", item.Company));
            commande.Parameters.Add(new SqlParameter("@civility", item.Civility));
            commande.Parameters.Add(new SqlParameter("@surname", item.Surname));
            commande.Parameters.Add(new SqlParameter("@name", item.Name));
            commande.Parameters.Add(new SqlParameter("@email", item.Email));
            commande.Parameters.Add(new SqlParameter("@address", item.Address));
            commande.Parameters.Add(new SqlParameter("@create_at", item.Create_at));
            commande.Parameters.Add(new SqlParameter("@id", item.ID));

            Member_DAL result = null;
            if (commande.ExecuteNonQuery() > 0)
                result = item;

            DetruireConnexionEtCommande();

            return result;
        }

        public override void Delete(Member_DAL item)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "delete from member where id = @ID";
            commande.Parameters.Add(new SqlParameter("@ID", item.ID));

            if (commande.ExecuteNonQuery() == 0)
                throw new Exception($"Aucune ID correspondent a {item.ID} dans la table Member");

            DetruireConnexionEtCommande();
        }


    }
}