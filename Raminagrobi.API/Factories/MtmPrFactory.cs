using Raminagrobis.Api.Contracts.Requests;
using Raminagrobis.Api.Contracts.Responses;
using Raminagrobis.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raminagrobis.Api.Factories
{
    public static class MtmPrFactory
    {
        public static MtmPrResponse ToResponse(this MtmPrMetier dto)
        {
            if (dto == null)
                return null;

            return new MtmPrResponse
            {
                ID = dto.ID,
                IdReferences = dto.Id_references,
                IdSupplier = dto.Id_supplier
            };
        }

        public static MtmPrMetier ToDto(this MtmPrRequest request)
        {
            if (request == null)
                return null;

            return new MtmPrMetier(
                request.ID,
                request.IdReferences,
                request.IdSupplier
            );
        }
    }
}
