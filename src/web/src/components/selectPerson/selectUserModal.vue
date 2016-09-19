<template>
    <modal title="选择用户" :static="true" :visible.sync="visible">
        <div class="modal-body">
            <div class="panel panel-default">
                <div class="panel-heading"></div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6">
                            <label for="focusedinput" class="control-label">模糊查询-账号</label>
                            <input type="text" class="form-control" placeholder="请输入需要查询的账号" maxlength="15" v-model="account">
                        </div>
                        <div class="col-md-6">
                            <label for="focusedinput" class="control-label">模糊查询-姓名</label>
                            <input type="text" class="form-control" placeholder="请输入需要查询的姓名" maxlength="20" v-model="name">
                        </div>
                        <div class="col-md-7">
                            <label for="focusedinput" class="control-label">查询账号类型</label>
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
                        <div class="col-md-2">
                            <a href="javascript:;" class="btn btn-primary mt30" @click="queryInfo">查询</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="table-responsive">
            <table v-el:table class="table table-striped table-bordered m0">
                <thead>
                    <tr>
                        <th class="text-left">姓名</th>
                        <th class="text-left">账号</th>
                        <th class="text-left">角色</th>
                        <th class="text-left">状态</th>
                        <th>操作</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="data in datas">
                        <td>{{data.Name}}</td>
                        <td>{{data.Account}}</td>
                        <td>{{data.RoleName}}</td>
                        <td>{{data.Title}}</td>
                        <td class="text-center">
                            <a class="btn btn-primary btn-xs pl10 pr10" href="javascript:;" @click="change(data),datas.$remove(data)">选择</a>
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="5" class="text-right">
                            <page-temp
                                :total-items="totalItems"
                                :show-pages="10"
                                :current-page.sync="query.pageIndex"
                                :per-pages="query.pageSize"
                                :change="reloadAsyncData"></page-temp>
                        </td>
                    </tr>
                </tfoot>
            </table>
        </div>
    </modal>
</template>
<script>
    import { getUserList } from "../../js/service/userService.js";
    import gritter from "../../js/lib/gritter/gritter.js";

    export default {
        props: {
            visible: {
                type: Boolean,
                default: false
            },
            change: {
                type: Function,
                default: function() {}
            }
        },
        data() {
            return {
                datas: [],
                totalItems: 0,
                account: "",
                name: "",
                type: "",
                query: {
                    type: "",
                    account: "",
                    name: "",
                    pageIndex: 1,
                    pageSize: 10
                }
            };
        },
        methods: {
            queryInfo(){
                this.query.pageIndex = 1;
                this.query.account = this.account;
                this.query.name = this.name;
                this.query.type = this.type;
                this.reloadAsyncData();
            }
        },
        asyncData(resolve, reject){
            getUserList(this.query, (data) => {
                let tData = {
                    datas: data.Datas,
                    totalItems: data.PageCount
                }
                resolve(tData);
            }, (msg) => {
                gritter(msg).error();
            });
        },
        components: {
            pageTemp: require("../page/page.vue"),
            modal: require("../modal/modal.vue")
        }
    }
</script>