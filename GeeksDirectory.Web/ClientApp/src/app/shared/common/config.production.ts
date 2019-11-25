export let CONFIG = {
    pagination: {
        mobile: 5,
        tablet: 10,
        desktop: 20
    },
    ignoreConneciton: true,
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
