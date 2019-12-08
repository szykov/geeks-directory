﻿using GeeksDirectory.Data.Entities;
using GeeksDirectory.SharedTypes.Classes;

using System.Collections.Generic;

namespace GeeksDirectory.Data.Repositories.Interfaces
{
    public interface IProfilesRepository
    {
        void Add(GeekProfile profile);

        GeekProfile GetProfileById(int id);

        GeekProfile GetProfileByUserName(string userName);

        IEnumerable<GeekProfile> GetProfiles(QueryOptions queryOptions);

        IEnumerable<GeekProfile> Search(QueryOptions queryOptions, out int total);

        void Update(GeekProfile profile);

        int Total();
    }
}