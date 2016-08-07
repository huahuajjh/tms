<style>
    .file-span{
        font-size: 15px;
        color:#f9a825;
    }
</style>
<template>
    <h2 class="sinfotit">导入订单</h2>
    <div class="panel panel-default m20">
        <div class="panel-heading"></div>
        <div class="panel-body">
            <h3 class="mt0">请选择需要导入的文件 <span class="file-span">文件只能是excel文件,文件大小不能大于5MB</span></h3>
            <p class="text-muted">文件格式必须按照该文件格式进行导入. <a :href="excel.ticket.import" target="_blank">下载模板</a>.如果不知道线路编号,可以下载 <a :href="excel.scenery.export" target="_blank">线路编号文件</a></p>
            <div class="row">
                <div class="col-md-6">
                    <up-file :send-data.sync="sendData" :accept="accept" :send-url="excel.ticket.upload" :maxsize="maxsize" :send-success="sendSuccess" :send-error="sendError" :upload-before="uploadBefore"></up-file>
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-danger m20" v-if="errorList && errorList.length > 0">
        <div class="panel-heading"></div>
        <div class="panel-body">
            <h3 class="mt0 text-danger">导入错误信息</h3>
            <p class="text-danger" v-for="error in errorList"><i class="fa fa-times-circle mr10"></i>{{error}}</p>
        </div>
    </div>
    <div class="panel panel-warning m20" v-if="repeatList && repeatList.length > 0">
        <div class="panel-heading"></div>
        <div class="panel-body">
            <h3 class="mt0 text-warning">重复导入的数据(非重复的数据已经成功导入)</h3>
            <table class="table mb0">
                <thead>
                    <tr>
                        <th class="text-left">游客名称</th>
                        <th class="text-left">游客手机号码</th>
                        <th class="text-left">游客身份证</th>
                        <th class="text-left">游客性别</th>
                        <th class="text-left">游玩线路编号</th>
                        <th class="text-left">游玩时间</th>
                        <th class="text-left">购票数量</th>
                        <th class="text-left">是否已付款</th>
                        <th class="text-left">游客所属群体</th>
                        <th class="text-left">游客所属单位(学校)</th>
                        <th class="text-left">备注</th>
                        <th class="text-left">推介人</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="repeat in repeatList">
                        <td>{{ repeat.Name }}</td>
                        <td>{{ repeat.Phone }}</td>
                        <td>{{ repeat.IdCard }}</td>
                        <td>{{ repeat.Gender }}</td>
                        <td>{{ repeat.SceneryId }}</td>
                        <td>{{ repeat.PlayTime | datetime "yyyy/MM/dd hh:ss" }}</td>
                        <td>{{ repeat.BuyNumber }}</td>
                        <td>{{ repeat.IsPay }}</td>
                        <td>{{ repeat.Community }}</td>
                        <td>{{ repeat.Unit }}</td>
                        <td>{{ repeat.Remarks }}</td>
                        <td>{{ repeat.Recommender }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>
<script>
    import global from "../../../js/globalMethod/global.js";
    import {excel} from "../../../js/helpers/apiUrl.js";
    import gritter from "../../../js/lib/gritter/gritter.js";
    import { success as successAlert, error as errorAlert } from '../../../js/lib/sweetalert/s-alert.js';

    export default {
        data() {
            return {
                excel: excel,
                accept: {
                    title: 'Excel',
                    extensions: 'xls',
                    mimeTypes: 'application/vnd.ms-excel'
                },
                maxsize: 5242880,
                errorList: [],
                repeatList: [],
                sendData: {
                    userId: global.user.Id < 0 ? null : global.user.Id
                }
            };
        },
        methods: {
            sendSuccess(response) {
                if(response && response.type) {
                    if(response.type == "error") {
                        this.$set("errorList", response.datas);
                        errorAlert("上传文件内容不正确");
                        return false;
                    } else if(response.type == "repeat") {
                        this.$set("repeatList", response.datas);
                    }
                }
                successAlert("上传成功");
                return true;
            },
            sendError() {
                errorAlert("上传文件失败");
            },
            uploadBefore(){
                this.$set("errorList", []);
                this.$set("repeatList", []);
            }
        },
        components: {
            upFile: require("../../../components/upFile/up-file.vue")
        }
    }
</script>