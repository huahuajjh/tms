import {role} from "../helpers/apiUrl.js";
import ajax from '../utils/ajax.js';

export function getRoleList(data, successCallback, errorCallback) {
    ajax().create(role.list, data).success((data)=>{
        if ($.isFunction(successCallback)) {
            successCallback({
                pageCount: data.PageCount,
                datas: data.Datas
            });
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("获取角色列表失败");
        }
    }).send();
}

export function getRoleAll(successCallback, errorCallback) {
    ajax().create(role.all).success((data)=>{
        if ($.isFunction(successCallback)) {
            successCallback(data);
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("获取角色列表失败");
        }
    }).send();
}

export function getRoleAllInfo(successCallback, errorCallback) {
    ajax().create(role.allInfo).success((data)=>{
        if ($.isFunction(successCallback)) {
            successCallback(data);
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("获取角色列表失败");
        }
    }).send();
}

export function getRoleInfo(data, successCallback, errorCallback) {
    ajax().create(role.info, data).success((data)=>{
        if ($.isFunction(successCallback)) {
            successCallback(data);
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("获取角色信息失败");
        }
    }).send();
}

export function addRole(data, successCallback, errorCallback) {
    ajax().create(role.add, {
        name: data.name,
        remarks: data.remarks,
        Permissions: data.permissions.join(",")
    }).success(()=>{
        if ($.isFunction(successCallback)) {
            successCallback("新增角色成功");
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("新增角色失败");
        }
    }).send();
}

export function editRole(data, successCallback, errorCallback) {
    ajax().create(role.edit, data).success(()=>{
        if ($.isFunction(successCallback)) {
            successCallback("编辑角色成功");
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("编辑角色失败");
        }
    }).send();
}

export function delRole(data, successCallback, errorCallback) {
    ajax().create(role.del, data).success(()=>{
        if ($.isFunction(successCallback)) {
            successCallback("删除角色成功");
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("删除角色失败");
        }
    }).send();
}