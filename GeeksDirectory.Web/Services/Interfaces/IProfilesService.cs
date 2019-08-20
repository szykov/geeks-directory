using System.Collections.Generic;

using GeeksDirectory.Data.Entities;
using GeeksDirectory.SharedTypes.Models;

namespace GeeksDirectory.Web.Services.Interfaces
{
    public interface IProfilesService
    {
        GeekProfile Get(int id);

        IEnumerable<GeekProfile> Get();

        IEnumerable<GeekProfile> Search(string searchQuery);

        void Update(int id, ProfileModel profile);

        GeekProfile Add(ProfileModel profile);
    }
}