<template>
    <h2 class="sinfotit">维护景点 <a class=" btn btn-primary btn-label pull-right m20" href="javascript:;" @click="addInfo" v-if="action.add"><i class="fa fa-plus"></i> 新增景点</a></h2>
    <div class="panel panel-default m20">
        <div class="panel-heading"></div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3 form-group">
                    <label for="focusedinput" class="control-label">模糊查询-景点名称</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的景点名称" maxlength="15" v-model="name">
                </div>
                <div class="col-md-3 form-group">
                    <label for="focusedinput" class="control-label">模糊查询-景点编号</label>
                    <input type="text" class="form-control" placeholder="请输入需要查询的景点编号" maxlength="20" v-model="code">
                </div>
                <div class="col-md-3 form-group">
                    <a href="javascript:;" class="btn btn-primary mt30" @click="queryInfo">查询</a>
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-brown m20">
        <div class="panel-heading">
            <h2>景点列表</h2>
            <div class="panel-ctrls">
                <button type="button" class="btn btn-sm btn-brown" v-on:click="reloadAsyncData" :disabled="$loadingAsyncData">
                    <i class="fa fa-refresh"></i>
                </button>
                <div class="btn-group">
                    <div class="btn-check btn-check-sm">
                        <input type="radio" value="10" v-model="query.pageSize" number :disabled="$loadingAsyncData">
                        <label class="btn btn-brown">10</label>
                    </div>
                    <div class="btn-check btn-check-sm">
                        <input type="radio" value="30" v-model="query.pageSize" number :disabled="$loadingAsyncData">
                        <label class="btn btn-brown">30</label>
                    </div>
                    <div class="btn-check btn-check-sm">
                        <input type="radio" value="50" v-model="query.pageSize" number :disabled="$loadingAsyncData">
                        <label class="btn btn-brown">50</label>
                    </div>
                </div>
            </div>
        </div>
        <div class="table-responsive">
            <loading :show="$loadingAsyncData"></loading>
            <table class="table table-striped table-bordered m0">
                <thead>
                    <tr>
                        <th class="text-left">景点编号</th>
                        <th class="text-left">景点名称</th>
                        <th class="text-left">景点介绍</th>
                        <th style="width: 130px">操作</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="data in dataList">
                        <td>{{ data.Id }}</td>
                        <td>{{ data.Title }}</td>
                        <td>{{ data.Remarks }}</td>
                        <td class="text-center">
                            <a href="javascript:;" class="btn btn-primary-alt btn-xs mr10" v-tooltip.hover :tooltip-val="'查看'" v-on:click="showInfo(data)" v-if="action.see"><i class="fa fa-eye"></i></a>
                            <a href="javascript:;" class="btn btn-info-alt btn-xs mr10" v-tooltip.hover :tooltip-val="'编辑'" v-on:click="editInfo(data, data.Users)" v-if="action.edit"><i class="fa fa-pencil"></i></a>
                            <a href="javascript:;" class="btn btn-default-alt btn-xs" v-tooltip.hover :tooltip-val="'删除'" v-on:click="delInfo(data)" v-if="action.del"><i class="fa fa-trash-o"></i></a>
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="5" class="text-right">
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
    <add-modal v-ref:add-scenic-dom></add-modal>
    <edit-modal v-ref:edit-scenic-dom></edit-modal>
    <info-modal v-ref:info-scenic-dom></info-modal>
</template>

<script>
    import { getScenicList, delScenic } from "../../../js/service/scenicService.js";
    import gritter from "../../../js/lib/gritter/gritter.js";
    import { ajax as ajaxAlert, success as successAlert, error as errorAlert } from '../../../js/lib/sweetalert/s-alert.js';

    export default {
        data() {
            return {
                dataList: [],
                dataCount: 0,
                currentPage: 1,
                code: "",
                name: "",
                query: {
                    code: "",
                    name: "",
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
        methods: {
            queryInfo(){
                this.query.pageIndex = 1;
                this.query.code = this.code;
                this.query.name = this.name;
                this.reload()();
            },
            reload(){
                var self = this;
                return function() {
                    self.reloadAsyncData();
                };
            },
            addInfo() {
                this.$refs.addScenicDom.initInfo(this.reload());
            },
            showInfo(data) {
                this.$refs.infoScenicDom.initInfo(data, this.reload());
            },
            editInfo(data, users) {
                this.$refs.editScenicDom.initInfo($.extend({}, data), $.extend([], users), this.reload());
            },
            delInfo(data) {
                var self = this;
                ajaxAlert("确定删除该景点,删除将会导致某些订单一起删除?", "提示", ()=>{
                    delScenic(data.Id, (msg)=> {
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
            infoModal: require("./info.vue"),
            pageTemp: require("../../../components/page/page.vue"),
            loading: require("../../../components/logging/logging.vue")
        },
        ready(){
            var id = this.$route.params.id;
            this.$global.getMenuAtIdInitAction(id, this.action);
        },
        asyncData(resolve, reject){
            getScenicList(this.query, (data) => {
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