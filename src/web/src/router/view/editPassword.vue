<template>
    <modal title="更改密码" :static="true" :visible.sync="visible">
        <form class="form-horizontal" v-validation @success="formSuccess">
            <div class="modal-body">
                <div class="form-group" :class="{ 'has-error': !validation.model.old.isChangePass }">
                    <label for="focusedinput" class="col-sm-3 control-label">旧密码 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <input type="password" class="form-control" placeholder="请输入旧密码" v-model="password.old">
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.old.isChangePass">{{ validation.model.old.message }}</p>
                </div>
                <hr>
                <div class="form-group" :class="{ 'has-error': !validation.model.new.isChangePass }">
                    <label for="focusedinput" class="col-sm-3 control-label">新密码 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <input type="password" class="form-control" placeholder="请输入新密码" v-model="password.new">
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.new.isChangePass">{{ validation.model.new.message }}</p>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.repeat.isChangePass }">
                    <label for="focusedinput" class="col-sm-3 control-label">重复输入密码 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <input type="password" class="form-control" placeholder="请从新输入密码" v-model="password.repeat">
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.repeat.isChangePass">{{ validation.model.repeat.message }}</p>
                </div>
            </div>
            <div class="modal-footer">
                <button type="submit" class="btn btn-block btn-primary" :disabled="!validation.isPass">应用</button>
            </div>
        </form>
    </modal>
</template>
<script>
    import { userCookie } from '../../js/helpers/cookieData.js';
    import { ajax as ajaxAlert, success as successAlert, error as errorAlert } from '../../js/lib/sweetalert/s-alert.js';
    import { editPassword } from '../../js/service/userService.js';

    export default {
        validation: {
            baseAttrName: "password",
            model: {
                old: {
                    required: true,
                    alphaDash: true,
                    minlength: 5,
                    maxlength: 15
                },
                new: {
                    required: true,
                    alphaDash: true,
                    minlength: 5,
                    maxlength: 15
                },
                repeat: {
                    required: true,
                    alphaDash: true,
                    minlength: 5,
                    maxlength: 15,
                    repeat: "password.new"
                }
            }
        },
        props: {
            visible: {
                type: Boolean,
                default: false
            }
        },
        watch: {
            visible(value) {
                if(!value) {
                    this.password.old = "";
                    this.password.new = "";
                    this.password.repeat = "";
                }
            }
        },
        methods: {
            formSuccess() {
                var self = this;
                ajaxAlert("确定提交密码修改", "提示", ()=>{
                    var password = {
                        sessionId: userCookie.get(),
                        oldPassword: self.password.old,
                        newPassword: self.password.new
                    };
                    editPassword(password, (msg)=> {
                        setTimeout(()=>{
                            self.visible = false;
                            successAlert(msg);
                        }, 1000);
                    }, (msg)=>{
                        setTimeout(()=>{
                            errorAlert(msg);
                        }, 1000);
                    });
                });

            }
        },
        data() {
            return {
                password: {
                    old: "",
                    new: "",
                    repeat: ""
                }
            };
        },
        components: {
            modal: require("../../components/modal/modal.vue")
        }
    };
</script>