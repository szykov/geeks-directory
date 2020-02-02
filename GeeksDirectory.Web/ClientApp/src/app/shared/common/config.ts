import { environment } from 'src/environments/environment';
import { CONFIG as CONFIG_DEVELOPMENT } from './config.development';
import { CONFIG as CONFIG_PRODUCTION } from './config.production';

export const CONFIG = environment.development ? CONFIG_DEVELOPMENT : CONFIG_PRODUCTION;
