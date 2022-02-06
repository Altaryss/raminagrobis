using Raminagrobis.DAL;
using Raminagrobi.Api.Contracts.Responses;
using Depot.DAL.Depot;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Raminagrobi.Metier.Services
{
    internal class Price
    {
        public static List<PriceMetier> GetAll()
        {
            var all = new List<PriceMetier>();
            var dep = new Price_DAL_Depot();
            foreach (var item in dep.GetAll())
            {
                all.Add(new PriceMetier(item.ID, item.Id_global_details, item.Id_supplier, item.Price));
            }
            return all;
        }

        public static PriceMetier GetByID(int id)
        {
            var dep = new Price_DAL_Depot();
            var price = dep.GetByID(id);
            return new PriceMetier(price.ID, price.Id_global_details, price.Id_supplier, price.Price);
        }

        public static void Insert(PriceResponse input)
        {
            var dep = new Price_DAL_Depot();
            var price = new Price_DAL(input.Id_global_details, input.Id_supplier, input.Price);
            dep.Insert(price);
        }

        public static void Update(int id, PriceResponse input)
        {
            var dep = new Price_DAL_Depot();
            var price = new Price_DAL(id, input.Id_global_details, input.Id_supplier, input.Price);
            dep.Update(price);
        }

        public static void Delete(int id)
        {
            Price_DAL price;
            Price_DAL_Depot dep = new Price_DAL_Depot();
            price = dep.GetByID(id);
            dep.Delete(price);
        }
    }
}
