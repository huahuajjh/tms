<template>
    <modal title="选择景点" :static="true" :visible.sync="visible">
        <div class="modal-body">
            <div class="panel panel-default">
                <div class="panel-heading"></div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-5">
                            <label for="focusedinput" class="control-label">模糊查询-景点名称</label>
                            <input type="text" class="form-control" placeholder="请输入需要查询的账号" maxlength="15" v-model="name">
                        </div>
                        <div class="col-md-5">
                            <label for="focusedinput" class="control-label">模糊查询-景点编号</label>
                            <input type="text" class="form-control" placeholder="请输入需要查询的姓名" maxlength="20" v-model="code">
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
                        <th class="text-left">景点编号</th>
                        <th class="text-left">景点名称</th>
                        <th>操作</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="data in datas">
                        <td>{{ data.Id }}</td>
                        <td>{{ data.Title }}</td>
                        <td class="text-center">
                            <a class="btn btn-primary btn-xs pl10 pr10" href="javascript:;" @click="change(data)">选择</a>
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
    import { getScenicList } from "../../js/service/scenicService.js";
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
                code: "",
                name: "",
                query: {
                    code: "",
                    name: "",
                    pageIndex: 1,
                    pageSize: 10
                }
            };
        },
        methods: {
            queryInfo(){
                this.query.pageIndex = 1;
                this.query.code = this.code;
                this.query.name = this.name;
                this.reloadAsyncData();
            }
        },
        asyncData(resolve, reject){
            getScenicList(this.query, (data) => {
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