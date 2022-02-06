using Raminagrobis.Api.Contracts.Requests;
using Raminagrobis.Api.Contracts.Responses;
using Raminagrobis.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raminagrobis.Api.Factories
{
    public static class PriceFactory
    {
        public static PriceResponse ToResponse(this PriceMetier dto)
        {
            if (dto == null)
                return null;

            return new PriceResponse
            {
                ID = dto.ID,
                IdGlobalDetails = dto.Id_global_details,
                IdSupplier = dto.Id_supplier,
                Price = dto.Price
            };
        }

        public static PriceMetier ToDto(this PriceRequest request)
        {
            if (request == null)
                return null;

            return new PriceMetier(
                request.ID,
                request.IdGlobalDetails,
                request.IdSupplier,
                request.Price
            );
        }
    }
}
