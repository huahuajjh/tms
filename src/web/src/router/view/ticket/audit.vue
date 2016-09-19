<style>
    .block {
        display: block;
    }
</style>
<template>
    <h2 class="sinfotit">审核订单</h2>
    <div class="panel panel-default m20">
        <div class="panel-heading"></div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3 form-group">
                    <label for="focusedinput" class="control-label">游客手机号</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的游客手机号" maxlength="11" v-model="queryData.Phone">
                </div>
                <div class="col-md-3 form-group">
                    <label for="focusedinput" class="control-label">游客身份证号码</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的游客身份证号码" maxlength="20" v-model="queryData.IdCard">
                </div>
                <div class="col-md-3 form-group">
                    <label for="focusedinput" class="control-label">游玩时间</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的游玩时间" maxlength="10" v-model="queryData.PlayTime" v-datetime="queryData.PlayTime" format-datetime="yyyy/MM/dd">
                </div>
                <div class="col-md-3 form-group">
                    <label for="focusedinput" class="control-label">线路编号</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的线路编号" maxlength="10" v-model="queryData.SceneryId">
                </div>
                <div class="col-md-3 form-group">
                    <label for="focusedinput" class="control-label">模糊查询-线路名称</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的线路名称" maxlength="15" v-model="queryData.SceneryName">
                </div>
                <div class="col-md-3 form-group">
                    <label for="focusedinput" class="control-label">指定审核人</label>
                    <select-person v-ref:select-dom :select-fn="selectUser"></select-person>
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
                <div class="col-md-3">
                    <a href="javascript:;" class="btn btn-purple btn-block mt30" @click="queryInfo">查询</a>
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-toyo m20">
        <div class="panel-heading">
            <h2>订单列表</h2>
            <div class="panel-ctrls">
                <label type="button" class="btn btn-sm" v-on:click="reloadAsyncData" :disabled="$loadingAsyncData">
                    <i class="fa fa-refresh"></i>
                </label>
                <div class="btn-group">
                    <div class="btn-check btn-check-sm">
                        <input type="radio" value="10" v-model="query.pageSize" number :disabled="$loadingAsyncData">
                        <label class="btn">10</label>
                    </div>
                    <div class="btn-check btn-check-sm">
                        <input type="radio" value="30" v-model="query.pageSize" number :disabled="$loadingAsyncData">
                        <label class="btn">30</label>
                    </div>
                    <div class="btn-check btn-check-sm">
                        <input type="radio" value="50" v-model="query.pageSize" number :disabled="$loadingAsyncData">
                        <label class="btn">50</label>
                    </div>
                </div>
            </div>
        </div>
        <div class="table-responsive">
            <table class="table table-striped table-bordered m0" style="white-space: nowrap;">
                <thead>
                    <tr>
                        <th class="text-centext">
                            审核 <br>
                            <label><input type="radio" v-model="auditAll" value="0"> 未审核</label>
                            <label class="ml5 mr5"><input type="radio" v-model="auditAll" value="1"> 通过审核</label>
                            <label><input type="radio" v-model="auditAll" value="2"> 未通过审核</label>
                        </th>
                        <th class="text-left mb10">
                            是否产生验证码
                            <br>
                            <label><input type="radio" v-model="checkCodeAll" value="0"> 无验证码</label>
                            <label class="ml5 mr5"><input type="radio" v-model="checkCodeAll" value="1"> 有验证码</label>
                            <label><input type="radio" v-model="checkCodeAll" value="2"> 自定义发送短信</label>
                        </th>
                        <th class="text-left">支付状态</th>
                        <th class="text-left">游玩线路</th>
                        <th class="text-left">游客姓名</th>
                        <th class="text-left">性别</th>
                        <th class="text-left">游客手机号码</th>
                        <th class="text-left">游客身份证</th>
                        <th class="text-left">游玩时间</th>
                        <th class="text-left">购买数量</th>
                        <th class="text-left">所属群体</th>
                        <th class="text-left">所属单位</th>
                        <th class="text-left">推介人</th>
                        <th class="text-left">备注</th>
                    </tr>
                </thead>
                <tbody v-for="data in dataList">
                    <tr>
                        <td class="text-center info">
                            <div class="form-control-static">
                                <label><input type="radio" v-model="data.State" value="0" @change="isCheckAudit"> 未审核</label>
                                <label class="ml5 mr5"><input type="radio" v-model="data.State" value="1" @change="isCheckAudit"> 通过审核</label>
                                <label><input type="radio" v-model="data.State" value="2" @change="isCheckAudit"> 未通过审核</label>
                            </div>
                        </td>
                        <td class="info">
                            <label><input type="radio" v-model="data.IsCode" value="0" @change="isCheckCode"> 无验证码</label>
                            <label class="ml5 mr5"><input type="radio" v-model="data.IsCode" value="1" @change="isCheckCode"> 有验证码</label>
                            <label><input type="radio" v-model="data.IsCode" value="2" @change="isCheckCode"> 自定义发送短信</label>
                            <input v-if="data.IsCode == 2" type="text" class="form-control" v-model="data.SMSContext" maxlength="200" placeholder="请输入短信内容" style="display: inline-block; width: 180px;">
                        </td>
                        <td><div class="form-control-static">{{ data.IsPayStr }}</div></td>
                        <td><div class="form-control-static">{{ data.SceneryTitle }}</div></td>
                        <td><div class="form-control-static">{{ data.Name }}</div></td>
                        <td><div class="form-control-static">{{ data.GenderStr }}</div></td>
                        <td><div class="form-control-static">{{ data.Phone }}</div></td>
                        <td><div class="form-control-static">{{ data.IdCard }}</div></td>
                        <td><div class="form-control-static">{{ data.PlayTime | datetime "yyyy/MM/dd" }}</div></td>
                        <td><div class="form-control-static">{{ data.BuyNumber }}</div></td>
                        <td><div class="form-control-static">{{ data.Community }}</div></td>
                        <td><div class="form-control-static">{{ data.Unit }}</div></td>
                        <td><div class="form-control-static">{{ data.Recommender }}</div></td>
                        <td><div class="form-control-static">{{ data.Remarks }}</div></td>
                    </tr>
                    <tr>
                        <td colspan="14" v-if="data.CreateUserAccount">
                            <span class="mr20">添加人信息: {{ data.CreateUserName }}({{data.CreateUserAccount}})</span>
                            <span class="mr10 ml10" v-if="data.CreateMail"><i class="fa fa-envelope-o mr10"></i>{{data.CreateMail}}</span>
                            <span class="mr10 ml10" v-if="data.Qq"><i class="fa fa-qq"></i>{{data.Qq}}</span>
                            <span class="mr10 ml10" v-if="data.CreatePhone"><i class="fa fa-phone mr10"></i>{{data.CreatePhone}}</span>
                        </td>
                        <td colspan="14" v-if="!data.CreateUserAccount">
                            添加人信息: 超级管理员
                        </td>
                    </tr>
                    <tr class="success">
                        <td colspan="14">
                            <input type="text" class="form-control" v-model="data.StateMsg" maxlength="200" placeholder="请输入审核备注">
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="14">
                            <div class="row">
                                <div class="col-sm-3 col-xs-3">
                                    <button type="button" class="btn btn-success m10" @click="subData">处理选中的数据并且发送短信</button>
                                </div>
                                <div class="col-sm-9 col-xs-9">
                                    <page-temp
                                        :total-items="dataCount"
                                        :current-page.sync="query.pageIndex"
                                        :per-pages="query.pageSize"
                                        :change="reloadAsyncData"></page-temp>
                                </div>
                            </div>
                        </td>
                    </tr>
                </tfoot>
            </table>
        </div>
    </div>
</template>
<script>
    import { listTicket, auditTicket } from "../../../js/service/ticketService.js";
    import gritter from "../../../js/lib/gritter/gritter.js";
    import { ajax as ajaxAlert, success as successAlert, error as errorAlert } from '../../../js/lib/sweetalert/s-alert.js';

    export default {
        data() {
            return {
                auditAll: "0",
                checkCodeAll: "0",
                dataList: [],
                dataCount: 0,
                queryData: {
                    Phone: "",
                    IdCard: "",
                    PlayTime: "",
                    SceneryId: "",
                    SceneryName: "",
                    IsPay: ""
                },
                query: {
                    CreateIds: "",
                    Phone: "",
                    IdCard: "",
                    PlayTime: "",
                    SceneryId: "",
                    SceneryName: "",
                    IsPay: "",
                    State: 0,
                    pageIndex: 1,
                    pageSize: 10
                }
            };
        },
        watch:{
            auditAll(value) {
                for(var i = 0, data; data = this.dataList[i++];){
                    data.State = value;
                }
            },
            checkCodeAll(value) {
                for(var i = 0, data; data = this.dataList[i++];){
                    data.IsCode = value;
                }
            }
        },
        components: {
            pageTemp: require("../../../components/page/page.vue"),
            infoModal: require("./info.vue"),
            selectPerson: require("../../../components/selectPerson/selectPerson.vue")
        },
        methods: {
            queryInfo(){
                this.query.pageIndex = 1;
                this.query.Phone = this.queryData.Phone;
                this.query.IdCard = this.queryData.IdCard;
                this.query.PlayTime = this.queryData.PlayTime;
                this.query.SceneryId = this.queryData.SceneryId;
                this.query.SceneryName = this.queryData.SceneryName;
                this.query.IsPay = this.queryData.IsPay;
                this.reloadAsyncData();
            },
            subData() {
                var datas = [];
                var self = this;
                for(var i = 0, data; data = this.dataList[i++];){
                    if(data.State != "0") {
                        datas.push({
                            Id: data.Id,
                            State: data.State,
                            StateMsg: data.StateMsg,
                            IsStateCode: data.IsCode,
                            StateUserId: this.$global.user.Id > 0 ? this.$global.user.Id : null,
                            SMSContext: data.SMSContext
                        });
                    }
                }
                ajaxAlert("确定提交处理?", "提示", ()=>{
                    if(datas.length <= 0) {
                        setTimeout(()=>{errorAlert("没有数据可提交");}, 100);
                        return;
                    }
                    auditTicket(self.$JSON.stringify(datas), (msg)=> {
                        self.reloadAsyncData();
                        successAlert(msg);
                    }, (msg)=>{
                        errorAlert(msg);
                    });
                });
            },
            isCheckAudit() {
                var self = this;
                setTimeout(function() {
                    var not = true;
                    var pass = true;
                    var notPass = true;
                    for(var i = 0, data; data = self.dataList[i++];){
                        if(data.State == "0") {
                            pass = false;
                            notPass = false;
                        } else if(data.State == "1") {
                            not = false;
                            notPass = false;
                        } else if(data.State == "2") {
                            not = false;
                            pass = false;
                        }
                    }
                    if(not) {
                        self.auditAll = "0";
                    } else if(pass) {
                        self.auditAll = "1";
                    } else if(notPass) {
                        self.auditAll = "2";
                    }
                }, 0);
            },
            isCheckCode() {
                var self = this;
                setTimeout(function() {
                    var not = true;
                    var pass = true;
                    var notPass = true;
                    for(var i = 0, data; data = self.dataList[i++];){
                        if(data.IsCode == "0") {
                            pass = false;
                            notPass = false;
                        } else if(data.IsCode == "1") {
                            not = false;
                            notPass = false;
                        } else if(data.IsCode == "2") {
                            not = false;
                            pass = false;
                        }
                    }
                    if(not) {
                        self.checkCodeAll = "0";
                    } else if(pass) {
                        self.checkCodeAll = "1";
                    } else if(notPass) {
                        self.checkCodeAll = "2";
                    }
                }, 0);
            },
            selectUser(datas) {
                var ids = [];
                for(var i = 0, item; item = datas[i++];) {
                    ids.push(item.Id);
                }
                this.$set("query.CreateIds", ids.join(","));
            }
        },
        asyncData(resolve, reject){
            listTicket(this.query, (data) => {
                let tData = {
                    dataList: data.Datas,
                    dataCount: data.PageCount,
                    auditAll: "0",
                    checkCodeAll: false
                }
                resolve(tData);
            }, (msg) => {
                reject();
            });
        }
    }
</script>