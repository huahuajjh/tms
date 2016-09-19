<template>
    <modal title="录入订单" :visible.sync="visible" :static="true">
        <form class="form-horizontal" v-validation @success="formSuccess">
            <div class="modal-body">
                <div class="form-group" :class="{ 'has-error': !validation.model.Name.isChangePass }">
                    <label for="focusedinput" class="col-sm-3 control-label">游客名称 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" placeholder="请输入游客名称" v-model="ticket.Name" tabindex="1">
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Name.isChangePass">{{ validation.model.Name.message }}</p>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.Phone.isChangePass }">
                    <label for="focusedinput" class="col-sm-3 control-label">游客手机号码 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" placeholder="请输入游客手机号码" v-model="ticket.Phone" tabindex="2">
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Phone.isChangePass">{{ validation.model.Phone.message }}</p>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.IdCard.isChangePass }">
                    <label for="focusedinput" class="col-sm-3 control-label">游客身份证 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" placeholder="请输入游客身份证" v-model="ticket.IdCard" tabindex="3">
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.IdCard.isChangePass">{{ validation.model.IdCard.message }}</p>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.Gender.isChangePass }">
                    <label class="col-sm-3 control-label">游客性别 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <div class="btn-group">
                            <div class="btn-check">
                                <input type="radio" v-model="ticket.Gender" value="1" tabindex="4">
                                <label class="btn btn-primary"><i class="fa fa-male mr10"></i>男</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="ticket.Gender" value="0" tabindex="5">
                                <label class="btn btn-primary"><i class="fa fa-female mr10"></i>女</label>
                            </div>
                        </div>
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Gender.isChangePass">{{ validation.model.Gender.message }}</p>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.SceneryId.isChangePass }">
                    <label for="focusedinput" class="col-sm-3 control-label">游玩线路 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <select-scenic :select-fn="selectScenic" :scenic.sync="scenic"></select-scenic>
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.SceneryId.isChangePass">{{ validation.model.SceneryId.message }}</p>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.PlayTime.isChangePass }">
                    <label for="focusedinput" class="col-sm-3 control-label">游玩时间 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" placeholder="请输入游玩时间" tabindex="6" v-model="ticket.PlayTime" v-datetime="ticket.PlayTime" format-datetime="yyyy/MM/dd">
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.PlayTime.isChangePass">{{ validation.model.PlayTime.message }}</p>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.BuyNumber.isChangePass }">
                    <label for="focusedinput" class="col-sm-3 control-label">购票数量 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" placeholder="请输入购票数量" tabindex="7" v-model="ticket.BuyNumber">
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.BuyNumber.isChangePass">{{ validation.model.BuyNumber.message }}</p>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.IsPay.isChangePass }">
                    <label for="focusedinput" class="col-sm-3 control-label">是否已付款 <span class="text-danger">*</span></label>
                    <div class="col-sm-8">
                        <div class="btn-group">
                            <div class="btn-check">
                                <input type="radio" v-model="ticket.IsPay" value="true" tabindex="8">
                                <label class="btn btn-primary">已付款</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="ticket.IsPay" value="false" tabindex="9">
                                <label class="btn btn-primary">未付款</label>
                            </div>
                        </div>
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.IsPay.isChangePass">{{ validation.model.IsPay.message }}</p>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.Community.isChangePass }">
                    <label for="focusedinput" class="col-sm-3 control-label">游客所属群体</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" placeholder="请输入游客所属群体" tabindex="10" v-model="ticket.Community">
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Community.isChangePass">{{ validation.model.Community.message }}</p>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.Unit.isChangePass }">
                    <label for="focusedinput" class="col-sm-3 control-label">游客所属单位(学校)</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" placeholder="请输入游客所属单位(学校)" tabindex="11" v-model="ticket.Unit">
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Unit.isChangePass">{{ validation.model.Unit.message }}</p>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.Remarks.isChangePass }">
                    <label for="focusedinput" class="col-sm-3 control-label">备注</label>
                    <div class="col-sm-8">
                        <textarea rows="4" class="form-control" placeholder="请输入备注" v-model="ticket.Remarks" tabindex="12"></textarea>
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Remarks.isChangePass">{{ validation.model.Remarks.message }}</p>
                </div>
                <div class="form-group" :class="{ 'has-error': !validation.model.Recommender.isChangePass }">
                    <label for="focusedinput" class="col-sm-3 control-label">推介人</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" placeholder="请输入推介人" v-model="ticket.Recommender" tabindex="13">
                    </div>
                    <p class="col-sm-8 col-sm-offset-3 text-danger mb0" v-if="!validation.model.Recommender.isChangePass">{{ validation.model.Recommender.message }}</p>
                </div>
            </div>
            <div class="modal-footer">
                <button type="submit" class="btn btn-block btn-purple" :disabled="!validation.isPass">保存</button>
            </div>
        </form>
    </modal>
</template>
<script>
    import { addTicket } from "../../../js/service/ticketService.js";
    import { ajax as ajaxAlert, success as successAlert, error as errorAlert } from '../../../js/lib/sweetalert/s-alert.js';

    export default {
        validation: {
            baseAttrName: "ticket",
            model: {
                Name: {
                    trim: true,
                    required: true,
                    chsNumeric: true,
                    maxlength: 20
                },
                Phone: {
                    trim: true,
                    required: true,
                    phone: true
                },
                IdCard: {
                    trim: true,
                    required: true,
                    id: true
                },
                Gender: {
                    required: true
                },
                SceneryId: {
                    required: true
                },
                PlayTime: {
                    required: true,
                    date: true
                },
                BuyNumber: {
                    required: true,
                    min: 10000,
                    int: true
                },
                IsPay: {
                    required: true
                },
                Community: {
                    maxlength: 20
                },
                Unit: {
                    maxlength: 20
                },
                Remarks: {
                    maxlength: 200
                },
                Recommender: {
                    maxlength: 20
                }
            }
        },
        watch:{
            "ticket.IdCard"(newVal) {
                if((newVal || "").length === 15) {
                    if(newVal[14] % 2 == 0) {
                        this.ticket.Gender = "0";
                    } else {
                        this.ticket.Gender = "1";
                    }
                } else if((newVal || "").length === 18) {
                    if(newVal[16] % 2 == 0) {
                        this.ticket.Gender = "0";
                    } else {
                        this.ticket.Gender = "1";
                    }
                }
            }
        },
        methods: {
            formSuccess() {
                var self = this;
                ajaxAlert("确定保存订单?", "提示", ()=>{
                    addTicket(self.ticket, (msg)=> {
                        self.visible = false;
                        self.reload();
                        successAlert(msg);
                        self.$set("scenic", {});
                        self.$set("ticket", {
                            Gender: null
                        });
                        self.$set("ticket.UserId", self.$global.user.Id > 0 ? self.$global.user.Id : null);
                        self.validation.initChangeTrue();
                    }, (msg)=>{
                        errorAlert(msg);
                    });
                });
            },
            initInfo(reload) {
                this.$set("reload", reload);
                this.$set("ticket.UserId", this.$global.user.Id > 0 ? this.$global.user.Id : null);
                this.visible = true;
            },
            selectScenic(data) {
                this.$set("ticket.SceneryId", data.Id);
            }
        },
        data() {
            return {
                visible: false,
                scenic: {},
                ticket: {
                    Gender: null
                }
            };
        },
        components: {
            modal: require("../../../components/modal/modal.vue"),
            selectScenic: require("../../../components/selectScenic/selectScenic.vue")
        }
    };
</script>