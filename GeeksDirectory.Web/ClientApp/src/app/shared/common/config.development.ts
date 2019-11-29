export let CONFIG = {
    gitHubUrl: 'https://github.com/szykov/GeeksDirectory',
    ignoreConneciton: false,
    connection: {
        protocol: 'http',
        hostName: 'localhost',
        port: '5000',
        apiRoot: 'api',
        endpoints: {
            getToken: 'connect/token',
            getProfiles: 'api/profiles',
            getProfile: 'api/profiles/{profileId}',
            getMyProfile: 'api/profiles/me',
            registerProfile: 'api/profiles',
            updatePersonalProfile: 'api/profiles/me',
            getSkill: 'api/profiles/{profileId}/skills',
            addSkill: 'api/profiles/{profileId}/skills',
            setSkillScore: 'api/profiles/{profileId}/skills/{skillName}/score'
        }
    }
};
