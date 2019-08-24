export let CONFIG = {
    ignoreConneciton: true,
    connection: {
        protocol: 'http',
        hostName: 'localhost',
        port: '5000',
        rootAddress: 'api',
        endpoints: {
            getProfiles: 'profiles',
            getProfile: 'profiles/{0}',
            registerProfile: 'profiles',
            updateProfile: 'profiles/{0}',
            getSkill: 'profiles/{0}/skills',
            addSkill: 'profiles/{0}/skills',
            setSkillScore: 'profiles/{0}/skills/{1}'
        }
    }
};
