using Raminagrobis.Api.Contracts.Requests;
using Raminagrobis.Api.Contracts.Responses;
using Raminagrobis.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raminagrobis.Api.Factories
{
    public static class MemberFactory
    {
        public static MemberResponse ToResponse(this MemberMetier dto)
        {
            if (dto == null)
                return null;

            return new MemberResponse
            {
                ID = dto.ID,
                Company = dto.Company,
                Civility = dto.Civility,
                Surname = dto.Surname,
                Name = dto.Name,
                Email = dto.Email,
                Address = dto.Address,
                CreatedAt = dto.CreateAt,
            };
        }

        public static MemberMetier ToDto(this MemberRequest request)
        {
            if (request == null)
                return null;

            return new MemberMetier(
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
