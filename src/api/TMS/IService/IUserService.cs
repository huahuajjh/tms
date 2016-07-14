using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IService
{
    public interface IUserService
    {
        ViewModel.OperationState Login(ViewModel.In.Login user);

        ViewModel.Out.User Info(string userName);

        ViewModel.OperationState Exist(string userName);

        ViewModel.OperationState Add(ViewModel.In.User user);

        ViewModel.OperationState Edit(ViewModel.In.User user);

        ViewModel.OperationState Del(int id);

        ViewModel.OperationState State(int id, int stateId);

        ViewModel.OperationState Password(string userName, string oldPassword, string newPassword);

        ViewModel.PageModel<ViewModel.Out.UserInfo> list(ViewModel.In.Page page, ViewModel.In.UserQuery query);

        ViewModel.OperationState InitPassword(int id);

        ViewModel.Out.UserState[] AllState();
    }
}
