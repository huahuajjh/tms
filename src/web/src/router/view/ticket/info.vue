<style>
    .form-group-info {
        padding: 5px 12px !important;
    }
</style>
<template>
    <modal title="订单详细" :visible.sync="visible">
        <div class="panel-body">
            <form class="form-horizontal tabular-form">
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
                        <div class="col-sm-9 tabular-border">{{info.PlayTime | datetime "yyyy/MM/dd hh:mm"}}</div>
                    </div>
                    <div class="form-group form-group-info">
                        <label for="focusedinput" class="col-sm-3 text-right">购票数量</label>
                        <div class="col-sm-9 tabular-border">{{info.BuyNumber}}</div>
                    </div>
                    <div class="form-group form-group-info">
                        <label for="focusedinput" class="col-sm-3 text-right">付款状态</label>
                        <div class="col-sm-9 tabular-border">{{info.IsPayStr}}</div>
                    </div>
                    <div class="form-group form-group-info">
                        <label for="focusedinput" class="col-sm-3 text-right">短信状态</label>
                        <div class="col-sm-8 tabular-border">{{info.SMSStateStr}}</div>
                    </div>
                    <div class="form-group form-group-info">
                        <label for="focusedinput" class="col-sm-3 text-right">取票状态</label>
                        <div class="col-sm-8 tabular-border">{{info.TakeStateStr}}</div>
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
                    <div class="form-group form-group-info">
                        <label for="focusedinput" class="col-sm-3 text-right">推介人</label>
                        <div class="col-sm-9 tabular-border">{{info.Recommender}}</div>
                    </div>
                    <div class="form-group form-group-info">
                        <label for="focusedinput" class="col-sm-3 text-right">订单状态</label>
                        <div class="col-sm-9 tabular-border">{{info.StateStr}}</div>
                    </div>
                    <div class="form-group form-group-info">
                        <label for="focusedinput" class="col-sm-3 text-right">订单审核人员</label>
                        <div class="col-sm-9 tabular-border" v-if="info.State != 0 && !info.StateUserAccount">超级管理员</div>
                        <div class="col-sm-9 tabular-border" v-if="info.State != 0 && info.StateUserAccount">{{info.StateUserName}}({{info.StateUserAccount}})</div>
                        <div class="col-sm-9 tabular-border" v-if="info.State == 0"></div>
                    </div>
                    <div class="form-group form-group-info">
                        <label for="focusedinput" class="col-sm-3 text-right">订单审核描述</label>
                        <div class="col-sm-9 tabular-border">{{info.StateMsg}}</div>
                    </div>
                </div>
            </form>
        </div>
    </modal>
</template>
<script>
    export default {
        methods: {
            initInfo(data) {
                this.$set("info", data);
                this.visible = true;
            }
        },
        data() {
            return {
                visible: false,
                info: {}
            };
        },
        components: {
            modal: require("../../../components/modal/modal.vue")
        }
    };
</script>