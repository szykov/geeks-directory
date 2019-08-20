using GeeksDirectory.Data.Entities;
using GeeksDirectory.SharedTypes.Models;
using GeeksDirectory.Web.Services.Interfaces;

using System;
using System.Collections.Generic;

namespace GeeksDirectory.Web.Services
{
    public class ProfilesService : IProfilesService
    {
        public IEnumerable<GeekProfile> Get()
        {
            throw new NotImplementedException();
        }

        public GeekProfile Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GeekProfile> Search(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, ProfileModel profile)
        {
            throw new NotImplementedException();
        }

        public GeekProfile Add(ProfileModel profile)
        {
            throw new NotImplementedException();
        }
    }
}
