<template>
    <modal title="景点详细" :visible.sync="visible">
        <div class="panel-body">
            <form class="form-horizontal tabular-form">
                <div class="modal-body">
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-3 text-right">景点名称</label>
                        <div class="col-sm-8 tabular-border">{{scenicInfo.Title}}</div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-3 text-right">景点介绍</label>
                        <div class="col-sm-9 tabular-border">{{scenicInfo.Remarks}}</div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-3 text-right">管理人员</label>
                        <div class="col-sm-9 tabular-border">
                            <p v-for="user in scenicInfo.Users">{{user.Name}}({{user.Account}})</p>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </modal>
</template>
<script>
    export default {
        methods: {
            initInfo(data) {
                this.visible = true;
                this.$set("scenicInfo", data);
            }
        },
        data() {
            return {
                visible: false,
                scenicInfo: {}
            };
        },
        components: {
            modal: require("../../../components/modal/modal.vue")
        }
    };
</script>