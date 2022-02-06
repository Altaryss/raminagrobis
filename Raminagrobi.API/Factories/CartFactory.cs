using Raminagrobi.Api.Contracts.Responses;
using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raminagrobi.Api.Factories
{
    public static class CartFactory
    {
        public static CartResponse ToResponse(this Cart_DAL dto)
        {
            if (dto == null)
                return null;

            return new CartResponse
            {
                ID = dto.ID,
                IdMember = dto.Id_Member,
                WeekOrder = dto.Week_order
            };
        }
    }
}
