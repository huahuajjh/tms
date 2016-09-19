<style>
    .form-group-info {
        padding: 5px 12px !important;
    }
</style>
<template>
    <modal title="取出订单" :visible.sync="visible" :static="true">
        <div class="panel-body">
            <div class="form-horizontal tabular-form">
                <div class="modal-body">
                    <div class="form-group form-group-info">
                        <label for="focusedinput" class="col-sm-3 text-right">验证码</label>
                        <div class="col-sm-8 tabular-border">{{info.Code}}</div>
                    </div>
                    <div class="form-group form-group-info">
                        <label for="focusedinput" class="col-sm-3 text-right">游客名称</label>
                        <div class="col-sm-8 tabular-border">{{info.Name}}</div>
                    </div>
                    <div class="form-group form-group-info">
                        <label for="focusedinput" class="col-sm-3 text-right">游客手机号码</label>
                        <div class="col-sm-9 tabular-border">{{info.Phone}}</div>
                    </div>
                    <div class="form-group form-group-info">
                        <label for="focusedinput" class="col-sm-3 text-right">游客身份证</label>
                        <div class="col-sm-9 tabular-border">{{info.IdCard}}</div>
                    </div>
                    <div class="form-group form-group-info">
                        <label for="focusedinput" class="col-sm-3 text-right">游客性别 </label>
                        <div class="col-sm-9 tabular-border">{{ info.GenderStr }}</div>
                    </div>
                    <div class="form-group form-group-info">
                        <label for="focusedinput" class="col-sm-3 text-right">游玩线路</label>
                        <div class="col-sm-9 tabular-border">{{info.SceneryTitle}}</div>
                    </div>
                    <div class="form-group form-group-info">
                        <label for="focusedinput" class="col-sm-3 text-right">游玩时间</label>
                        <div class="col-sm-9 tabular-border">{{info.PlayTime | datetime "yyyy/MM/dd"}}</div>
                    </div>
                    <div class="form-group form-group-info">
                        <label for="focusedinput" class="col-sm-3 text-right">购票数量</label>
                        <div class="col-sm-9 tabular-border">{{info.BuyNumber}}</div>
                    </div>
                    <div class="form-group form-group-info">
                        <label for="focusedinput" class="col-sm-3 text-right">游客所属群体</label>
                        <div class="col-sm-9 tabular-border">{{info.Community}}</div>
                    </div>
                    <div class="form-group form-group-info">
                        <label for="focusedinput" class="col-sm-3 text-right">游客所属单位(学校)</label>
                        <div class="col-sm-9 tabular-border">{{info.Unit}}</div>
                    </div>
                     <div class="form-group form-group-info">
                        <label for="focusedinput" class="col-sm-3 text-right">备注</label>
                        <div class="col-sm-9 tabular-border">{{info.Remarks}}</div>
                    </div>
                </div>
            </div>
            <hr>
            <form class="form-horizontal" v-validation @success="formSuccess">
                <div class="modal-body">
                    <div class="form-group">
                        <label class="col-sm-3 control-label">还剩可取订单</label>
                        <div class="col-sm-8 form-control-static">
                            {{info.TakeNum}}
                        </div>
                    </div>
                    <div class="form-group" :class="{ 'has-error': !validation.model.TakenNum.isChangePass }">
                        <label for="focusedinput" class="col-sm-3 control-label">取走数量 <span class="text-danger">*</span></label>
                        <div class="col-sm-8">
                            <input type="text" class="form-control" placeholder="请输入取走数量" number v-model="ticket.TakenNum" tabindex="1">
                        </div>
                        <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.TakenNum.isChangePass">{{ validation.model.TakenNum.message }}</p>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="submit" class="btn btn-block btn-purple" :disabled="!validation.isPass" tabindex="2">保存</button>
                </div>
            </form>
        </div>
    </modal>
</template>
<script>

    import { takenTicket } from "../../../js/service/ticketService.js";
    import { ajax as ajaxAlert, success as successAlert, error as errorAlert } from '../../../js/lib/sweetalert/s-alert.js';

    export default {
        validation: {
            baseAttrName: "ticket",
            model: {
                 TakenNum: {
                    trim: true,
                    required: true,
                    int: true,
                    max: 0
                }
            }
        },
        methods: {
            initInfo(data, reload) {
                this.$set("reload", reload);
                this.$set("info", data);
                this.$set("ticket.Id", data.Id);
                this.$set("ticket.TakenNum", 0);
                this.visible = true;
            },
            formSuccess() {
                if(this.ticket.TakenNum > this.info.TakeNum) {
                    errorAlert("超出范围");
                    return;
                }
                var self = this;
                ajaxAlert("确定取出该订单?", "提示", ()=>{
                    takenTicket(self.ticket, (msg)=> {
                        self.visible = false;
                        successAlert(msg);
                        self.reload();
                    }, (msg)=>{
                        errorAlert(msg);
                    });
                });
            }
        },
        data() {
            return {
                visible: false,
                info: {},
                ticket: {
                    Id: 0,
                    TakenNum: 0
                }
            };
        },
        components: {
            modal: require("../../../components/modal/modal.vue")
        }
    };
</script>