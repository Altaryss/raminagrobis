using Raminagrobi.Api.Contracts.Requests;
using Raminagrobi.Api.Contracts.Responses;
using Raminagrobi.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raminagrobi.Api.Factories
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
                Create_at = dto.CreateAt,
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
