﻿using Raminagrobis.DAL;
using Raminagrobi.Api.Contracts.Responses;
using Depot.DAL.Depot;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Raminagrobi.Metier.Services
{
    public class Cart
    {

        public static List<CartMetier> GetAll()
        {
            var all = new List<CartMetier>();
            var dep = new Cart_DAL_Depot();
            foreach (var item in dep.GetAll())
            {
                all.Add(new CartMetier(item.ID, item.Id_Member, item.Week_order));
            }
            return all;
        }

        public static CartMetier GetByID(int id)
        {
            var dep = new Cart_DAL_Depot();
            var cart = dep.GetByID(id);
            return new CartMetier(cart.ID, cart.Id_Member, cart.Week_order);
        }

        public static void Insert(CartResponse input)
        {
            var dep = new Cart_DAL_Depot();
            var cart = new Cart_DAL(input.IdMember, input.WeekOrder);
            dep.Insert(cart);
        }

        public static void Update(int id, CartResponse input)
        {
            var dep = new Cart_DAL_Depot();
            var cart = new Cart_DAL(id, input.IdMember, input.WeekOrder);
            dep.Update(cart);
        }

        public static void Delete(int id)
        {
            Cart_DAL cart;
            Cart_DAL_Depot dep = new Cart_DAL_Depot();
            cart = dep.GetByID(id);
            dep.Delete(cart);
        }
    }
}
