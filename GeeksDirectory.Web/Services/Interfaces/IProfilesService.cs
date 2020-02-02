#pragma warning disable CA1716

using GeeksDirectory.SharedTypes.Models;
using GeeksDirectory.SharedTypes.Responses;

using System.Threading.Tasks;

namespace GeeksDirectory.Web.Services.Interfaces
{
    public interface IProfilesService
    {
        GeekProfileResponse Get(int profileId);

        GeekProfileResponsesKit Get(int limit, int offset, string? orderBy, string? orderDirection);

        GeekProfileResponse Get(string userName);

        GeekProfileResponsesKit Search(string query, int limit, int offset, string? orderBy, string? orderDirection);

        GeekProfileResponse Update(string userName, GeekProfileModel model);

        Task<GeekProfileResponse> AddAsync(CreateGeekProfileModel model);
    }
}