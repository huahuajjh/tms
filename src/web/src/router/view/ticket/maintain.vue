<style>
    .block {
        display: block;
    }
</style>
<template>
    <h2 class="sinfotit">订单维护 <a class=" btn btn-purple btn-label pull-right m20" href="javascript:;" @click="addInfo" v-if="action.add"><i class="fa fa-plus"></i> 新增订单</a></h2>
    <div class="panel panel-default m20">
        <div class="panel-heading"></div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-2 form-group">
                    <label for="focusedinput" class="control-label">验证码</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的验证码" maxlength="15" v-model="queryData.Code">
                </div>
                <div class="col-md-2 form-group">
                    <label for="focusedinput" class="control-label">手机号</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的游客手机号" maxlength="11" v-model="queryData.Phone">
                </div>
                <div class="col-md-2 form-group">
                    <label for="focusedinput" class="control-label">身份证号码</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的游客身份证号码" maxlength="20" v-model="queryData.IdCard">
                </div>
                <div class="col-md-2 form-group">
                    <label for="focusedinput" class="control-label">游玩时间</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的游玩时间" maxlength="10" v-model="queryData.PlayTime" v-datetime="queryData.PlayTime" format-datetime="yyyy/MM/dd">
                </div>
                <div class="col-md-2 form-group">
                    <label for="focusedinput" class="control-label">线路编号</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的线路编号" maxlength="10" v-model="queryData.SceneryId">
                </div>
                <div class="col-md-2 form-group">
                    <label for="focusedinput" class="control-label">线路名称</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的线路名称" maxlength="15" v-model="queryData.SceneryName">
                </div>
                <div class="col-md-3 form-group">
                    <label for="focusedinput" class="control-label">创建时间段</label>
                    <calendar :startdate.sync="queryData.CreateStartTime" :enddate.sync="queryData.CreateEndTime"></calendar>
                </div>
                <div class="col-md-3 form-group">
                    <label for="focusedinput" class="control-label">取票状态</label>
                    <div class="block">
                        <div class="btn-group">
                            <div class="btn-check">
                                <input type="radio" v-model="queryData.TakeState" value="">
                                <label class="btn btn-midnightblue">所有状态</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="queryData.TakeState" value="true">
                                <label class="btn btn-midnightblue">已取票</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="queryData.TakeState" value="false">
                                <label class="btn btn-midnightblue">未取票</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 form-group">
                    <label for="focusedinput" class="control-label">付款状态</label>
                    <div class="block">
                        <div class="btn-group">
                            <div class="btn-check">
                                <input type="radio" v-model="queryData.IsPay" value="">
                                <label class="btn btn-midnightblue">所有状态</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="queryData.IsPay" value="true">
                                <label class="btn btn-midnightblue">已付款</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="queryData.IsPay" value="false">
                                <label class="btn btn-midnightblue">未付款</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 form-group">
                    <label for="focusedinput" class="control-label">审核状态</label>
                    <div class="block">
                        <div class="btn-group">
                            <div class="btn-check">
                                <input type="radio" v-model="queryData.State" value="">
                                <label class="btn btn-midnightblue">所有状态</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="queryData.State" value="0">
                                <label class="btn btn-midnightblue">未审核</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="queryData.State" value="1">
                                <label class="btn btn-midnightblue">通过审核</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="queryData.State" value="2">
                                <label class="btn btn-midnightblue">未通过审核</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <hr>
                </div>
                <div class="col-md-2 col-md-offset-10">
                    <a href="javascript:;" class="btn btn-purple btn-block" @click="queryInfo">查询</a>
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-toyo m20">
        <div class="panel-heading">
            <h2>订单列表</h2>
            <div class="panel-ctrls">
                <label type="button" class="btn btn-sm" v-on:click="reloadAsyncData">
                    <i class="fa fa-refresh"></i>
                </label>
                <div class="btn-group">
                    <div class="btn-check btn-check-sm">
                        <input type="radio" value="10" v-model="query.pageSize" number>
                        <label class="btn">10</label>
                    </div>
                    <div class="btn-check btn-check-sm">
                        <input type="radio" value="30" v-model="query.pageSize" number>
                        <label class="btn">30</label>
                    </div>
                    <div class="btn-check btn-check-sm">
                        <input type="radio" value="50" v-model="query.pageSize" number>
                        <label class="btn">50</label>
                    </div>
                </div>
            </div>
        </div>
        <div class="table-responsive">
            <table class="table table-striped table-bordered m0">
                <thead>
                    <tr>
                        <th class="text-left">游客姓名</th>
                        <th class="text-left">游客手机号码</th>
                        <th class="text-left">游客身份证</th>
                        <th class="text-left">游玩时间</th>
                        <th class="text-left">购买数量</th>
                        <th class="text-left">游玩线路</th>
                        <th class="text-left">审核状态</th>
                        <th class="text-left">取票状态</th>
                        <th class="text-left">支付状态</th>
                        <th style="width: 170px">操作</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="data in dataList">
                        <td>{{ data.Name }}</td>
                        <td>{{ data.Phone }}</td>
                        <td>{{ data.IdCard }}</td>
                        <td>{{ data.PlayTime | datetime "yyyy/MM/dd" }}</td>
                        <td>{{ data.BuyNumber }}</td>
                        <td>{{ data.SceneryTitle }}</td>
                        <td>{{ data.StateStr }}</td>
                        <td>{{ data.TakeStateStr }}</td>
                        <td>{{ data.IsPayStr }}</td>
                        <td class="text-center">
                            <a href="javascript:;" class="btn btn-primary-alt btn-xs mr10" v-tooltip.hover :tooltip-val="'查看'" v-on:click="showInfo(data)" v-if="action.see"><i class="fa fa-eye"></i></a>
                            <a href="javascript:;" class="btn btn-info-alt btn-xs mr10" v-tooltip.hover :tooltip-val="'编辑'" v-on:click="editInfo(data)" v-if="action.edit"><i class="fa fa-pencil"></i></a>
                            <a href="javascript:;" class="btn btn-default-alt btn-xs" v-tooltip.hover :tooltip-val="'删除'" v-on:click="delInfo(data)" v-if="action.del"><i class="fa fa-trash-o"></i></a>
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="10" class="text-right">
                            <page-temp
                                :total-items="dataCount"
                                :current-page.sync="query.pageIndex"
                                :per-pages="query.pageSize"
                                :change="reloadAsyncData"></page-temp>
                        </td>
                    </tr>
                </tfoot>
            </table>
        </div>
    </div>
    <add-modal v-ref:add-ticket-dom></add-modal>
    <info-modal v-ref:info-ticket-dom></info-modal>
    <edit-modal v-ref:edit-ticket-dom></edit-modal>
</template>
<script>
    import { listTicket, delTicket } from "../../../js/service/ticketService.js";
    import gritter from "../../../js/lib/gritter/gritter.js";
    import { ajax as ajaxAlert, success as successAlert, error as errorAlert } from '../../../js/lib/sweetalert/s-alert.js';

    export default {
        ready() {
            var id = this.$route.params.id;
            this.$global.getMenuAtIdInitAction(id, this.action);
        },
        data() {
            return {
                dataList: [],
                dataCount: 0,
                queryData: {
                    Code: "",
                    Phone: "",
                    IdCard: "",
                    PlayTime: "",
                    SceneryId: "",
                    SceneryName: "",
                    TakeState: "",
                    IsPay: "",
                    State: "",
                    CreateStartTime: "",
                    CreateEndTime: ""
                },
                query: {
                    Code: "",
                    Phone: "",
                    IdCard: "",
                    PlayTime: "",
                    SceneryId: "",
                    SceneryName: "",
                    TakeState: "",
                    IsPay: "",
                    State: "",
                    CreateStartTime: "",
                    CreateEndTime: "",
                    pageIndex: 1,
                    pageSize: 10
                },
                action: {
                    add: false,
                    see: false,
                    edit: false,
                    del: false
                }
            };
        },
        components: {
            "calendar": require("../../../components/calendar/calendar.vue"),
            pageTemp: require("../../../components/page/page.vue"),
            infoModal: require("./info.vue"),
            editModal: require("./edit.vue"),
            addModal: require("./add.vue")
        },
        methods: {
            queryInfo(){
                this.query.pageIndex = 1;
                this.query.Code = this.queryData.Code;
                this.query.Phone = this.queryData.Phone;
                this.query.IdCard = this.queryData.IdCard;
                this.query.PlayTime = this.queryData.PlayTime;
                this.query.SceneryId = this.queryData.SceneryId;
                this.query.SceneryName = this.queryData.SceneryName;
                this.query.TakeState = this.queryData.TakeState;
                this.query.IsPay = this.queryData.IsPay;
                this.query.State = this.queryData.State;
                this.query.CreateStartTime = this.queryData.CreateStartTime;
                this.query.CreateEndTime = this.queryData.CreateEndTime;
                this.reload()();
            },
            reload(){
                var self = this;
                return function() {
                    self.reloadAsyncData();
                };
            },
            addInfo() {
                this.$refs.addTicketDom.initInfo(this.reload());
            },
            showInfo(data) {
                this.$refs.infoTicketDom.initInfo($.extend({}, data));
            },
            delInfo(data) {
                var self = this;
                ajaxAlert("确定删除该订单?", "提示", ()=>{
                    delTicket(data.Id, (msg)=> {
                        self.reload()();
                        successAlert(msg);
                    }, (msg)=>{
                        errorAlert(msg);
                    });
                });
            },
            editInfo(data) {
                this.$refs.editTicketDom.initInfo($.extend({}, data), this.reload());
            }
        },
        asyncData(resolve, reject){
            listTicket(this.query, (data) => {
                let tData = {
                    dataList: data.Datas,
                    dataCount: data.PageCount
                }
                resolve(tData);
            }, (msg) => {
                reject();
            });
        }
    }
</script>