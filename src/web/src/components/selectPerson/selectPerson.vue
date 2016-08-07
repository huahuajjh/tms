<style>
    .tokenfield {
        height: auto !important;
        min-height: 32px !important;
        padding-bottom: 0px !important;
        padding: 0 !important;
    }
    .tokenfield .token {
        -webkit-box-sizing: border-box;
        -moz-box-sizing: border-box;
        box-sizing: border-box;
        -webkit-border-radius: 3px;
        -moz-border-radius: 3px;
        border-radius: 3px;
        display: inline-block;
        border: 1px solid #eeeeee;
        background-color: #eeeeee;
        white-space: nowrap;
        margin: 3px;
        height: 22px;
        vertical-align: top;
        cursor: default;
    }
    .tokenfield .token .close {
        font-family: Arial;
        display: inline-block;
        line-height: 100%;
        font-size: 1.1em;
        line-height: 1.49em;
        margin-left: 5px;
        float: none;
        height: 100%;
        vertical-align: top;
        padding-right: 4px;
        color: #263238;
        text-shadow: 0 1px 0 #ffffff;
        opacity: 0.2;
    }
    .tokenfield .token .close:hover {
        opacity: 1;
    }
    .tokenfield .token .token-label {
        display: inline-block;
        overflow: hidden;
        text-overflow: ellipsis;
        padding-left: 4px;
        vertical-align: top;
    }
</style>
<template>
    <div class="input-group">
        <div class="tokenfield form-control">
            <div class="token" v-for="selData in selectDatas">
                <span class="token-label">{{selData.Name}}({{selData.Account}})</span>
                <a href="javascript:;" class="close" @click="selectDatas.$remove(selData),changData()">×</a>
            </div>
        </div>
        <a class="input-group-addon" @click="visible = true" title="选择人员"><span href="javascript:;" class="fa fa-user"></span></a>
    </div>
    <select-user-modal :visible.sync="visible" :change="changData"></select-user-modal>
</template>
<script>

    import { getUserList } from "../../js/service/userService.js";

    export default {
        props: {
            selectFn: {
                type: Function,
                default: function () {}
            }
        },
        data() {
            return {
                visible: false,
                selectDatas: [],
            };
        },
        methods: {
            changData(data) {
                var state = false;
                if(!data) state = true;
                for(var i = 0, selData; (selData = this.selectDatas[i++]) && !state;) {
                    if(selData.Id === data.Id) {
                        state = true;
                    }
                }
                if(!state) {
                    this.selectDatas.push(data);
                }
                this.selectFn(this.selectDatas);
            },
            initSelectDatas(data) {
                this.$set("selectDatas", data);
            }
        },
        components: {
            selectUserModal: require("./selectUserModal.vue")
        }
    }
</script>