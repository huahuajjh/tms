<template>
    <modal title="修改用户" :visible.sync="visible" :static="true">
        <form class="form-horizontal" v-validation @success="formSuccess">
            <div class="modal-body">
                <div class="form-group" :class="{ 'has-error': !validation.model.Name.isChangePass }">
                    <label class="col-sm-3 control-label">姓名 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" placeholder="请输入姓名" tabindex="1" v-model="user.Name">
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Name.isChangePass">{{ validation.model.Name.message }}</p>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">账号</label>
                    <div class="col-sm-8 form-control-static">
                        {{user.Account}}
                    </div>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.Type.isChangePass }">
                    <label class="col-sm-3 control-label">账号类型 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <div class="btn-group">
                            <div class="btn-check">
                                <input type="radio" v-model="user.Type" number value="0" tabindex="2">
                                <label class="btn btn-primary">管理员</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="user.Type" number value="1" tabindex="3">
                                <label class="btn btn-primary">代理商</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="user.Type" number value="2">
                                <label class="btn btn-primary">景点管理员</label>
                            </div>
                        </div>
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Type.isChangePass">{{ validation.model.Type.message }}</p>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.RoleId.isChangePass }">
                    <label class="col-sm-3 control-label">角色 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <select class="form-control" v-model="user.RoleId" tabindex="5">
                            <option value="">请选择所属角色</option>
                            <option v-for="role in roleList" :value="role.Id">{{role.Name}}</option>
                        </select>
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.RoleId.isChangePass">{{ validation.model.RoleId.message }}</p>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.Gender.isChangePass }">
                    <label class="col-sm-3 control-label">性别 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <div class="btn-group">
                            <div class="btn-check">
                                <input type="radio" v-model="user.Gender" number value="1" tabindex="6">
                                <label class="btn btn-primary"><i class="fa fa-male mr10"></i>男</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="user.Gender" number value="0" tabindex="7">
                                <label class="btn btn-primary"><i class="fa fa-female mr10"></i>女</label>
                            </div>
                        </div>
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Gender.isChangePass">{{ validation.model.Gender.message }}</p>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.IdCard.isChangePass }">
                    <label class="col-sm-3 control-label">身份证</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" placeholder="请输入身份证" tabindex="8" v-model="user.IdCard">
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.IdCard.isChangePass">{{ validation.model.IdCard.message }}</p>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">联系方式</label>
                    <div class="col-sm-8">
                        <div class="input-group" :class="{ 'has-error': !validation.model.Mail.isChangePass }">
                            <span class="input-group-addon">
                                <i class="fa fa-envelope-o"></i>
                            </span>
                            <input type="text" class="form-control" placeholder="请输入邮箱" tabindex="9" v-model="user.Mail">
                        </div>
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Mail.isChangePass">{{ validation.model.Mail.message }}</p>
                    <div class="col-sm-8 col-sm-offset-3 mt10">
                        <div class="input-group" :class="{ 'has-error': !validation.model.Qq.isChangePass }">
                            <span class="input-group-addon">
                                <i class="fa fa-qq"></i>
                            </span>
                            <input type="text" class="form-control" placeholder="请输入QQ" tabindex="10" v-model="user.Qq">
                        </div>
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Qq.isChangePass">{{ validation.model.Qq.message }}</p>
                    <div class="col-sm-8 col-sm-offset-3 mt10">
                        <div class="input-group" :class="{ 'has-error': !validation.model.Phone.isChangePass }">
                            <span class="input-group-addon">
                                <i class="fa fa-phone"></i>
                            </span>
                            <input type="text" class="form-control" placeholder="请输入手机号码" tabindex="11" v-model="user.Phone">
                        </div>
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Phone.isChangePass">{{ validation.model.Phone.message }}</p>
                </div>
            </div>
            <div class="modal-footer">
                <button type="submit" class="btn btn-block btn-purple" :disabled="!validation.isPass" tabindex="12">应用</button>
            </div>
        </form>
    </modal>
</template>
<script>
    import { editUser } from "../../../js/service/userService.js";
    import { getRoleAllInfo } from "../../../js/service/roleService.js";
    import gritter from "../../../js/lib/gritter/gritter.js";
    import { ajax as ajaxAlert, success as successAlert, error as errorAlert } from '../../../js/lib/sweetalert/s-alert.js';

    export default {
        validation: {
            baseAttrName: "user",
            model: {
                Name: {
                    trim: true,
                    required: true,
                    chsNumeric: true,
                    maxlength: 20
                },
                Type: {
                    required: true
                },
                Gender: {
                    required: true,
                },
                RoleId: {
                    required: true
                },
                Mail: {
                    email: true
                },
                Qq: {
                    qq: true
                },
                Phone: {
                    phone: true
                },
                IdCard: {
                    id: true
                }
            }
        },
        methods: {
            formSuccess() {
                var self = this;
                ajaxAlert("确定修改该用户信息?", "提示", ()=>{
                    var user = $.extend({}, self.user);
                    editUser(user, (msg)=> {
                        setTimeout(()=>{
                            self.visible = false;
                            successAlert(msg);
                            self.reload();
                        }, 1000);
                    }, (msg)=>{
                        setTimeout(()=>{
                            errorAlert(msg);
                        }, 1000);
                    });
                });
            },
            initInfo(user, reload) {
                if(this.roleList.length <= 0){
                    var self = this;
                    getRoleAllInfo((roleList)=>{
                        self.$set("roleList", roleList);
                    }, (msg)=>{
                        gritter(msg).error();
                    });
                }
                this.$set("reload", reload);
                this.visible = true;
                user.Type = user.UserType;
                this.$set("user", user);
            }
        },
        data() {
            return {
                user: {},
                visible: false,
                roleList: []
            };
        },
        components: {
            modal: require("../../../components/modal/modal.vue")
        }
    };
</script>