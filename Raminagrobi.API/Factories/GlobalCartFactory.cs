using Raminagrobis.Api.Contracts.Requests;
using Raminagrobis.Api.Contracts.Responses;
using Raminagrobis.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raminagrobis.Api.Factories
{
    public static class GlobalCartFactory
    {
        public static GlobalCartResponse ToResponse(this GlobalCartMetier dto)
        {
            if (dto == null)
                return null;

            return new GlobalCartResponse
            {
                ID = dto.ID,
                IdCart = dto.Id_cart,
                WeekOrder = dto.Week_order
            };
        }

        public static GlobalCartMetier ToDto(this GlobalCartRequest request)
        {
            if (request == null)
                return null;

            return new GlobalCartMetier(
                request.ID,
                request.IdCart,
                request.WeekOrder
            );
        }
    }
}
