using attributes;
using eh.attributes;
using eh.attributes.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excel.In
{
    public class Ticket
    {
        [Col("A")]
        [ColDataValid(DataTypeEnum.STRING)]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        [ColDataMaxlength(20)]
        public string Name { get; set; }

        [Col("B")]
        [ColDataValid(DataTypeEnum.STRING)]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        [ColDataPhone]
        public string Phone { get; set; }

        [Col("C")]
        [ColDataValid(DataTypeEnum.STRING)]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        [ColDataID]
        public string IdCard { get; set; }

        [Col("D")]
        [ColDataValid(DataTypeEnum.STRING)]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        [ColDataEquals("男", "女")]
        public string Gender { get; set; }

        [Col("E")]
        [ColDataValid(DataTypeEnum.INT)]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        public int SceneryId { get; set; }

        [Col("F")]
        [ColDataValid(DataTypeEnum.DATETIME)]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        public DateTime PlayTime { get; set; }

        [Col("G")]
        [ColDataValid(DataTypeEnum.INT)]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        public int BuyNumber { get; set; }

        [Col("H")]
        [ColDataValid(DataTypeEnum.STRING)]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        [ColDataEquals("是", "否")]
        public string IsPay { get; set; }

        [Col("I")]
        [ColDataValid(DataTypeEnum.STRING)]
        [ColDataMaxlength(20)]
        public string Community { get; set; }

        [Col("J")]
        [ColDataValid(DataTypeEnum.STRING)]
        [ColDataMaxlength(20)]
        public string Unit { get; set; }

        [Col("K")]
        [ColDataValid(DataTypeEnum.STRING)]
        [ColDataMaxlength(200)]
        public string Remarks { get; set; }

        [Col("L")]
        [ColDataValid(DataTypeEnum.STRING)]
        [ColDataMaxlength(20)]
        public string Recommender { get; set; }

        public int? UserId { get; set; }

        public Entity.Ticket ToEntity()
        {
            Entity.Ticket ticket = new Entity.Ticket();
            ticket.BuyNumber = this.BuyNumber;
            ticket.Community = this.Community;
            ticket.CreateTime = DateTime.Now;
            ticket.Gender = this.Gender.Trim().Equals("女") ? (byte)0 : (byte)1;
            ticket.IdCard = this.IdCard;
            ticket.IsCode = null;
            ticket.IsDel = false;
            ticket.IsPay = this.IsPay.Trim().Equals("否") ? false : true;
            ticket.Name = this.Name;
            ticket.Phone = this.Phone;
            ticket.PlayDate = this.PlayTime;
            ticket.PlayTime = this.PlayTime;
            ticket.Recommender = this.Recommender;
            ticket.Remarks = this.Remarks;
            ticket.SceneryId = this.SceneryId;
            ticket.State = 0;
            ticket.TakeNum = this.BuyNumber;
            ticket.TakeState = false;
            ticket.Unit = this.Unit;
            ticket.UserId = this.UserId;
            return ticket;
        }
    }
}
