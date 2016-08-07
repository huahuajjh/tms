using eh.attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excel.Out
{
    public class Ticket
    {
        [Col("A")]
        public string CreateUserName { get; set; }
        [Col("B")]
        public string CreateUserInfo { get; set; }
        [Col("C")]
        public DateTime CreateTime { get; set; }
        [Col("D")]
        public string Code { get; set; }
        [Col("E")]
        public string Name { get; set; }
        [Col("F")]
        public string Phone { get; set; }
        [Col("G")]
        public string IdCard { get; set; }
        [Col("H")]
        public string GenderStr { get; set; }
        [Col("I")]
        public string SceneryTitle { get; set; }
        [Col("J")]
        public DateTime PlayTime { get; set; }
        [Col("K")]
        public int BuyNumber { get; set; }
        [Col("L")]
        public string IsPayStr { get; set; }
        [Col("M")]
        public string SMSStateStr { get; set; }
        [Col("N")]
        public string TakeStateStr { get; set; }
        [Col("O")]
        public string StateStr { get; set; }
        [Col("P")]
        public string Community { get; set; }
        [Col("Q")]
        public string Unit { get; set; }
        [Col("R")]
        public string Remarks { get; set; }
        [Col("S")]
        public string Recommender { get; set; }

        public static Ticket ToModel(ViewModel.Out.Ticket ticket)
        {
            Ticket model = new Ticket();
            model.BuyNumber = ticket.BuyNumber;
            model.Code = ticket.Code;
            model.Community = ticket.Community;
            model.CreateTime = ticket.CreateTime;
            model.CreateUserName = string.Format("{0}({1})", ticket.CreateUserName, ticket.CreateUserAccount);
            model.CreateUserInfo = string.Format("手机:{0}, QQ:{1}, 邮箱:{2}", ticket.CreatePhone, ticket.CreateQq, ticket.CreateMail);
            model.GenderStr = ticket.GenderStr;
            model.IdCard = ticket.IdCard;
            model.IsPayStr = ticket.IsPayStr;
            model.Name = ticket.Name;
            model.Phone = ticket.Phone;
            model.PlayTime = ticket.PlayTime;
            model.Recommender = ticket.Recommender;
            model.Remarks = ticket.Remarks;
            model.SceneryTitle = ticket.SceneryTitle;
            model.SMSStateStr = ticket.SMSStateStr;
            model.StateStr = ticket.StateStr;
            model.TakeStateStr = ticket.TakeStateStr;
            model.Unit = ticket.Unit;
            return model;
        }
    }
}
