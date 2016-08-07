<style>
    .block {
        display: block;
    }
</style>
<template>
    <h2 class="sinfotit">用户维护 <a class=" btn btn-purple btn-label pull-right m20" href="javascript:;" @click="addInfo" v-if="action.add"><i class="fa fa-plus"></i> 新增用户</a></h2>
    <div class="panel panel-default m20">
        <div class="panel-heading"></div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3 form-group">
                    <label for="focusedinput" class="control-label">模糊查询-账号</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的账号" maxlength="15" v-model="account">
                </div>
                <div class="col-md-3 form-group">
                    <label for="focusedinput" class="control-label">模糊查询-姓名</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的姓名" maxlength="20" v-model="name">
                </div>
                <div class="col-md-6 form-group">
                    <label for="focusedinput" class="control-label">查询账号类型</label>
                    <div class="block">
                        <div class="btn-group">
                            <div class="btn-check">
                                <input type="radio" v-model="type" value="">
                                <label class="btn btn-midnightblue">所有类型</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="type" value="0">
                                <label class="btn btn-midnightblue">管理员</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="type" value="1">
                                <label class="btn btn-midnightblue">代理商</label>
                            </div>
                            <div class="btn-check">
                                <input type="radio" v-model="type" value="2">
                                <label class="btn btn-midnightblue">景点管理员</label>
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
            <h2>用户列表</h2>
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
                        <th class="text-left">姓名</th>
                        <th class="text-left">账号</th>
                        <th class="text-left">性别</th>
                        <th class="text-left">身份证</th>
                        <th class="text-left">角色</th>
                        <th class="text-left">状态</th>
                        <th style="width: 170px">操作</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="data in dataList">
                        <td>{{ data.Name }}</td>
                        <td>{{ data.Account }}</td>
                        <td>{{ data.Gender === 1 ? "男" : "女" }}</td>
                        <td>{{ data.IdCard }}</td>
                        <td>{{ data.TypeStr }}({{ data.RoleName }})</td>
                        <td>{{ data.Title }}</td>
                        <td class="text-center">
                            <a href="javascript:;" class="btn btn-primary-alt btn-xs mr10" v-tooltip.hover :tooltip-val="'查看'" v-on:click="showInfo(data)" v-if="action.see"><i class="fa fa-eye"></i></a>
                            <a href="javascript:;" class="btn btn-info-alt btn-xs mr10" v-tooltip.hover :tooltip-val="'编辑'" v-on:click="editInfo(data)" v-if="action.edit"><i class="fa fa-pencil"></i></a>
                            <a href="javascript:;" class="btn btn-warning-alt btn-xs mr10" v-tooltip.hover :tooltip-val="'重置密码'" v-on:click="resetPassword(data)" v-if="action.password"><i class="fa fa-lock"></i></a>
                            <a href="javascript:;" class="btn btn-inverse-alt btn-xs mr10" v-tooltip.hover :tooltip-val="'账号状态'" v-on:click="stateInfo(data)" v-if="action.state"><i class="fa fa-cogs"></i></a>
                            <a href="javascript:;" class="btn btn-default-alt btn-xs" v-tooltip.hover :tooltip-val="'删除'" v-on:click="delInfo(data)" v-if="action.del"><i class="fa fa-trash-o"></i></a>
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="7" class="text-right">
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
    <add-modal v-ref:add-user-dom></add-modal>
    <state-modal v-ref:state-user-dom></state-modal>
    <edit-modal v-ref:edit-user-dom></edit-modal>
    <info-modal v-ref:info-user-dom></info-modal>
</template>

<script>
    import { getUserList, delUser, resetPassword } from "../../../js/service/userService.js";
    import gritter from "../../../js/lib/gritter/gritter.js";
    import { ajax as ajaxAlert, success as successAlert, error as errorAlert } from '../../../js/lib/sweetalert/s-alert.js';

    export default {
        data() {
            return {
                dataList: [],
                dataCount: 0,
                currentPage: 1,
                account: "",
                name: "",
                type: "",
                query: {
                    account: "",
                    name: "",
                    type: "",
                    pageIndex: 1,
                    pageSize: 10
                },
                action: {
                    add: false,
                    see: false,
                    edit: false,
                    del: false,
                    state: false,
                    password: false,
                }
            };
        },
        methods: {
            queryInfo(){
                this.query.pageIndex = 1;
                this.query.account = this.account;
                this.query.name = this.name;
                this.query.type = this.type;
                this.reload()();
            },
            reload(){
                var self = this;
                return function() {
                    self.reloadAsyncData();
                };
            },
            addInfo() {
                this.$refs.addUserDom.initInfo(this.reload());
            },
            showInfo(data) {
                this.$refs.infoUserDom.initInfo($.extend({}, data));
            },
            editInfo(data) {
                this.$refs.editUserDom.initInfo($.extend({}, data), this.reload());
            },
            stateInfo(data) {
                this.$refs.stateUserDom.initInfo($.extend({}, data), this.reload());
            },
            resetPassword(data) {
                var self = this;
                ajaxAlert("确定重置该用户的密码为'123456'?", "提示", ()=>{
                    resetPassword(data.Id, (msg)=> {
                        successAlert(msg);
                    }, (msg)=>{
                        errorAlert(msg);
                    });
                });
            },
            delInfo(data) {
                var self = this;
                ajaxAlert("确定删除用户?", "提示", ()=>{
                    delUser(data.Id, (msg)=> {
                        self.reload()();
                        successAlert(msg);
                    }, (msg)=>{
                        errorAlert(msg);
                    });
                });
            }
        },
        components: {
            addModal: require("./add.vue"),
            editModal: require("./edit.vue"),
            stateModal: require("./state.vue"),
            infoModal: require("./info.vue"),
            pageTemp: require("../../../components/page/page.vue")
        },
        ready(){
            var id = this.$route.params.id;
            this.$global.getMenuAtIdInitAction(id, this.action);
        },
        asyncData(resolve, reject){
            getUserList(this.query, (data) => {
                let tData = {
                    dataList: data.Datas,
                    dataCount: data.PageCount
                }
                resolve(tData);
            }, (msg) => {
                reject();
            });
        }
    };
</script>