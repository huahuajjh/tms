<template>
    <div class="jstree">
        <ul class="jstree-container-ul jstree-wholerow-ul">
            <li class="jstree-node" v-for="permission in permissions" :class="{ 'jstree-leaf': !permission.child || permission.child.length <= 0, 'jstree-closed': permission.child.length > 0 && permission.close }">
                <div class="jstree-wholerow" :class="{ 'jstree-wholerow-clicked': permission.check === 1 }">&nbsp;</div>
                <i class="jstree-icon jstree-ocl" @click="permission.close = !permission.close"></i>
                <a class="jstree-anchor" href="javascript:;" :class="{ 'jstree-clicked': permission.check === 1 }" @click="checkData(permission)">
                    <i class="jstree-icon" :class="{ 'jstree-undetermined': permission.check === 2, 'jstree-checkbox': permission.check !== 2 }"></i>
                    <i class="jstree-icon jstree-themeicon-custom fa" v-if="permission.icon" :class="permission.icon"></i>
                    {{permission.title}}
                </a>
                <permission-item :permissions="permission.child" :show.sync="!permission.close" :check-data="checkData"></permission-item>
            </li>
        </ul>
    </div>
</template>
<script>
    import { getAll } from "../../js/service/menuService.js";
    import gritter from "../../js/lib/gritter/gritter.js";

    Vue.component('permission-item', {
        props: {
            permissions: {
                type: Array
            },
            show: {
                type: Boolean
            },
            checkData: {
                type: Function
            }
        },
        template: `
            <ul class="jstree-children" v-if="permissions || permissions.length > 0" v-show="show">
                <li class="jstree-node" v-for="permission in permissions" :class="{ 'jstree-leaf': !permission.child || permission.child.length <= 0, 'jstree-closed': permission.child.length > 0 && permission.close }">
                    <div class="jstree-wholerow" :class="{ 'jstree-wholerow-clicked': permission.check !== 0 }">&nbsp;</div>
                    <i class="jstree-icon jstree-ocl" @click="permission.close = !permission.close"></i>
                    <a class="jstree-anchor" href="javascript:;" :class="{ 'jstree-clicked': permission.check !== 0 }" @click="checkData(permission)">
                        <i class="jstree-icon" :class="{ 'jstree-undetermined': permission.check === 2, 'jstree-checkbox': permission.check !== 2 }"></i>
                        <i class="jstree-icon jstree-themeicon-custom fa" v-if="permission.icon" :class="permission.icon"></i>
                        {{permission.title}}
                    </a>
                    <permission-item :permissions="permission.child" :show.sync="!permission.close" :check-data="checkData"></permission-item>
                </li>
            </ul>
        `
    });

    function toModel(data, parent) {
        return {
            title: data.Title,
            sort: data.Sort,
            check: 0,
            close: true,
            icon: data.Ico,
            data: data,
            parent: parent,
            child: []
        };
    }
    function initDatas (permission, id, datas) {
        for(let i = 0, data; data = datas[i++];) {
            if(data.PaterId === id) {
                let permissionTemp = toModel(data, permission);
                permission.child.push(permissionTemp);
                initDatas(permissionTemp, data.Id, datas);
            }
        }
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
        props: {
            checkIds: {
                type: Array,
                default: []
            },
            checkFn: {
                type:Function,
                default: function() {}
            }
        },
        data(){
            return {
                permissions: []
            };
        },
        methods: {
            initPermissions() {
                var self = this;
                getAll((datas)=>{
                    var permissions = initData(datas);
                    self.$set("permissions", permissions);
                    var checkIds = this.checkIds || [];
                    for(let i = 0, permission; permission = permissions[i++];) {
                        self.permissionIsCheck(permission, checkIds);
                    }
                }, (msg)=>{
                    gritter(msg).error();
                });
            },
            checkData(data) {
                data.check = data.check === 1 ? 0 : 1;
                this.checkNext(data);
                this.checkPer(data.parent);
                var checkIds = [];
                this.initCheck(this.permissions, checkIds);
                this.checkFn(checkIds);
            },
            checkPer: function (data){
                if(data) {
                    var checkLength = data.child.length;
                    for(var i = 0, child; child = data.child[i++];) {
                        if(child.check === 0) {
                            checkLength = checkLength - 1;
                        }
                    }
                    if(checkLength === data.child.length) {
                        data.check = 1;
                    } else if(checkLength > 0) {
                        data.check = 2;
                    } else {
                        data.check = 0;
                    }
                    this.checkPer(data.parent);
                }
            },
            checkNext: function (data){
                if(data.child && data.child.length) {
                    for(var i = 0,child; child = data.child[i++];) {
                        child.check = data.check;
                        this.checkNext(child);
                    }
                }
            },
            permissionIsCheck (permission, checkIds) {
                for(let i = 0, checkId; checkId = checkIds[i++]; ) {
                    if(permission.child && permission.child.length > 0) {
                        for(let l = 0, childPermission; childPermission = permission.child[l++];) {
                            this.permissionIsCheck(childPermission, checkIds);
                        }
                    } else if(permission.data.Id === checkId) {
                       permission.check = 1;
                        this.checkNext(permission);
                        this.checkPer(permission.parent);
                    }
                }
            },
            initCheck(permissions, checkIds) {
                for(var i = 0, permission; permission = permissions[i++];) {
                    if(permission.check !== 0) {
                        checkIds.push(permission.data.Id);
                        if(permission.child && permission.child.length > 0) {
                            this.initCheck(permission.child, checkIds);
                        }
                    }
                }
            }
        }
    }
</script>