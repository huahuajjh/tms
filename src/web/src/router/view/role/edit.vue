<template>
    <modal title="修改角色" :visible.sync="visible" :static="true">
        <form class="form-horizontal" v-validation @success="formSuccess">
            <div class="modal-body">
                <div class="form-group" :class="{ 'has-error': !validation.model.Name.isChangePass }">
                    <label for="focusedinput" class="col-sm-3 control-label">角色名称 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" placeholder="请输入角色名称" v-model="role.Name" tabindex="1">
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Name.isChangePass">{{ validation.model.Name.message }}</p>
                </div>
                <div class="form-group">
                    <label for="focusedinput" class="col-sm-3 control-label">角色备注</label>
                    <div class="col-sm-8">
                        <textarea rows="4" class="form-control" placeholder="请输入角色介绍" v-model="role.Remarks" tabindex="2"></textarea>
                    </div>
                </div>
                <div class="form-group">
                    <label for="focusedinput" class="col-sm-3 control-label">角色权限</label>
                    <div class="col-sm-9">
                        <permission v-ref:permission-dom :check-fn="initCheck"></permission>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="submit" class="btn btn-block btn-purple" :disabled="!validation.isPass" tabindex="3">保存</button>
            </div>
        </form>
    </modal>
</template>
<script>
    import { getRoleInfo, editRole } from "../../../js/service/roleService.js";
    import { ajax as ajaxAlert, success as successAlert, error as errorAlert } from '../../../js/lib/sweetalert/s-alert.js';
    import gritter from "../../../js/lib/gritter/gritter.js";

    export default {
        validation: {
            baseAttrName: "role",
            model: {
                Name: {
                    trim: true,
                    required: true,
                    chsNumeric: true,
                    maxlength: 20
                },
                Remarks: {
                    maxlength: 200
                }
            }
        },
        watch: {
            visible(value) {
                if(value) {
                    this.$refs.permissionDom.$set("checkIds", this.role.Permissions);
                    this.$refs.permissionDom.initPermissions();
                }
            }
        },
        methods: {
            formSuccess() {
                var self = this;
                ajaxAlert("确定修改该角色信息?", "提示", ()=>{
                    var role = $.extend({}, self.role);
                    editRole(role, (msg)=> {
                        self.visible = false;
                        successAlert(msg);
                        self.reload();
                    }, (msg)=>{
                        errorAlert(msg);
                    });
                });
            },
            initCheck(checkIds) {
                this.$set("role.Permissions", (checkIds || []).join(","));
            },
            initInfo(role, permissions, reload) {
                var self = this;
                var permissionsIds = [];
                for(var i = 0,item; item = permissions[i++];) {
                    permissionsIds.push(item.Id);
                }
                this.$set("role", $.extend({}, role));
                this.$set("role.Permissions", permissionsIds);
                this.$set("reload", reload);
                this.visible = true;
            }
        },
        data() {
            return {
                role: {
                    Id: 0,
                    Name: "",
                    Remarks: "",
                    Permissions: []
                },
                visible: false
            };
        },
        components: {
            modal: require("../../../components/modal/modal.vue"),
            permission: require("../../../components/permission/permission.vue")
        }
    };
</script>