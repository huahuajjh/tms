import {ticket} from "../helpers/apiUrl.js";
import ajax from '../utils/ajax.js';
import global from '../globalMethod/global.js';

export function addTicket(data, successCallback, errorCallback) {
    ajax().create(ticket.add, data).success(()=>{
        if ($.isFunction(successCallback)) {
            successCallback("新增门票成功");
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("新增门票失败");
        }
    }).send();
}

export function listTicket(data, successCallback, errorCallback) {
    data.CreateUserId = global.user.UserType == 1 ? global.user.Id : null;
    ajax().create(ticket.list, data).success((datas)=>{
        if ($.isFunction(successCallback)) {
            successCallback(datas);
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("获取门票列表失败");
        }
    }).send();
}

export function editTicket(data, successCallback, errorCallback) {
    ajax().create(ticket.edit, data).success((datas)=>{
        if ($.isFunction(successCallback)) {
            successCallback("编辑门票成功");
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("编辑门票失败");
        }
    }).send();
}

export function delTicket(id, successCallback, errorCallback) {
    ajax().create(ticket.del, {
        id: id
    }).success((datas)=>{
        if ($.isFunction(successCallback)) {
            successCallback("删除门票成功");
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("删除门票失败");
        }
    }).send();
}

export function auditTicket(datasJson, successCallback, errorCallback) {
    ajax().create(ticket.audit, {
        json: datasJson
    }).success((datas)=>{
        if ($.isFunction(successCallback)) {
            successCallback("审核门票成功");
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("审核门票失败");
        }
    }).send();
}

export function untakenListTicket(data, successCallback, errorCallback) {
    ajax().create(ticket.untakenList, data).success((datas)=>{
        if ($.isFunction(successCallback)) {
            successCallback(datas);
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("获取门票列表失败");
        }
    }).send();
}

export function takenTicket(data, successCallback, errorCallback) {
    ajax().create(ticket.taken, data).success((datas)=>{
        if ($.isFunction(successCallback)) {
            successCallback("取出门票成功");
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("取出门票失败");
        }
    }).send();
}

export function sendSMS(json, successCallback, errorCallback) {
    ajax().create(ticket.sendSMS, {
        json: json
    }).success(()=>{
        if ($.isFunction(successCallback)) {
            successCallback("发送短信成功");
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("发送短信失败");
        }
    }).send();
}