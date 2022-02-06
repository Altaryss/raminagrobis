using Raminagrobis.Api.Contracts.Requests;
using Raminagrobis.Api.Contracts.Responses;
using Raminagrobis.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raminagrobis.Api.Factories
{
    public static class CartDetailsFactory
    {
        public static CartDetailsResponse ToResponse(this CartDetailsMetier dto)
        {
            if (dto == null)
                return null;

            return new CartDetailsResponse
            {
                IdCart = dto.IdCart,
                IdReferences = dto.IdReferences,
                IdGlobalDetails = dto.IdGlobalDetails,
                Quantity = dto.Quantity
            };
        }

        public static CartDetailsMetier ToDto(this CartDetailsRequest request)
        {
            if (request == null)
                return null;

            return new CartDetailsMetier(
                request.IdCart,
                request.IdReferences,
                request.IdGlobalDetails,
                request.Quantity
            );
        }
    }
}
