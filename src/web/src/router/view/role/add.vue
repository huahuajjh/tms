<template>
    <modal title="录入权限" :visible.sync="visible" :static="true">
        <form class="form-horizontal" v-validation @success="formSuccess">
            <div class="modal-body">
                <div class="form-group" :class="{ 'has-error': !validation.model.name.isChangePass }">
                    <label for="focusedinput" class="col-sm-3 control-label">权限名称 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" placeholder="请输入权限名称" v-model="role.name" tabindex="1">
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.name.isChangePass">{{ validation.model.name.message }}</p>
                </div>
                <div class="form-group">
                    <label for="focusedinput" class="col-sm-3 control-label">权限备注</label>
                    <div class="col-sm-8">
                        <textarea rows="4" class="form-control" placeholder="请输入权限介绍" v-model="role.remarks" tabindex="2"></textarea>
                    </div>
                </div>
                <div class="form-group">
                    <label for="focusedinput" class="col-sm-3 control-label">权限权限</label>
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
    import { addRole } from "../../../js/service/roleService.js";
    import { ajax as ajaxAlert, success as successAlert, error as errorAlert, confirm as confirmAlert } from '../../../js/lib/sweetalert/s-alert.js';

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
                ajaxAlert("确定保存权限?", "提示", ()=>{
                    var role = $.extend({}, self.role);
                    addRole(role, (msg)=> {
                        successAlert(msg);
                        self.$set("role.name", "");
                        self.$set("role.remarks", "");
                        self.$refs.permissionDom.$set("checkIds", []);
                        self.$refs.permissionDom.initPermissions();
                        self.validation.initChangeTrue();
                        self.reload();
                        self.visible = false;
                    }, (msg)=>{
                        errorAlert(msg);
                    });
                });
            },
            initInfo(reload) {
                this.$set("reload", reload);
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
        ready() {
            this.$refs.permissionDom.initPermissions();
        },
        components: {
            modal: require("../../../components/modal/modal.vue"),
            permission: require("../../../components/permission/permission.vue")
        }
    };
</script>