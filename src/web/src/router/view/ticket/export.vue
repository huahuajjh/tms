<style>
    .block {
        display: block;
    }
</style>
<template>
    <h2 class="sinfotit">导出订单</h2>
    <div class="panel panel-default m20">
        <div class="panel-heading"></div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-2 form-group">
                    <label for="focusedinput" class="control-label">线路编号</label>
                    <input type="text" class="form-control" placeholder="请输入线路编号" maxlength="10" v-model="query.SceneryId">
                </div>
                <div class="col-md-2 form-group">
                    <label for="focusedinput" class="control-label">线路名称</label>
                    <input type="text" class="form-control" placeholder="请输入线路名称" maxlength="20" v-model="query.SceneryName">
                </div>
                <div class="col-md-2 form-group">
                    <label for="focusedinput" class="control-label">游玩时间</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的游玩时间" maxlength="10" v-model="query.PlayTime" v-datetime="query.PlayTime" format-datetime="yyyy/MM/dd">
                </div>
                <div class="col-md-2 form-group">
                    <label for="focusedinput" class="control-label">推介人</label>
                    <input type="text" class="form-control" placeholder="请输入推介人" maxlength="20" v-model="query.Recommender">
                </div>
                <div class="col-md-4 form-group">
                    <label for="focusedinput" class="control-label">审核状态</label>
                    <div class="block">
                        <div class="btn-group">
                            <div class="btn-check">
                                <input type="radio" v-model="query.State" value="">
                                <label class="btn btn-midnightblue">所有状态</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="query.State" value="0">
                                <label class="btn btn-midnightblue">未审核</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="query.State" value="1">
                                <label class="btn btn-midnightblue">通过审核</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="query.State" value="2">
                                <label class="btn btn-midnightblue">未通过审核</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 form-group">
                    <label for="focusedinput" class="control-label">创建时间段</label>
                    <calendar :startdate.sync="query.CreateStartTime" :enddate.sync="query.CreateEndTime"></calendar>
                </div>
                <div class="col-md-3 form-group">
                    <label for="focusedinput" class="control-label">取票状态</label>
                    <div class="block">
                        <div class="btn-group">
                            <div class="btn-check">
                                <input type="radio" v-model="query.TakeState" value="">
                                <label class="btn btn-midnightblue">所有状态</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="query.TakeState" value="true">
                                <label class="btn btn-midnightblue">已取票</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="query.TakeState" value="false">
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
                                <input type="radio" v-model="query.IsPay" value="">
                                <label class="btn btn-midnightblue">所有状态</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="query.IsPay" value="true">
                                <label class="btn btn-midnightblue">已付款</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="query.IsPay" value="false">
                                <label class="btn btn-midnightblue">未付款</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 form-group">
                    <label for="focusedinput" class="control-label">短信发送状态</label>
                    <div class="block">
                        <div class="btn-group">
                            <div class="btn-check">
                                <input type="radio" v-model="query.SmsState" value="">
                                <label class="btn btn-midnightblue">所有状态</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="query.SmsState" value="0">
                                <label class="btn btn-midnightblue">未发送</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="query.SmsState" value="1">
                                <label class="btn btn-midnightblue">发送成功</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="query.SmsState" value="2">
                                <label class="btn btn-midnightblue">发送失败</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <hr>
                </div>
                <div class="col-md-2 col-md-offset-4 text-right" v-if="isShowSelectPerson">
                    <label class="control-label" style="margin-top: 5px;">导出指定的人:</label>
                </div>
                <div class="col-md-4" v-if="isShowSelectPerson">
                    <select-person v-ref:select-dom :select-fn="selectUser"></select-person>
                </div>
                <div class="col-md-2" :class="{ 'col-md-offset-10': !isShowSelectPerson }">
                    <a href="javascript:;" class="btn btn-purple btn-block" @click="download">导出</a>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
    import {excel} from "../../../js/helpers/apiUrl.js";
    import global from '../../../js/globalMethod/global.js';

    export default {
        components: {
            "calendar": require("../../../components/calendar/calendar.vue"),
            selectPerson: require("../../../components/selectPerson/selectPerson.vue")
        },
        data() {
            return {
                isShowSelectPerson: global.user.UserType == 1 ? false : true,
                query: {
                    CreateUserId: global.user.UserType == 1 ? global.user.Id : null,
                    SceneryId: "",
                    SceneryName: "",
                    PlayTime: "",
                    Recommender: "",
                    State: "",
                    CreateStartTime: "",
                    CreateEndTime: "",
                    TakeState: "",
                    IsPay: "",
                    SmsState: "",
                    CreateIds: ""
                }
            };
        },
        methods: {
            selectUser(datas) {
                var ids = [];
                for(var i = 0, item; item = datas[i++];) {
                    ids.push(item.Id);
                }
                this.$set("query.CreateIds", ids.join(","));
            },
            download() {
                var url = excel.ticket.export + "?" + $.param(this.query);
                window.open(url);
            }
        }
    }
</script>