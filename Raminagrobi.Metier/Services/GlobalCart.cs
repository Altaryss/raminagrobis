using Raminagrobis.DAL;
using Raminagrobis.Api.Contracts.Responses;
using Depot.DAL.Depot;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Raminagrobis.Metier.Services
{
    public class GlobalCart
    {
        public List<GlobalCartMetier> GetAll()
        {
            var all = new List<GlobalCartMetier>();
            var dep = new Globlal_cart_DAL_Depot();
            foreach (var item in dep.GetAll())
            {
                all.Add(new GlobalCartMetier(item.ID, item.Id_cart, item.Week_order));
            }
            return all;
        }

        public GlobalCartMetier GetByID(int id)
        {
            var dep = new Globlal_cart_DAL_Depot();
            var globalcart = dep.GetByID(id);
            return new GlobalCartMetier(globalcart.ID, globalcart.Id_cart, globalcart.Week_order);
        }

        public void Insert(GlobalCartResponse input)
        {
            var dep = new Globlal_cart_DAL_Depot();
            var globalcart = new Globlal_cart_DAL(input.IdCart, input.WeekOrder);
            dep.Insert(globalcart);
        }

        public void Update(int id, GlobalCartResponse input)
        {
            var dep = new Globlal_cart_DAL_Depot();
            var globalcart = new Globlal_cart_DAL(id, input.IdCart, input.WeekOrder);
            dep.Update(globalcart);
        }

        public void Delete(int id)
        {
            Globlal_cart_DAL globalcart;
            Globlal_cart_DAL_Depot dep = new Globlal_cart_DAL_Depot();
            globalcart = dep.GetByID(id);
            dep.Delete(globalcart);
        }
    }
}
