<style>
    .block {
        display: block;
    }
</style>
<template>
    <h2 class="sinfotit">门票验证</h2>
    <div class="panel panel-default m20">
        <div class="panel-heading"></div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3 form-group">
                    <label for="focusedinput" class="control-label">验证码</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的订单验证码" maxlength="15" v-model="queryData.Code">
                </div>
                <div class="col-md-3 form-group">
                    <label for="focusedinput" class="control-label">游客手机号</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的游客手机号" maxlength="11" v-model="queryData.Phone">
                </div>
                <div class="col-md-3 form-group">
                    <label for="focusedinput" class="control-label">游客身份证号码</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的游客身份证号码" maxlength="20" v-model="queryData.IdCard">
                </div>
                <div class="col-md-3">
                    <a href="javascript:;" class="btn btn-purple btn-block mt30" @click="queryInfo">查询</a>
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-toyo m20">
        <div class="panel-heading">
            <h2>门票验证列表</h2>
        </div>
        <div class="table-responsive">
            <table class="table table-striped table-bordered m0">
                <thead>
                    <tr>
                        <th class="text-left">验证码</th>
                        <th class="text-left">游客姓名</th>
                        <th class="text-left">游客手机</th>
                        <th class="text-left">身份证</th>
                        <th class="text-left">性别</th>
                        <th class="text-left">线路</th>
                        <th class="text-left">出游时间</th>
                        <th style="width: 170px">操作</th>
                    </tr>
                </thead>
                <tbody v-if="dataList && dataList.length > 0">
                    <tr v-for="data in dataList">
                        <td>{{ data.Code }}</td>
                        <td>{{ data.Name }}</td>
                        <td>{{ data.Phone }}</td>
                        <td>{{ data.IdCard }}</td>
                        <td>{{ data.GenderStr }}</td>
                        <td>{{ data.SceneryTitle }}</td>
                        <td>{{ data.PlayTime | datetime "yyyy/MM/dd" }}</td>
                        <td class="text-center">
                            <a href="javascript:;" class="btn btn-primary-alt btn-xs mr10" v-tooltip.hover :tooltip-val="'取出订单'" v-on:click="takenInfo(data)" v-if="data.IsProcess"><i class="fa fa-external-link"></i></a>
                        </td>
                    </tr>
                </tbody>
                <tbody v-if="!dataList || dataList.length <= 0">
                    <tr>
                        <td colspan="8" class="text-center">没有可操作的数据</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <taken-modal v-ref:taken-ticket-dom></taken-modal>
</template>
<script>
    import { untakenListTicket } from "../../../js/service/ticketService.js";
    import gritter from "../../../js/lib/gritter/gritter.js";

    export default {
        data() {
            return {
                dataList: [],
                queryData: {
                    Code: "",
                    Phone: "",
                    IdCard: ""
                },
                query: {
                    Code: "",
                    Phone: "",
                    IdCard: "",
                    userId: null
                }
            };
        },
        ready() {
            this.$set("query.userId", this.$global.user.UserType == 2 ? this.$global.user.Id : null);
        },
        components: {
            takenModal: require("./taken.vue")
        },
        methods: {
            takenInfo(data) {
                this.$refs.takenTicketDom.initInfo($.extend({}, data), this.reload());
            },
            queryInfo(){
                this.query.pageIndex = 1;
                this.query.Code = this.queryData.Code;
                this.query.Phone = this.queryData.Phone;
                this.query.IdCard = this.queryData.IdCard;
                this.reloadDate();
            },
            reload(){
                var self = this;
                return function() {
                    self.reloadDate();
                };
            },
            reloadDate() {
                var self = this;
                untakenListTicket(this.query, (datas)=>{
                    self.$set("dataList", datas);
                }, (msg)=>{
                    gritter(msg).error();
                });
            }
        }
    }
</script>