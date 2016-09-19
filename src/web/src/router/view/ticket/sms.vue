<style>
    .block {
        display: block;
    }
</style>
<template>
    <h2 class="sinfotit">维护订单短信</h2>
    <div class="panel panel-default m20">
        <div class="panel-heading"></div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3 form-group">
                    <label for="focusedinput" class="control-label">订单验证码</label>
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
                <div class="col-md-2 form-group">
                    <label for="focusedinput" class="control-label">游玩时间</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的游玩时间" maxlength="10" v-model="queryData.PlayTime" v-datetime="queryData.PlayTime" format-datetime="yyyy/MM/dd">
                </div>
                <div class="col-md-2 form-group">
                    <label for="focusedinput" class="control-label">线路编号</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的线路编号" maxlength="10" v-model="queryData.SceneryId">
                </div>
                <div class="col-md-2 form-group">
                    <label for="focusedinput" class="control-label">模糊查询-线路名称</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的线路名称" maxlength="15" v-model="queryData.SceneryName">
                </div>
                <div class="col-md-4 form-group">
                    <label for="focusedinput" class="control-label">短信发送状态</label>
                    <div class="block">
                        <div class="btn-group">
                            <div class="btn-check">
                                <input type="radio" v-model="queryData.SmsState" value="">
                                <label class="btn btn-midnightblue">所有状态</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="queryData.SmsState" value="0">
                                <label class="btn btn-midnightblue">未发送</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="queryData.SmsState" value="1">
                                <label class="btn btn-midnightblue">发送成功</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="queryData.SmsState" value="2">
                                <label class="btn btn-midnightblue">发送失败</label>
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
            <table class="table table-striped table-bordered m0">
                <thead>
                    <tr>
                        <th class="text-left"></th>
                        <th class="text-left">验证码</th>
                        <th class="text-left">游客姓名</th>
                        <th class="text-left">游客手机</th>
                        <th class="text-left">身份证</th>
                        <th class="text-left">性别</th>
                        <th class="text-left">线路</th>
                        <th class="text-left">出游时间</th>
                        <th class="text-left">短信状态</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="data in dataList" :class="{ 'success': data.CheckSend }" @click="data.CheckSend = !data.CheckSend">
                        <td><input type="checkbox" v-model="data.CheckSend" @click.stop></td>
                        <td>{{ data.Code }}</td>
                        <td>{{ data.Name }}</td>
                        <td>{{ data.Phone }}</td>
                        <td>{{ data.IdCard }}</td>
                        <td>{{ data.GenderStr }}</td>
                        <td>{{ data.SceneryTitle }}</td>
                        <td>{{ data.PlayTime | datetime "yyyy/MM/dd" }}</td>
                        <td>{{ data.SMSStateStr }}</td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="9" class="text-right">
                            <button type="button" class="btn btn-success m10 pull-left" @click="send">发送短信</button>
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
</template>
<script>
    import { listTicket, sendSMS } from "../../../js/service/ticketService.js";
    import gritter from "../../../js/lib/gritter/gritter.js";
    import { ajax as ajaxAlert, success as successAlert, error as errorAlert } from '../../../js/lib/sweetalert/s-alert.js';

    export default {
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
                    SmsState: ""
                },
                query: {
                    Code: "",
                    Phone: "",
                    IdCard: "",
                    PlayTime: "",
                    SceneryId: "",
                    SceneryName: "",
                    SmsState: "",
                    State: 1,
                    pageIndex: 1,
                    pageSize: 10
                }
            };
        },
        components: {
            pageTemp: require("../../../components/page/page.vue")
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
                this.query.SmsState = this.queryData.SmsState;
                this.reloadAsyncData();
            },
            send() {
                var datas = [];
                var self = this;
                for(var i = 0, data; data = this.dataList[i++];){
                    if(data.CheckSend) {
                        datas.push(data.Id);
                    }
                }
                ajaxAlert("确定提交处理?", "提示", ()=>{
                    if(datas.length <= 0) {
                        setTimeout(()=>{errorAlert("没有数据可提交");}, 100);
                        return;
                    }
                    sendSMS(self.$JSON.stringify(datas), (msg)=> {
                        self.reloadAsyncData();
                        successAlert(msg);
                    }, (msg)=>{
                        errorAlert(msg);
                    });
                });
            }
        },
        asyncData(resolve, reject){
            listTicket(this.query, (data) => {
                if(data.Datas) {
                    for(var i = 0,d; d = data.Datas[i++];) {
                        d.CheckSend = false;
                    }
                }
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