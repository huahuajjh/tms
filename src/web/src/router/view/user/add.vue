<template>
    <modal title="录入用户" :visible.sync="visible" :static="true">
        <form class="form-horizontal" v-validation @success="formSuccess">
            <div class="modal-body">
                <div class="form-group" :class="{ 'has-error': !validation.model.Name.isChangePass }">
                    <label class="col-sm-3 control-label">姓名 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" placeholder="请输入姓名" v-model="user.Name">
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Name.isChangePass">{{ validation.model.Name.message }}</p>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.Account.isChangePass }">
                    <label class="col-sm-3 control-label">账号 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" placeholder="请输入账号" v-model="user.Account">
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Account.isChangePass">{{ validation.model.Account.message }}</p>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.RoleId.isChangePass }">
                    <label class="col-sm-3 control-label">角色 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <select class="form-control" v-model="user.RoleId">
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
                                <input type="radio" v-model="user.Gender" number value="1">
                                <label class="btn btn-primary"><i class="fa fa-male mr10"></i>男</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="user.Gender" number value="0">
                                <label class="btn btn-primary"><i class="fa fa-female mr10"></i>女</label>
                            </div>
                        </div>
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Gender.isChangePass">{{ validation.model.Gender.message }}</p>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.IdCard.isChangePass }">
                    <label class="col-sm-3 control-label">身份证</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" placeholder="请输入身份证" v-model="user.IdCard">
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
                            <input type="text" class="form-control" placeholder="请输入邮箱" v-model="user.Mail">
                        </div>
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Mail.isChangePass">{{ validation.model.Mail.message }}</p>
                    <div class="col-sm-8 col-sm-offset-3 mt10">
                        <div class="input-group" :class="{ 'has-error': !validation.model.Qq.isChangePass }">
                            <span class="input-group-addon">
                                <i class="fa fa-qq"></i>
                            </span>
                            <input type="text" class="form-control" placeholder="请输入QQ" v-model="user.Qq">
                        </div>
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Qq.isChangePass">{{ validation.model.Qq.message }}</p>
                    <div class="col-sm-8 col-sm-offset-3 mt10">
                        <div class="input-group" :class="{ 'has-error': !validation.model.Phone.isChangePass }">
                            <span class="input-group-addon">
                                <i class="fa fa-phone"></i>
                            </span>
                            <input type="text" class="form-control" placeholder="请输入手机号码" v-model="user.Phone">
                        </div>
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Phone.isChangePass">{{ validation.model.Phone.message }}</p>
                </div>
                <div class="col-sm-12 text-center text-danger">
                    注意:刚录入账号的密码都默认为"123456"
                </div>
            </div>
            <div class="modal-footer">
                <button type="submit" class="btn btn-block btn-primary" :disabled="!validation.isPass">保存</button>
            </div>
        </form>
    </modal>
</template>
<script>
    import { addUser, existsUser } from "../../../js/service/userService.js";
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
                Account: {
                    trim: true,
                    required: true,
                    alphaDash: true,
                    minlength: 3,
                    maxlength: 15,
                    remote(value, next) {
                        if(!value) next(false);
                        existsUser(value, ()=>{
                            next(true);
                        }, ()=>{
                            next(false);
                        });
                    }
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
                ajaxAlert("确定创建该账号?", "提示", ()=>{
                    var user = $.extend({}, self.user);
                    addUser(user, (msg)=> {
                        setTimeout(()=>{
                            self.visible = false;
                            self.reload();
                            self.$set("user", {
                                Name: "",
                                Account: "",
                                RoleId: "",
                                Gender: null,
                                Qq: "",
                                Mail: "",
                                Phone: "",
                                IdCard: ""
                            });
                            successAlert(msg);
                        }, 1000);
                    }, (msg)=>{
                        setTimeout(()=>{
                            errorAlert(msg);
                        }, 1000);
                    });
                });
            },
            initInfo(reload) {
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
            }
        },
        data() {
            return {
                visible: false,
                user: {
                    Name: "",
                    Account: "",
                    RoleId: "",
                    Gender: null,
                    Qq: "",
                    Mail: "",
                    Phone: "",
                    IdCard: ""
                },
                roleList: []
            };
        },
        components: {
            modal: require("../../../components/modal/modal.vue")
        }
    };
</script>