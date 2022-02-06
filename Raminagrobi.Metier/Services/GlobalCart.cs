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
    public class GlobalCart
    {
        public static List<GlobalCartMetier> GetAll()
        {
            var all = new List<GlobalCartMetier>();
            var dep = new Globlal_cart_DAL_Depot();
            foreach (var item in dep.GetAll())
            {
                all.Add(new GlobalCartMetier(item.ID, item.Id_cart, item.Week_order));
            }
            return all;
        }

        public static GlobalCartMetier GetByID(int id)
        {
            var dep = new Globlal_cart_DAL_Depot();
            var globalcart = dep.GetByID(id);
            return new GlobalCartMetier(globalcart.ID, globalcart.Id_cart, globalcart.Week_order);
        }

        public static void Insert(GlobalCartResponse input)
        {
            var dep = new Globlal_cart_DAL_Depot();
            var globalcart = new Globlal_cart_DAL(input.Id_cart, input.Week_order);
            dep.Insert(globalcart);
        }

        public static void Update(int id, GlobalCartResponse input)
        {
            var dep = new Globlal_cart_DAL_Depot();
            var globalcart = new Globlal_cart_DAL(id, input.Id_cart, input.Week_order);
            dep.Update(globalcart);
        }

        public static void Delete(int id)
        {
            Globlal_cart_DAL globalcart;
            Globlal_cart_DAL_Depot dep = new Globlal_cart_DAL_Depot();
            globalcart = dep.GetByID(id);
            dep.Delete(globalcart);
        }
    }
}
