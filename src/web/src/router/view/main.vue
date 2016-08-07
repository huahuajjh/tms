<template>
    <main>
        <header>
            <a href="javascript:;" v-link="{ path: '/', replace: true }"><h1><strong>约游约呗</strong>大学生旅游门票管理系统</h1></a>
            <aside>
                <span>{{$global.user.TypeStr}}</span>
                <span>|</span>
                <div class="dropdown">
                    <a class="dropdown-toggle" href="javascript:;">{{$global.user.Name}} <i class="fa fa-angle-down"></i></a>
                    <ul class="dropdown-menu dropdown-menu-right">
                        <li><a href="javascript:;" @click="editPasswordVisible = true"><i class="fa fa-edit mr10"></i>修改密码</a></li>
                    </ul>
                </div>
                <span>|</span>
                <a class="outsys" title="退出系统" href="javascript:;" v-alert.bottom="'确定要退出系统?'" @yes="outsys">
                    <i class="fa fa-power-off"></i> 退出
                </a>
            </aside>
        </header>
        <div class="context not-child-nav">
            <div class="left-nav">
                <nav>
                    <div v-for="menu in $global.menus">
                        <a href="javascript:;" v-link="{ path: getLink(menu), activeClass: 'current', replace: true}" @click="actionMenu = menu">
                            {{menu.title}}
                        </a>
                        <dl v-if="menu.child && menu.child.length > 0">
                            <dt>{{menu.title}}</dt>
                            <dd v-for="child in menu.child">
                                <a href="javascript:;" v-link="{ path: getLink(child), activeClass: 'current', replace: true }">{{child.title}}</a>
                            </dd>
                        </dl>
                    </div>
                </nav>
            </div>
            <div class="right-content">
                <router-view></router-view>
            </div>
        </div>
        <edit-password-modal :visible.sync="editPasswordVisible"></edit-password-modal>
    </main>
</template>
<script>
    require("./main.scss");

    import { userCookie } from '../../js/helpers/cookieData.js';

    export default {
        data() {
            return {
                actionMenu: {},
                editPasswordVisible: false
            };
        },
        methods: {
            getLink(menu){
                if(menu.child && menu.child.length > 0)
                    return menu.link;
                return menu.link + '/' + menu.id;
            },
            outsys() {
                userCookie.remove();
                location.href = "./login.html";
            }
        },
        components: {
            editPasswordModal: require("./editPassword.vue")
        }
    };
</script>