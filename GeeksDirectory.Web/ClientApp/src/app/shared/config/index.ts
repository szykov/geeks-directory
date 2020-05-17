import { environment } from 'src/environments/environment';
import { API as API_DEVELOPMENT } from './api-development.config';
import { API as API_PRODUCTION } from './api-production.config';
import { ANIMATION } from './anitmation.config';

const API = environment.development ? API_DEVELOPMENT : API_PRODUCTION;
export const CONFIG = {
	prefix: 'gd',
	mobileWidth: '600px',
	gitHubUrl: 'https://github.com/szykov/GeeksDirectory',
	specsUrl: 'https://redocly.github.io/redoc/?url=http://geeks-directory.azurewebsites.net/swagger/1.0/swagger.json',
	api: API,
	animation: ANIMATION
};
