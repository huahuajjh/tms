var VueRouter = require('../js/lib/vueRouter/vue-router.js');

import { userCookie } from '../js/helpers/cookieData.js';
import routerMap from './router-url.js';

var router = new VueRouter()
router.map(routerMap)
// 验证拦截
router.beforeEach(function (transition) {
    //判断是否已经登录
    if (transition.to.path != "/401" && !userCookie.get()) {
        transition.redirect("401")
    } else if (!transition.to.matched || !transition.to.matched.length) { //判断页面是否存在
        transition.abort();
    } else {
        transition.next()
    }
})
export default router
