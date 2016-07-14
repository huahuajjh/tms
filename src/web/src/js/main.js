require("./base/base.js");
Vue.config.silent = true;

import { userCookie } from '../js/helpers/cookieData.js';
import { getUserInfo } from '../js/service/userService.js';
import global from './globalMethod/global.js';

var indexVue = require("../router/view/main.vue");
import router from "../router/router.js";
if(userCookie.get()) {
    getUserInfo((data)=>{
        global.user = data;
        var menuTemp = global.user.Permissions || [];
        var menus = [];
        var initChild = (id, menus, actionChild)=>{
            for(var t = 0, menu; menu = menuTemp[t++];) {
                if(menu.PaterId === id && menu.Type === "menu") {
                    var model = toModel(menu);
                    menus.push(model);
                    initChild(menu.Id, model.child, model.actionChild);
                } else if(menu.Type === "action" && menu.PaterId === id) {
                    actionChild.push(toModel(menu));
                }
            }
        };
        var toModel = (menu)=>{
            return {
                id: menu.Id,
                title: menu.Title,
                sort: menu.Sort,
                link: menu.Link,
                type: menu.Type,
                data: menu,
                actionChild:[],
                child: []
            };
        };
        for(var i = 0, menu; menu = menuTemp[i++];) {
            if(!menu.PaterId && menu.Type === "menu") {
                var model = toModel(menu);
                menus.push(model);
                initChild(menu.Id, model.child, model.actionChild);
            }
        }
        global.menus = menus;
        router.start(indexVue, '#app');
    }, (error)=>{
        location.href = "./login.html";
    });
} else {
    location.href = "./login.html";
}