require("./base/base.js");

Vue.config.silent = true;

import { userCookie } from '../js/helpers/cookieData.js';

if(userCookie.get()) {
    location.href = "./main.html";
} else {
    new Vue(require("../template/login.vue"));
}