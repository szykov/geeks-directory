using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Domain.Classes;

using System.Collections.Generic;

namespace GeeksDirectory.Domain.Interfaces
{
    public interface IProfilesRepository
    {
        void Add(GeekProfile profile);

        GeekProfile? GetProfileById(int id);

        GeekProfile? GetProfileByUserName(string userName);

        bool UserExists(string userName);

        IEnumerable<GeekProfile> GetProfiles(QueryOptions queryOptions);

        IEnumerable<GeekProfile> Search(QueryOptions queryOptions, out int total);

        void Update(GeekProfile profile);

        int Total();
    }
}