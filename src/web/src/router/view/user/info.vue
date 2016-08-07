<template>
    <modal title="用户详细" :visible.sync="visible">
        <div class="panel-body">
            <form class="form-horizontal tabular-form">
                <div class="modal-body">
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-3 text-right">姓名</label>
                        <div class="col-sm-8 tabular-border">{{userInfo.Name}}</div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-3 text-right">账号</label>
                        <div class="col-sm-9 tabular-border">{{userInfo.Account}}</div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-3 text-right">账号类型</label>
                        <div class="col-sm-9 tabular-border">{{userInfo.TypeStr}}</div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-3 text-right">性别</label>
                        <div class="col-sm-9 tabular-border">{{ userInfo.Gender === 1 ? "男" : "女" }}</div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-3 text-right">身份证</label>
                        <div class="col-sm-9 tabular-border">{{userInfo.IdCard}}</div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-3 text-right">角色</label>
                        <div class="col-sm-9 tabular-border">{{userInfo.RoleName}}</div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-3 text-right">QQ</label>
                        <div class="col-sm-9 tabular-border">{{userInfo.Qq}}</div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-3 text-right">mail</label>
                        <div class="col-sm-9 tabular-border">{{userInfo.Mail}}</div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-3 text-right">手机</label>
                        <div class="col-sm-9 tabular-border">{{userInfo.Phone}}</div>
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
                this.$set("userInfo", data);
                this.visible = true;
            }
        },
        data() {
            return {
                visible: false,
                userInfo: {}
            };
        },
        components: {
            modal: require("../../../components/modal/modal.vue")
        }
    };
</script>