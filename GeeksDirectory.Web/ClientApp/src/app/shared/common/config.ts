import { environment } from 'src/environments/environment';
import { CONFIG as CONFIG_DEVELOPMENT } from './api-development.config';
import { CONFIG as CONFIG_PRODUCTION } from './api-production.config';

export const CONFIG = environment.development ? CONFIG_DEVELOPMENT : CONFIG_PRODUCTION;
