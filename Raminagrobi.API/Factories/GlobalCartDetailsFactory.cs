using Raminagrobis.Api.Contracts.Requests;
using Raminagrobis.Api.Contracts.Responses;
using Raminagrobis.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raminagrobis.Api.Factories
{
    public static class GlobalCartDetailsFactory
    {
        public static GlobalCartDetailsResponse ToResponse(this GlobalCartDetailsMetier dto)
        {
            if (dto == null)
                return null;

            return new GlobalCartDetailsResponse
            {
                ID = dto.ID,
                IdGlobalCart = dto.Id_global_cart,
                IdReferences = dto.Id_references,
                Quantity = dto.Quantity
            };
        }

        public static GlobalCartDetailsMetier ToDto(this GlobalCartDetailsRequest request)
        {
            if (request == null)
                return null;

            return new GlobalCartDetailsMetier(
                request.ID,
                request.IdGlobalCart,
                request.IdReferences,
                request.Quantity
            );
        }
    }
}
