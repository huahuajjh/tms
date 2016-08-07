<template>
    <main>
        <h1>约游约呗-大学生旅游</h1>
        <div class="darkbanner">门票管理系统</div>
        <form v-validation @success="formSuccess">
            <p :class="{ 'error': !validation.model.userName.isChangePass }">
                <label class="loginlabel" for="user_name">用户名:</label>
                <input type="text" class="form-control" v-model="user.userName" :disabled="isDisabled" tabindex="1" autofocus />
                <span>{{validation.model.userName.message}}</span>
            </p>
            <p :class="{ 'error': !validation.model.userPassword.isChangePass }">
                <label class="loginlabel" for="user_password">密码:</label>
                <input type="password" class="form-control" v-model="user.userPassword" :disabled="isDisabled" tabindex="2" />
                <span>{{validation.model.userPassword.message}}</span>
            </p>
            <p class="ml50 mr50 pt20 mb0">
                <button type="submit" class="btn btn-block btn-orange" :disabled="!(validation.isPass && !isDisabled)" tabindex="3">
                    {{ isDisabled ? "正在登录..." : "登录" }}
                </button>
            </p>
        </form>
    </main>
</template>
<script>
    require("./scss/login.scss");
    import {login} from "../js/service/userService.js";
    import gritter from "../js/lib/gritter/gritter.js";

    export default {
        el: "#app",
        data() {
            return {
                user: {
                    userName: "",
                    userPassword: ""
                },
                isDisabled: false
            };
        },
        methods: {
            formSuccess() {
                let self = this;
                self.isDisabled = true;
                login(self.user, (msg)=> {
                    gritter(msg).success();
                    setTimeout(()=>{
                        location.href = "./main.html";
                    }, 2000);
                }, (msg)=>{
                    gritter(msg).error();
                    self.isDisabled = false;
                });
            }
        },
        validation: {
            baseAttrName: "user",
            model: {
                userName: {
                    trim: true,
                    required: true,
                    alphaDash: true,
                    minlength: 3,
                    maxlength: 15
                },
                userPassword: {
                    required: true,
                    alphaDash: true,
                    minlength: 5,
                    maxlength: 15
                }
            }
        }
    }
</script>