import { environment } from 'src/environments/environment';

let CONFIG_DEVELOPMENT = {
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

let CONFIG_PRODUCTION = {
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

export let CONFIG = environment.development ? CONFIG_DEVELOPMENT : CONFIG_PRODUCTION;
