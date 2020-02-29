using System;

namespace GeeksDirectory.Infrastructure.Seed.Models
{
    internal class ProfilesSeedModel
    {
        public Guid Id { get; set; }

        public string? Email => String.IsNullOrEmpty(this.Name) && String.IsNullOrEmpty(this.Surname) ? default : 
            $"{this.Name?.ToLower()}.{this.Surname?.ToLower()}@mail.some";

        public string? NormalizedEmail => this.Email?.Normalize().ToUpperInvariant();

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string FullName => $"{this.Name} {this.Surname}";

        public string? City { get; set; }

        public string Password => "Pa$$w0rd";
    }
}
