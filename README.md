# GeeksDirectory

Web site for assessment of competence in technologies.

## Stack

- Back-End: .NET Core 3.1 Web API;
- Front-End: Angular 9 + Angular Material;
- Storage: Sqlite + EF Core (Code First);
- Authentification: OpenIdDict (OAuth JWT);
- Logging: NLog

## Demo

http://geeks-directory.azurewebsites.net/

To login use profile's email and password. Password is always `Pa$$w0rd`.

## Functionality

- Non-authentificated user can see list of others profiles or search for them.
- User profile contains: Name, Surname, Middle Name, City, Email and etc.
- User can search by Name, Surname, Middle name, City.
- User can sign up and be authentificated.
- Authentificated user can add new skills and make assessment to existing ones.
- Score assessments for skills is limited to range between 0 to 5.
- Each skill can have multiple score assessments. Skill should have an average score.
- User is not allowed to remove skills.

## Build

1. Check `ConnectionStrings` in `appsettings.development.json`. <br />
   There will be created a new **sqlite** db when applied migrations;
2. Open terminal with the path of project `GeeksDirectory.Data`. <br />
   Update database with migrations `dotnet ef database update -s "../GeeksDirectory.Web"`;
3. Run angular in watch mode `ng serve` or `npm run start`;
4. Run in Visual Studio;
