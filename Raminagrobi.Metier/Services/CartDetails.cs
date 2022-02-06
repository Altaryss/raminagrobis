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
    public class CartDetails
    {

        public List<CartDetailsMetier> GetAll()
        {
            var all = new List<CartDetailsMetier>();
            var dep = new Cart_details_DAL_Depot();
            foreach (var item in dep.GetAll())
            {
                all.Add(new CartDetailsMetier(item.ID, item.Id_cart, item.Id_references, item.Id_global_details, item.Quantity));
            }
            return all;
        }

        public CartDetailsMetier GetByID(int id)
        {
            var dep = new Cart_details_DAL_Depot();
            var cart = dep.GetByID(id);
            return new CartDetailsMetier(cart.Id_cart, cart.Id_references, cart.Id_global_details, cart.Quantity);
        }

        public void Insert(CartDetailsResponse input)
        {
            var dep = new Cart_details_DAL_Depot();
            var cart = new Cart_details_DAL(input.IdCart, input.IdReferences, input.IdGlobalDetails, input.Quantity);
            dep.Insert(cart);
        }

        public void Update(int id, CartDetailsResponse input)
        {
            var dep = new Cart_details_DAL_Depot();
            var cart = new Cart_details_DAL(input.IdCart, input.IdReferences, input.IdGlobalDetails, input.Quantity);
            dep.Update(cart);
        }

        public void Delete(int id)
        {
            Cart_details_DAL cart;
            Cart_details_DAL_Depot dep = new Cart_details_DAL_Depot();
            cart = dep.GetByID(id);
            dep.Delete(cart);
        }
    }
}
