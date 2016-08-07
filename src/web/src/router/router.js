var VueRouter = require('../js/lib/vueRouter/vue-router.js');

import { userCookie } from '../js/helpers/cookieData.js';
import routerMap from './router-url.js';
import global from '../js/globalMethod/global.js';

var router = new VueRouter()
router.map(routerMap)
// 验证拦截
router.beforeEach(function (transition) {
    //判断是否已经登录
    if (transition.to.path != "/401" && !userCookie.get()) {
        transition.redirect("401")
    } else if (!transition.to.matched || !transition.to.matched.length) { //判断页面是否存在
        transition.abort();
    } else if(transition.to.path != "/" && transition.to.path != "/401" && transition.to.path != "/404") {
        var permissions = global.user.Permissions || [];
        var state = false;
        for(var i = 0, menu; menu = permissions[i++];) {
            if(menu.Type = "menu" && transition.to.path.indexOf(menu.Link) == 0) {
                state = true;
                break;
            }
        }
        if(state) {
            transition.next();
        } else {
            transition.redirect("/404")
        }
    } else {
        transition.next()
    }
})
export default router
