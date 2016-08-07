<style>
    .file-span{
        font-size: 15px;
        color:#f9a825;
    }
</style>
<template>
    <h2 class="sinfotit">导入线路</h2>
    <div class="panel panel-default m20">
        <div class="panel-heading"></div>
        <div class="panel-body">
            <h3 class="mt0">请选择需要导入的文件 <span class="file-span">文件只能是excel文件,文件大小不能大于5MB</span></h3>
            <p class="text-muted">文件格式必须按照该文件格式进行导入. <a :href="excel.scenery.import" target="_blank">下载模板</a></p>
            <div class="row">
                <div class="col-md-6">
                    <up-file :accept="accept" :send-url="excel.scenery.upload" :maxsize="maxsize" :send-success="sendSuccess" :send-error="sendError" :upload-before="uploadBefore"></up-file>
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
</template>
<script>
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
                errorList: []
            };
        },
        methods: {
            sendSuccess(response) {
                if(response instanceof Array) {
                    this.$set("errorList", response);
                    errorAlert("上传文件内容不正确");
                    return false;
                } else {
                    successAlert("上传成功");
                    return true;
                }
            },
            sendError() {
                errorAlert("上传文件失败");
            },
            uploadBefore(){
                this.$set("errorList", []);
            }
        },
        components: {
            upFile: require("../../../components/upFile/up-file.vue")
        }
    }
</script>