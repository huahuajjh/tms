import { share } from '../helpers/apiUrl.js'
import ajax from '../utils/ajax.js'

export function getPermission (successCallback, errorCallback) {
    var datas = [
        {
            id: 1,
            pid: null,
            title: '角色维护'
        },
        {
            id: 2,
            pid: 1,
            title: '新增'
        },
        {
            id: 3,
            pid: 1,
            title: '修改'
        },
        {
            id: 4,
            pid: 1,
            title: '删除'
        },
        {
            id: 5,
            pid: null,
            title: '用户管理'
        },
        {
            id: 6,
            pid: 5,
            title: '新增'
        },
        {
            id: 7,
            pid: 5,
            title: '修改'
        },
        {
            id: 8,
            pid: 5,
            title: '删除'
        },
        {
            id: 9,
            pid: 5,
            title: '冻结'
        }
    ];
    successCallback(datas);
}
