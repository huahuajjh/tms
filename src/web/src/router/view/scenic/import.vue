<style>
    .file-span{
        font-size: 15px;
        color:#f9a825;
    }
</style>
<template>
    <h2 class="sinfotit">导入景点</h2>
    <div class="panel panel-default m20">
        <div class="panel-heading"></div>
        <div class="panel-body">
            <h3 class="mt0">请选择需要导入的文件 <span class="file-span">文件只能是excel文件,文件大小不能大于5MB</span></h3>
            <p class="text-muted">文件格式必须按照该文件格式进行导入. <a href="javascript:;">下载模板</a></p>
            <up-file></up-file>
        </div>
    </div>
</template>
<script>
    export default {
        components: {
            upFile: require("../../../components/upFile/up-file.vue")
        }
    }
</script>