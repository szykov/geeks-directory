using GeeksDirectory.SharedTypes.Models;
using GeeksDirectory.SharedTypes.Responses;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeeksDirectory.Web.Services.Interfaces
{
    public interface IProfilesService
    {
        GeekProfileResponse Get(int profileId);

        GeekProfileResponses Get(int limit, int offset);

        GeekProfileResponse Get(string userName);

        IEnumerable<GeekProfileResponse> Search(string searchQuery);

        GeekProfileResponse Update(string userName, GeekProfileModel model);

        Task<GeekProfileResponse> AddAsync(CreateGeekProfileModel model);
    }
}