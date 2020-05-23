# GeeksDirectory

Web site for assessment of competence in technologies.

## Stack

- Back-End: .NET Core 3.0 Web API;
- Front-End: Angular 9 + Angular Material;
- Storage: Sqlite + EF Core (Code First);
- Authentification: OpenIdDict (OAuth JWT);
- Logging: NLog

## Demo

http://geeks-directory.azurewebsites.net/ (on first load is warming up)

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
3. Use `ng serve` or `npm run start` to run angular;
4. To run back-end use `dotnet run` or use Visual Studio;

## TODO:

1. ~~Add Web API methods.~~
2. ~~Make database with EF Core code-first;~~
3. ~~Add API model validations;~~
4. ~~Add Oauth Token authentification;~~
5. ~~Add SignIn page;~~
6. ~~Add Registration page;~~
7. ~~Add View Profile page;~~
8. ~~Add Cookie/LocalStorage support;~~
9. ~~Add Edit Profile page~~;
10. ~~Add Skills adding functionality~~;
11. ~~Add Skills assessment functionality~~;
12. ~~Update layout for small screen support~~;
13. ~~Search functionality on front-end side~~;
14. ~~Limit editing profile to personal one on server side;~~
15. ~~Add more validations for password and skill's name~~;
16. Get previous score when evaluate skill;
17. Add tests;
18. ~~Refactoring / code review~~;
19. ~~Seed database~~;
20. ~~Add pagination~~;
21. Add OpenApi;
