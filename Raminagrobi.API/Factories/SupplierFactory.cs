using Raminagrobis.Api.Contracts.Requests;
using Raminagrobis.Api.Contracts.Responses;
using Raminagrobis.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raminagrobis.Api.Factories
{
    public static class SupplierFactory
    {
        public static SupplierResponse ToResponse(this SupplierMetier dto)
        {
            if (dto == null)
                return null;

            return new SupplierResponse
            {
                ID = dto.ID,
                Company = dto.Company,
                Civility = dto.Civility,
                Surname = dto.Surname,
                Name = dto.Name,
                Email = dto.Email,
                Address = dto.Address,
                CreatedAt = dto.Create_at,
            };
        }

        public static SupplierMetier ToDto(this SupplierRequest request)
        {
            if (request == null)
                return null;

            return new SupplierMetier(
                request.ID,
                request.Company,
                request.Civility,
                request.Surname,
                request.Name,
                request.Email,
                request.Address,
                request.CreatedAt
            );
        }
    }
}
