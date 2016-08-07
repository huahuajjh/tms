using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.Out
{
    public class TakenTicket: ViewModel.Out.Ticket
    {
        public bool IsProcess { get; set; }

        public static TakenTicket ToModel(Entity.TicketInfo info, bool isProcess)
        {
            TakenTicket ticket = new TakenTicket();
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
            ticket.IsProcess = isProcess;
            ticket.TakeNum = info.TakeNum;
            ticket.CreateQq = info.CreateQq;
            ticket.CreateMail = info.CreateMail;
            ticket.CreatePhone = info.CreatePhone;
            return ticket;
        }
    }
}
