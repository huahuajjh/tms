import { menu } from '../helpers/apiUrl.js'
import ajax from '../utils/ajax.js'

export function getAll (successCallback, errorCallback) {
    ajax().create(menu.all).success((datas)=>{
        if ($.isFunction(successCallback)) {
            successCallback(datas);
        }
    }).error(()=>{
        if ($.isFunction(errorCallback)) {
            errorCallback("获取菜单列表失败");
        }
    }).send();
}
