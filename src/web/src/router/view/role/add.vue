<template>
    <modal title="录入角色" :visible.sync="visible" :static="true">
        <form class="form-horizontal" v-validation @success="formSuccess">
            <div class="modal-body">
                <div class="form-group" :class="{ 'has-error': !validation.model.name.isChangePass }">
                    <label for="focusedinput" class="col-sm-3 control-label">角色名称 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" placeholder="请输入角色名称" v-model="role.name">
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.name.isChangePass">{{ validation.model.name.message }}</p>
                </div>
                <div class="form-group">
                    <label for="focusedinput" class="col-sm-3 control-label">角色备注</label>
                    <div class="col-sm-8">
                        <textarea rows="4" class="form-control" placeholder="请输入角色介绍" v-model="role.remarks"></textarea>
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
                <button type="submit" class="btn btn-block btn-primary" :disabled="!validation.isPass">保存</button>
            </div>
        </form>
    </modal>
</template>
<script>
    import { addRole } from "../../../js/service/roleService.js";
    import { ajax as ajaxAlert, success as successAlert, error as errorAlert } from '../../../js/lib/sweetalert/s-alert.js';

    export default {
        validation: {
            baseAttrName: "role",
            model: {
                name: {
                    trim: true,
                    required: true,
                    chsNumeric: true,
                    maxlength: 20
                },
                remarks: {
                    maxlength: 200
                }
            }
        },
        methods: {
            formSuccess() {
                var self = this;
                ajaxAlert("确定保存角色?", "提示", ()=>{
                    var role = $.extend({}, self.role);
                    addRole(role, (msg)=> {
                        self.visible = false;
                        self.reload();
                        successAlert(msg);
                    }, (msg)=>{
                        errorAlert(msg);
                    });
                });
            },
            initInfo(reload) {
                this.$set("reload", reload);
                this.$set("role.name", "");
                this.$set("role.remarks", "");
                this.$refs.permissionDom.$set("checkIds", []);
                this.$refs.permissionDom.initPermissions();
                this.visible = true;
            },
            initCheck(checkIds) {
                this.$set("role.permissions", checkIds);
            }
        },
        data() {
            return {
                visible: false,
                role: {
                    name: "",
                    remarks: "",
                    permissions: []
                }
            };
        },
        components: {
            modal: require("../../../components/modal/modal.vue"),
            permission: require("../../../components/permission/permission.vue")
        }
    };
</script>