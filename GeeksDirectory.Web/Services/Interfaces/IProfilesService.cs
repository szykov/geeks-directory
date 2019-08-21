using GeeksDirectory.SharedTypes.Models;
using GeeksDirectory.SharedTypes.Responses;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeeksDirectory.Web.Services.Interfaces
{
    public interface IProfilesService
    {
        GeekProfileResponse Get(int profileId);

        IEnumerable<GeekProfileResponse> Get(int take, int skip);

        IEnumerable<GeekProfileResponse> Search(string searchQuery);

        void Update(int profileId, GeekProfileModel model);

        Task<GeekProfileResponse> AddAsync(CreateGeekProfileModel model);
    }
}