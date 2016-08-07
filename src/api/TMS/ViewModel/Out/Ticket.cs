using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.Out
{
    public class Ticket : Entity.TicketInfo
    {
        public string StateStr
        {
            get
            {
                switch (this.State)
                {
                    case 0:
                        return "未审核";
                    case 1:
                        return "审核通过";
                    case 2:
                        return "未通过审核";
                    default:
                        return "其他状态";
                }
            }
        }

        public string SMSStateStr
        {
            get
            {
                switch (this.SmsState)
                {
                    case null:
                    case 0:
                        return "未发送";
                    case 1:
                        return "发送成功";
                    case 2:
                        return "发送失败";
                    default:
                        return "其他状态";
                }
            }
        }

        public string TakeStateStr
        {
            get
            {
                if (this.TakeState)
                    return "已取";
                else
                    return "未取";
            }
        }

        public string IsPayStr
        {
            get
            {
                if (this.IsPay)
                    return "已支付";
                return "未支付";
            }
        }

        public string GenderStr
        {
            get
            {
                switch (this.Gender)
                {
                    case 0:
                        return "女";
                    case 1:
                        return "男";
                    default:
                        return "其他";
                }
            }
        }

        public static Ticket ToModel(Entity.TicketInfo info)
        {
            Ticket ticket = new Ticket();
            ticket.BuyNumber = info.BuyNumber;
            ticket.Code = info.Code;
            ticket.Community = info.Community;
            ticket.CreateTime = info.CreateTime;
            ticket.CreateUserAccount = info.CreateUserAccount;
            ticket.CreateUserName = info.CreateUserName;
            ticket.Gender = info.Gender;
            ticket.Id = info.Id;
            ticket.IdCard = info.IdCard;
            ticket.IsDel = info.IsDel;
            ticket.IsPay = info.IsPay;
            ticket.CreateUserType = info.CreateUserType;
            ticket.Name = info.Name;
            ticket.Phone = info.Phone;
            ticket.PlayDate = info.PlayDate;
            ticket.PlayTime = info.PlayTime;
            ticket.Recommender = info.Recommender;
            ticket.Remarks = info.Remarks;
            ticket.SceneryId = info.SceneryId;
            ticket.SceneryRemarks = info.SceneryRemarks;
            ticket.SceneryTitle = info.SceneryTitle;
            ticket.SmsState = info.SmsState;
            ticket.State = info.State;
            ticket.StateMsg = info.StateMsg;
            ticket.StateUserAccount = info.StateUserAccount;
            ticket.StateUserId = info.StateUserId;
            ticket.StateUserName = info.StateUserName;
            ticket.StateUserType = info.StateUserType;
            ticket.TakeState = info.TakeState;
            ticket.Unit = info.Unit;
            ticket.UserId = info.UserId;
            ticket.TakeNum = info.TakeNum;
            ticket.CreateQq = info.CreateQq;
            ticket.CreateMail = info.CreateMail;
            ticket.CreatePhone = info.CreatePhone;
            return ticket;
        }
    }
}
