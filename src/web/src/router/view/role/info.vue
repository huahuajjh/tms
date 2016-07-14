<template>
    <modal title="角色详细" :visible.sync="visible">
        <div class="panel-body">
            <form class="form-horizontal tabular-form">
                <div class="modal-body">
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-3 text-right">角色名称</label>
                        <div class="col-sm-8 tabular-border">{{roleInfo.Name}}</div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-3 text-right">角色介绍</label>
                        <div class="col-sm-8 tabular-border">{{roleInfo.Remarks}}</div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-3 text-right">角色权限</label>
                        <div class="col-sm-9 tabular-border">
                            <div class="jstree">
                                <ul class="jstree-container-ul">
                                    <li class="jstree-node" v-for="permission in roleInfo.Permissions" :class="{ 'jstree-leaf': !permission.child || permission.child.length <= 0, 'jstree-closed': permission.child.length > 0 && permission.close }">
                                        <div class="jstree-wholerow">&nbsp;</div>
                                        <i class="jstree-icon jstree-ocl" @click="permission.close = !permission.close"></i>
                                        <a class="jstree-anchor" href="javascript:;">
                                            <i class="jstree-icon jstree-themeicon-custom fa" v-if="permission.icon" :class="permission.icon"></i>
                                            {{permission.title}}
                                        </a>
                                        <role-permission-item :permissions="permission.child" :show.sync="!permission.close"></role-permission-item>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </modal>
</template>
<script>
    Vue.component('role-permission-item', {
        props: {
            permissions: {
                type: Array
            },
            show: {
                type: Boolean
            }
        },
        template: `
            <ul class="jstree-children" v-if="permissions || permissions.length > 0" v-show="show">
                <li class="jstree-node" v-for="permission in permissions" :class="{ 'jstree-leaf': !permission.child || permission.child.length <= 0, 'jstree-closed': permission.child.length > 0 && permission.close }">
                    <i class="jstree-icon jstree-ocl" @click="permission.close = !permission.close"></i>
                    <a class="jstree-anchor" href="javascript:;">
                        <i class="jstree-icon jstree-themeicon-custom fa" v-if="permission.icon" :class="permission.icon"></i>
                        {{permission.title}}
                    </a>
                    <role-permission-item :permissions="permission.child" :show.sync="!permission.close"></role-permission-item>
                </li>
            </ul>
        `
    });

    function initDatas(permission, id, datas) {
        for(let i = 0, data; data = datas[i++];) {
            if(data.PaterId === id) {
                let permissionTemp = toModel(data, permission);
                permission.child.push(permissionTemp);
                initDatas(permissionTemp, data.Id, datas);
            }
        }
    }

    function toModel(data, parent) {
        return {
            title: data.Title,
            sort: data.Sort,
            close: true,
            icon: data.Ico,
            data: data,
            parent: parent,
            child: []
        };
    }

    function initData(datas) {
        var permissions = [];
        for(var i = 0, data; data = datas[i++];) {
            if(data.PaterId === null) {
                let permission = toModel(data, null);
                permissions.push(permission);
                initDatas(permission, data.Id, datas);
            }
        }
        return permissions;
    }

    export default {
        methods: {
            initInfo(data, permissions) {
                var permissions = initData(permissions);
                data.Permissions = permissions;
                this.$set("roleInfo", data);
                this.visible = true;
            }
        },
        data() {
            return {
                visible: false,
                roleInfo: {}
            };
        },
        components: {
            modal: require("../../../components/modal/modal.vue")
        }
    };
</script>