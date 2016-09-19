<template>
    <h2 class="sinfotit">权限管理 <a class=" btn btn-purple btn-label pull-right m20" href="javascript:;" @click="addInfo" v-if="action.add"><i class="fa fa-plus"></i> 新增权限</a></h2>
    <div class="panel panel-toyo m20">
        <div class="panel-heading">
            <h2>权限列表</h2>
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
                        <th class="text-left">权限名称</th>
                        <th class="text-left">权限介绍</th>
                        <th style="width: 130px">操作</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="data in dataList">
                        <td>{{ data.Name }}</td>
                        <td>{{ data.Remarks }}</td>
                        <td class="text-center">
                            <a href="javascript:;" class="btn btn-primary-alt btn-xs mr10" v-tooltip.hover :tooltip-val="'查看'" v-on:click="showInfo(data, data.Permissions)" v-if="action.see"><i class="fa fa-eye"></i></a>
                            <a href="javascript:;" class="btn btn-info-alt btn-xs mr10" v-tooltip.hover :tooltip-val="'编辑'" v-on:click="editInfo(data, data.Permissions)" v-if="action.edit"><i class="fa fa-pencil"></i></a>
                            <a href="javascript:;" class="btn btn-default-alt btn-xs" v-tooltip.hover :tooltip-val="'删除'" v-on:click="delInfo(data)" v-if="action.del"><i class="fa fa-trash-o"></i></a>
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="3" class="text-right">
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
    <add-modal v-ref:add-role-dom></add-modal>
    <edit-modal v-ref:edit-role-dom></edit-modal>
    <info-modal v-ref:info-role-dom></info-modal>
</template>

<script>
    import { getRoleList, delRole } from "../../../js/service/roleService.js";
    import gritter from "../../../js/lib/gritter/gritter.js";
    import { ajax as ajaxAlert, success as successAlert, error as errorAlert } from '../../../js/lib/sweetalert/s-alert.js';

    export default {
        data() {
            return {
                dataList: [],
                dataCount: 0,
                query: {
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
            reload(){
                var self = this;
                return function() {
                    self.reloadAsyncData();
                };
            },
            addInfo() {
                this.$refs.addRoleDom.initInfo(this.reload());
            },
            showInfo(data, permissions) {
                this.$refs.infoRoleDom.initInfo($.extend({}, data), permissions);
            },
            editInfo(data, permissions) {
                this.$refs.editRoleDom.initInfo($.extend({}, data), $.extend([], permissions), this.reload());
            },
            delInfo(data) {
                var self = this;
                ajaxAlert("确定删除权限?", "提示", ()=>{
                    delRole({
                        id: data.Id
                    }, (msg)=> {
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
            pageTemp: require("../../../components/page/page.vue")
        },
        ready(){
            var id = this.$route.params.id;
            this.$global.getMenuAtIdInitAction(id, this.action);
        },
        asyncData(resolve, reject){
            var self = this;
            getRoleList(this.query, (data) => {
                self.$set("dataList", data.datas);
                self.$set("dataCount", data.pageCount);
                resolve();
            }, (msg) => {
                reject();
            });
        }
    };
</script>