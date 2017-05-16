'use strict';

import baseConfig from './base';

let config = {
    appEnv: 'dev',  // feel free to remove the appEnv property here
    apiUrl: 'http://127.0.0.1:5000/'
};

export default Object.freeze(Object.assign({}, baseConfig, config));
