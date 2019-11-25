using GeeksDirectory.Data.Entities;

using System.Collections.Generic;

namespace GeeksDirectory.Data.Repositories.Interfaces
{
    public interface IProfilesRepository
    {
        void Add(GeekProfile profile);

        GeekProfile Get(int id);

        GeekProfile Get(string userName);

        IEnumerable<GeekProfile> Get(int limit, int offset);

        IEnumerable<GeekProfile> Search(string searchQuery);

        void Update(GeekProfile profile);

        int Total();
    }
}