<template>
    <modal title="录入线路" :visible.sync="visible" :static="true">
        <form class="form-horizontal" v-validation @success="formSuccess">
            <div class="modal-body">
                <div class="form-group" :class="{ 'has-error': !validation.model.title.isChangePass }">
                    <label class="col-sm-3 control-label">线路名称 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" placeholder="请输入姓名" v-model="scenic.title" tabindex="1">
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.title.isChangePass">{{ validation.model.title.message }}</p>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.remarks.isChangePass }">
                    <label class="col-sm-3 control-label">线路介绍</label>
                    <div class="col-sm-8">
                        <textarea rows="4" class="form-control" v-model="scenic.remarks" placeholder="请输入线路介绍" tabindex="2"></textarea>
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.remarks.isChangePass">{{ validation.model.remarks.message }}</p>
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
    import { addScenic } from "../../../js/service/scenicService.js";
    import gritter from "../../../js/lib/gritter/gritter.js";
    import { ajax as ajaxAlert, success as successAlert, error as errorAlert } from '../../../js/lib/sweetalert/s-alert.js';

    export default {
        validation: {
            baseAttrName: "scenic",
            model: {
                title: {
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
                ajaxAlert("确定保存该线路?", "提示", ()=>{
                    var scenic = $.extend({}, self.scenic);
                    addScenic(scenic, (msg)=> {
                        self.visible = false;
                        self.reload();
                        successAlert(msg);
                        self.$set("scenic", {
                            title: "",
                            remarks: "",
                            userIds: ""
                        });
                        self.$refs.selectDom.initSelectDatas([]);
                        self.validation.initChangeTrue();
                    }, (msg)=>{
                        errorAlert(msg);
                    });
                });
            },
            initInfo(reload) {
                this.$set("reload", reload);
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
                visible: false,
                scenic: {}
            };
        },
        components: {
            modal: require("../../../components/modal/modal.vue"),
            selectPerson: require("../../../components/selectPerson/selectPerson.vue")
        }
    };
</script>