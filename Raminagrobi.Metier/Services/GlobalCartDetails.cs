using Raminagrobis.DAL;
using Raminagrobis.Api.Contracts.Responses;
using Depot.DAL.Depot;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Raminagrobis.Metier;

namespace Raminagrobi.Metier.Services
{
    public class GlobalCartDetails
    {
        public List<GlobalCartDetailsMetier> GetAll()
        {
            var all = new List<GlobalCartDetailsMetier>();
            var dep = new Globlal_cart_details_DAL_Depot();
            foreach (var item in dep.GetAll())
            {
                all.Add(new GlobalCartDetailsMetier(item.ID, item.Id_global_cart, item.Id_references, item.Quantity));
            }
            return all;
        }

        public GlobalCartDetailsMetier GetByID(int id)
        {
            var dep = new Globlal_cart_details_DAL_Depot();
            var globalcart = dep.GetByID(id);
            return new GlobalCartDetailsMetier(globalcart.ID, globalcart.Id_global_cart, globalcart.Id_references, globalcart.Quantity);
        }

        public void Insert(GlobalCartDetailsResponse input)
        {
            var dep = new Globlal_cart_details_DAL_Depot();
            var globalcart = new Globlal_cart_details_DAL(input.IdGlobalCart, input.IdReferences, input.Quantity);
            dep.Insert(globalcart);
        }

        public void Update(int id, GlobalCartDetailsResponse input)
        {
            var dep = new Globlal_cart_details_DAL_Depot();
            var globalcart = new Globlal_cart_details_DAL(id, input.IdGlobalCart, input.IdReferences, input.Quantity);
            dep.Update(globalcart);
        }

        public static void Delete(int id)
        {
            Globlal_cart_details_DAL globalcart;
            Globlal_cart_details_DAL_Depot dep = new Globlal_cart_details_DAL_Depot();
            globalcart = dep.GetByID(id);
            dep.Delete(globalcart);
        }
    }
}
