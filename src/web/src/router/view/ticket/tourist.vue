<style>
    .block {
        display: block;
    }
</style>
<template>
    <h2 class="sinfotit">查询游客信息</h2>
    <div class="panel panel-default m20">
        <div class="panel-heading"></div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-2 form-group">
                    <label for="focusedinput" class="control-label">验证码</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的验证码" maxlength="15" v-model="queryData.Code">
                </div>
                <div class="col-md-2 form-group">
                    <label for="focusedinput" class="control-label">游客手机号</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的游客手机号" maxlength="11" v-model="queryData.Phone">
                </div>
                <div class="col-md-2 form-group">
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
            <h2>游客列表</h2>
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
                        <th class="text-left">验证码</th>
                        <th class="text-left">游客姓名</th>
                        <th class="text-left">游客手机号码</th>
                        <th class="text-left">游客身份证</th>
                        <th class="text-left">游玩时间</th>
                        <th class="text-left">购买数量</th>
                        <th class="text-left">游玩线路</th>
                        <th class="text-left">取票状态</th>
                        <th style="width: 170px">操作</th>
                    </tr>
                </thead>
                <tbody v-if="dataList && dataList.length > 0">
                    <tr v-for="data in dataList">
                        <td>{{ data.Code }}</td>
                        <td>{{ data.Name }}</td>
                        <td>{{ data.Phone }}</td>
                        <td>{{ data.IdCard }}</td>
                        <td>{{ data.PlayTime | datetime "yyyy/MM/dd hh:mm" }}</td>
                        <td>{{ data.BuyNumber }}</td>
                        <td>{{ data.SceneryTitle }}</td>
                        <td>{{ data.TakeStateStr }}</td>
                        <td class="text-center">
                            <a href="javascript:;" class="btn btn-primary-alt btn-xs mr10" v-tooltip.hover :tooltip-val="'查看'" v-on:click="showInfo(data)"><i class="fa fa-eye"></i></a>
                        </td>
                    </tr>
                </tbody>
                <tbody v-if="!dataList || dataList.length <= 0">
                    <tr>
                        <td colspan="9" class="text-center">请查询数据</td>
                    </tr>
                </tbody>
                <tfoot v-if="dataList && dataList.length > 0">
                    <tr>
                        <td colspan="9" class="text-right">
                            <page-temp
                                :total-items="dataCount"
                                :current-page="currentPage"
                                :per-pages="query.pageSize"
                                :change="reloadAsyncData"></page-temp>
                        </td>
                    </tr>
                </tfoot>
            </table>
        </div>
    </div>
    <info-modal v-ref:info-ticket-dom></info-modal>
</template>
<script>
    import { listTicket } from "../../../js/service/ticketService.js";
    import gritter from "../../../js/lib/gritter/gritter.js";

    export default {
        data() {
            return {
                dataList: [],
                dataCount: 0,
                currentPage: 1,
                queryData: {
                    Code: "",
                    Phone: "",
                    IdCard: "",
                    PlayTime: "",
                    SceneryId: "",
                    SceneryName: ""
                },
                query: {
                    Code: "",
                    Phone: "",
                    IdCard: "",
                    PlayTime: "",
                    SceneryId: "",
                    SceneryName: "",
                    pageIndex: 1,
                    pageSize: 10
                }
            };
        },
        components: {
            pageTemp: require("../../../components/page/page.vue"),
            infoModal: require("./info.vue")
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
                this.reloadAsyncData();
            },
            showInfo(data) {
                this.$refs.infoTicketDom.initInfo($.extend({}, data));
            }
        },
        asyncData(resolve, reject){
            if(!this.query.Code && !this.query.Phone && !this.query.IdCard && !this.query.PlayTime && !this.query.SceneryId && !this.query.SceneryName) {
                resolve({
                    dataList: [],
                    dataCount: 0
                });
                return;
            }
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