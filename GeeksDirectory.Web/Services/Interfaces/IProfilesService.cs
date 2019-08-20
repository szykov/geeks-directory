using System.Collections.Generic;
using System.Threading.Tasks;

using GeeksDirectory.Data.Entities;
using GeeksDirectory.SharedTypes.Models;

namespace GeeksDirectory.Web.Services.Interfaces
{
    public interface IProfilesService
    {
        GeekProfile Get(int id);

        IEnumerable<GeekProfile> Get(int take, int skip);

        IEnumerable<GeekProfile> Search(string searchQuery);

        void Update(int id, GeekProfileModel profile);

        Task<GeekProfile> AddAsync(GeekProfileModel profile);
    }
}