using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel
{
    public enum OperationState
    {
        //用户名错误
        userNameError,
        // 密码错误
        passwordError,
        // 数据已存在
        existError,
        // 数据错误
        dataError,
        // 成功
        success
    }
}
