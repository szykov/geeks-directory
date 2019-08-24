using GeeksDirectory.Data.Entities;

using System.Collections.Generic;

namespace GeeksDirectory.Data.Repositories.Interfaces
{
    public interface IProfilesRepository
    {
        void Add(GeekProfile profile);

        GeekProfile Get(int id);

        IEnumerable<GeekProfile> Get(int take, int skip);

        IEnumerable<GeekProfile> Search(string searchQuery);

        void Update(GeekProfile profile);
    }
}