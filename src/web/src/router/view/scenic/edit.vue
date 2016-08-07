<template>
    <modal title="修改线路详细" :visible.sync="visible" :static="true">
        <form class="form-horizontal" v-validation @success="formSuccess">
            <div class="modal-body">
                <div class="form-group" :class="{ 'has-error': !validation.model.Title.isChangePass }">
                    <label class="col-sm-3 control-label">线路名称 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" placeholder="请输入姓名" v-model="scenic.Title" tabindex="1">
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Title.isChangePass">{{ validation.model.Title.message }}</p>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.Remarks.isChangePass }">
                    <label class="col-sm-3 control-label">线路介绍</label>
                    <div class="col-sm-8">
                        <textarea rows="4" class="form-control" v-model="scenic.Remarks" placeholder="请输入线路介绍" tabindex="2"></textarea>
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Remarks.isChangePass">{{ validation.model.Remarks.message }}</p>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">线路管理人员</label>
                    <div class="col-sm-8">
                        <select-person v-ref:select-dom :select-fn="selectUser"></select-person>
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
    import { getScenicInfo, editScenic } from "../../../js/service/scenicService.js";
    import { ajax as ajaxAlert, success as successAlert, error as errorAlert } from '../../../js/lib/sweetalert/s-alert.js';
    import gritter from "../../../js/lib/gritter/gritter.js";

    export default {
        validation: {
            baseAttrName: "scenic",
            model: {
                Title: {
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
        methods: {
            formSuccess() {
                var self = this;
                ajaxAlert("确定修改该线路信息?", "提示", ()=>{
                    editScenic(self.scenic, (msg)=> {
                        self.visible = false;
                        successAlert(msg);
                        self.reload();
                    }, (msg)=>{
                        errorAlert(msg);
                    });
                });
            },
            initInfo(scenic, users, reload) {
                this.$set("reload", reload);
                this.$set("scenic", scenic);
                this.$set("users", users);
                this.selectUser(users);
                this.$refs.selectDom.initSelectDatas(users);
                this.visible = true;
            },
            selectUser(users) {
                var ids = [];
                for(var i = 0, user; user = users[i++];){
                    ids.push(user.Id);
                }
                this.$set("scenic.userIds", ids.join(","));
            }
        },
        data() {
            return {
                scenic: {},
                users: [],
                visible: false
            };
        },
        components: {
            modal: require("../../../components/modal/modal.vue"),
            selectPerson: require("../../../components/selectPerson/selectPerson.vue")
        }
    };
</script>