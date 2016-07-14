import {user} from "../helpers/apiUrl.js";
import ajax from '../utils/ajax.js';
import { userCookie } from '../helpers/cookieData.js';

/**
 * 登录接口
 * @param {obj} data 登录数据
 * @param {function} successCallback 成功后的回调
 * @param {function} errorCallback 失败的回调
 */
export function login (data, successCallback, errorCallback) {
    ajax().create(user.login, {
        userName: data.userName,
        password: data.userPassword
    }).success((sessionId)=>{
        setTimeout(function() {
            userCookie.set(sessionId);
        }, 0);
        if ($.isFunction(successCallback)) {
            successCallback("登录成功");
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("用户名不存在或者密码不正确");
        }
    }).send();
}

/**
 * 获取用户信息接口
 * @param {obj} user 用户数据
 * @param {function} successCallback 成功后的回调
 * @param {function} errorCallback 失败的回调
 */
export function getUserInfo(successCallback, errorCallback) {
    ajax().create(user.info, {
        sessionId: userCookie.get()
    }, "json").success((data)=>{
        if ($.isFunction(successCallback)) {
            successCallback(data);
        }
    }).error(()=>{
        userCookie.remove();
        if ($.isFunction(errorCallback)) {
            errorCallback("数据不存在");
        }
    }).send();
}

/**
 * 修改用户的密码
 * @param {obj} user 用户数据
 * @param {function} successCallback 成功后的回调
 * @param {function} errorCallback 失败的回调
 */
export function editPassword(data, successCallback, errorCallback) {
    ajax().create(user.editPassword, data).success((data)=>{
        if ($.isFunction(successCallback)) {
            successCallback("修改密码成功");
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("旧密码不正确,请重新输入");
        }
    }).send();
}

/**
 * 新增用户
 * 
 * @export
 * @param {any} data
 * @param {any} successCallback
 * @param {any} errorCallback
 */
export function addUser(data, successCallback, errorCallback) {
    ajax().create(user.add, data).success(()=>{
        if ($.isFunction(successCallback)) {
            successCallback("新增用户成功");
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("新增用户失败");
        }
    }).send();
}

/**
 * 判断用户名是否存在
 * 
 * @export
 * @param {any} account
 * @param {any} successCallback
 * @param {any} errorCallback
 */
export function existsUser(account, successCallback, errorCallback) {
    ajax().create(user.exists, {
        userName: account
    }).success(()=>{
        if ($.isFunction(successCallback)) {
            successCallback("用户名未存在");
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("用户名已存在");
        }
    }).send();
}

/**
 * 获取用户列表
 * 
 * @export
 * @param {any} data
 * @param {any} successCallback
 * @param {any} errorCallback
 */
export function getUserList(data, successCallback, errorCallback) {
    ajax().create(user.list, data).success((datas)=>{
        if ($.isFunction(successCallback)) {
            successCallback(datas);
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("获取用户列表失败");
        }
    }).send();
}

/**
 * 获取所有用户状态
 * 
 * @export
 * @param {any} successCallback
 * @param {any} errorCallback
 */
export function getStateAll(successCallback, errorCallback) {
    ajax().create(user.stateAll).success((datas)=>{
        if ($.isFunction(successCallback)) {
            successCallback(datas);
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("获取用户状态失败");
        }
    }).send();
}

/**
 * 编辑用户资料
 * 
 * @export
 * @param {any} data
 * @param {any} successCallback
 * @param {any} errorCallback
 */
export function editUser(data, successCallback, errorCallback) {
    ajax().create(user.edit, data).success((datas)=>{
        if ($.isFunction(successCallback)) {
            successCallback("编辑成功");
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("编辑失败");
        }
    }).send();
}

/**
 * 更改用户状态
 * 
 * @export
 * @param {any} data
 * @param {any} successCallback
 * @param {any} errorCallback
 */
export function setUserState(data, successCallback,errorCallback) {
    ajax().create(user.setState, data).success(()=>{
        if ($.isFunction(successCallback)) {
            successCallback("设置状态成功");
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("设置状态失败");
        }
    }).send();
}

/**
 * 删除用户
 * 
 * @export
 * @param {any} data
 * @param {any} successCallback
 * @param {any} errorCallback
 */
export function delUser(data, successCallback, errorCallback) {
    ajax().create(user.del, {
        id: data
    }).success(()=>{
        if ($.isFunction(successCallback)) {
            successCallback("设置状态成功");
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("设置状态失败");
        }
    }).send();
}

/**
 * 重置该用户的密码
 * 
 * @export
 * @param {any} data
 * @param {any} successCallback
 * @param {any} errorCallback
 */
export function resetPassword(data, successCallback, errorCallback) {
    ajax().create(user.resetPassword, {
        id: data
    }).success(()=>{
        if ($.isFunction(successCallback)) {
            successCallback("重置成功");
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("重置失败");
        }
    }).send();
}