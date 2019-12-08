### Applying migrations
`dotnet ef migrations add XXXXXX -o "Migrations" -s "../GeeksDirectory.Web"`

`dotnet ef migrations remove -s "../GeeksDirectory.Web"`

`dotnet ef database update -s "../GeeksDirectory.Web"`

`dotnet ef database drop -s "../GeeksDirectory.Web"`