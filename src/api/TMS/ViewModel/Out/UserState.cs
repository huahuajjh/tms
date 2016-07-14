using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.Out
{
    public class UserState : Entity.UserState
    {
        public static UserState ToModel(Entity.UserState state)
        {
            UserState userState = new UserState();
            userState.Id = state.Id;
            userState.IsLogin = state.IsLogin;
            userState.Title = state.Title;
            return userState;
        }
    }
}
