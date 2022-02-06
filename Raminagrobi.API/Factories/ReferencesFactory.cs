using Raminagrobis.Api.Contracts.Requests;
using Raminagrobis.Api.Contracts.Responses;
using Raminagrobis.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raminagrobis.Api.Factories
{
    public static class ReferencesFactory
    {
        public static ReferencesResponse ToResponse(this ReferencesMetier dto)
        {
            if (dto == null)
                return null;

            return new ReferencesResponse
            {
                ID = dto.ID,
                References = dto.References,
                Wording = dto.Wording,
                Brand = dto.Brand,
                Status = dto.Status
            };
        }

        public static ReferencesMetier ToDto(this ReferencesRequest request)
        {
            if (request == null)
                return null;

            return new ReferencesMetier(
                request.ID,
                request.References,
                request.Wording,
                request.Brand,
                request.Status
            );
        }
    }
}
