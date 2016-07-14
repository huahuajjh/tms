var globalVM = {
    user:{},
    menus: [],
    getMenuAtIdInitAction(id, action){
        var data = null;
        var search = (menus)=> {
            for(var i = 0,menu; (menu = menus[i++]) && !data;) {
                if(menu.id == id) {
                    data = menu;
                }
                search(menu.child);
            }
        };
        for(var i = 0,menu; (menu = this.menus[i++]) && !data;) {
            if(menu.id == id) {
                data = menu;
            }
            search(menu.child);
        }
        if(action && data && data.actionChild && data.actionChild.length > 0) {
            var actionChild = data.actionChild;
            for(var i = 0, child; child = actionChild[i++];) {
                for (var key in action) {
                    if(key == child.link) {
                        action[key] = true;
                    }
                }
            }
        }
        return data;
    }
};

export function install(Vue) {
    Vue.global = globalVM;
    Vue.mixin({
        created: function () {
            Vue.util.defineReactive(this, '$global', globalVM)
        }
    })
}
export default globalVM;