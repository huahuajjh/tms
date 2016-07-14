<template>
    <modal title="更改用户状态" :visible.sync="visible" :static="true" size="modal-sm">
        <form v-validation @success="formSuccess">
            <div class="modal-body">
                <div class="form-group">
                    <label class="control-label">用户账号</label>
                    <div class="form-control-static">{{user.Account}}</div>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.state.isChangePass }">
                    <label class="control-label">状态 <span class="text-danger">*</span></label>
                    <div>
                        <div class="btn-group">
                            <div class="btn-check" v-for="val in stateList">
                                <input type="radio" :value="val.Id" v-model="state">
                                <label class="btn btn-midnightblue-alt">{{val.Title}}</label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="submit" class="btn btn-block btn-primary" :disabled="!validation.isPass">应用</button>
            </div>
        </form>
    </modal>
</template>
<script>
    import { setUserState, getStateAll } from "../../../js/service/userService.js";
    import gritter from "../../../js/lib/gritter/gritter.js";
    import { ajax as ajaxAlert, success as successAlert, error as errorAlert } from '../../../js/lib/sweetalert/s-alert.js';

    export default {
        validation: {
            model: {
                state: {
                    required: true
                }
            }
        },
        props: {
            visible: {
                type: Boolean,
                default: false
            }
        },
        methods: {
            formSuccess() {
                var self = this;
                ajaxAlert("确定更改该账号的状态?", "提示", ()=>{
                    setUserState({
                        id: self.user.Id,
                        stateId: self.state
                    }, (msg)=> {
                        self.visible = false;
                        self.reload();
                        successAlert(msg);
                    }, (msg)=>{
                        errorAlert(msg);
                    });
                });
            },
            initInfo(user, reload) {
                if(this.stateList.length <= 0){
                    var self = this;
                    getStateAll((stateList)=>{
                        self.$set("stateList", stateList);
                    }, (msg)=>{
                        gritter(msg).error();
                    });
                }
                this.$set("reload", reload);
                this.visible = true;
                this.state = user.StateId;
                this.$set("user", user);
            }
        },
        data() {
            return {
                user: {},
                state: "",
                stateList: []
            };
        },
        components: {
            modal: require("../../../components/modal/modal.vue")
        }
    };
</script>