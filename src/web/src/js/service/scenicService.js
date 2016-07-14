import {scenery} from "../helpers/apiUrl.js";
import ajax from '../utils/ajax.js';

export function getScenicList(data, successCallback, errorCallback) {
    ajax().create(scenery.list, data).success((data)=>{
        if ($.isFunction(successCallback)) {
            successCallback(data);
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("获取景点列表失败");
        }
    }).send();
}

export function addScenic(data, successCallback, errorCallback) {
    ajax().create(scenery.add, data).success(()=>{
        if ($.isFunction(successCallback)) {
            successCallback("新增景点成功");
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("新增景点失败");
        }
    }).send();
}

export function editScenic(data, successCallback, errorCallback) {
    ajax().create(scenery.edit, data).success(()=>{
        if ($.isFunction(successCallback)) {
            successCallback("编辑景点成功");
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("编辑景点失败");
        }
    }).send();
}

export function delScenic(data, successCallback, errorCallback) {
    ajax().create(scenery.del, {
        id: data
    }).success(()=>{
        if ($.isFunction(successCallback)) {
            successCallback("删除景点成功");
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("删除景点失败");
        }
    }).send();
}