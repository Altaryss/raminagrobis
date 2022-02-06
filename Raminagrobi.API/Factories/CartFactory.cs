using Raminagrobis.Api.Contracts.Requests;
using Raminagrobis.Api.Contracts.Responses;
using Raminagrobis.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raminagrobis.Api.Factories
{
    public static class CartFactory
    {
        public static CartResponse ToResponse(this CartMetier dto)
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

        public static CartMetier ToDto(this CartRequest request)
        {
            if (request == null)
                return null;

            return new CartMetier(
                request.ID,
                request.IdMember,
                request.WeekOrder
            );
        }
    }
}
