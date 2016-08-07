<template>
    <div class="input-group">
        <div class="form-control">{{scenic.Title}}</div>
        <a href="javascript:;" class="input-group-addon" @click="visible = true">选择</a>
    </div>
    <select-scenic-modal :visible.sync="visible" :change="changData"></select-scenic-modal>
</template>
<script>
    export default {
        props: {
            scenic: {
                type: Object,
                default: {}
            },
            selectFn: {
                type: Function,
                default: function() {}
            }
        },
        data() {
            return {
                visible: false
            };
        },
        methods: {
            changData(data) {
                this.$set("scenic", data);
                this.selectFn(data);
                this.visible = false;
            }
        },
        components: {
            selectScenicModal: require("./selectScenicModal.vue")
        }
    }
</script>