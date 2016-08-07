using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.In
{
    public class Ticket
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string IdCard { get; set; }

        public byte Gender { get; set; }

        public string Community { get; set; }

        public string Unit { get; set; }

        public int SceneryId { get; set; }

        public DateTime PlayTime { get; set; }

        public int BuyNumber { get; set; }

        public bool IsPay { get; set; }

        public string Recommender { get; set; }

        public string Remarks { get; set; }

        public int? UserId { get; set; }

        public void SetEntity(Entity.Ticket ticket)
        {
            ticket.Name = this.Name;
            ticket.Phone = this.Phone;
            ticket.IdCard = this.IdCard;
            ticket.Gender = this.Gender;
            ticket.Community = this.Community;
            ticket.Unit = this.Unit;
            ticket.SceneryId = this.SceneryId;
            ticket.PlayTime = this.PlayTime;
            ticket.PlayDate = this.PlayTime;
            ticket.BuyNumber = this.BuyNumber;
            ticket.IsPay = this.IsPay;
            ticket.Recommender = this.Recommender;
            ticket.Remarks = this.Remarks;
        }

        public Entity.Ticket ToAddEntity()
        {
            Entity.Ticket ticket = new Entity.Ticket();
            ticket.BuyNumber = this.BuyNumber;
            ticket.Community = this.Community;
            ticket.CreateTime = DateTime.Now;
            ticket.Gender = this.Gender;
            ticket.IdCard = this.IdCard;
            ticket.IsDel = false;
            ticket.IsPay = this.IsPay;
            ticket.Name = this.Name;
            ticket.Phone = this.Phone;
            ticket.PlayDate = this.PlayTime;
            ticket.PlayTime = this.PlayTime;
            ticket.Recommender = this.Recommender;
            ticket.Remarks = this.Remarks;
            ticket.SceneryId = this.SceneryId;
            ticket.State = 0;
            ticket.TakeState = false;
            ticket.Unit = this.Unit;
            ticket.UserId = this.UserId;
            ticket.TakeNum = this.BuyNumber;
            return ticket;
        }
    }
}
