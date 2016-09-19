using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class TicketController : BaseController
    {
        private IService.ITicketService ticketService = null;

        public TicketController()
        {
            ticketService = GetService<IService.ITicketService>();
        }

        public ActionResult Add(ViewModel.In.Ticket ticket)
        {
            ViewModel.OperationState state = ticketService.Add(ticket);
            if (state == ViewModel.OperationState.success)
            {
                return new HttpStatusCodeResult(200);
            }
            else if(state == ViewModel.OperationState.repeatData)
            {
                return new HttpStatusCodeResult(406);
            }
            return new HttpStatusCodeResult(412);
        }

        public ActionResult List(ViewModel.In.Page page, ViewModel.In.TicketQuery query)
        {
            return Json(ticketService.List(page, query));
        }

        public ActionResult Del(int id)
        {
            if(ticketService.Del(id) == ViewModel.OperationState.success)
                return new HttpStatusCodeResult(200);
            return new HttpStatusCodeResult(412);
        }

        public ActionResult Edit(ViewModel.In.Ticket ticket)
        {
            if (ticketService.Edit(ticket) == ViewModel.OperationState.success)
                return new HttpStatusCodeResult(200);
            return new HttpStatusCodeResult(412);
        }

        public ActionResult Audit(string json)
        {
            ViewModel.In.AuditTicket[] datas = Library.SerializeHelper.SerializeHelper.DeSerialize<ViewModel.In.AuditTicket[]>(json);
            if (ticketService.Audit(datas) == ViewModel.OperationState.success)
                return new HttpStatusCodeResult(200);
            return new HttpStatusCodeResult(412);
        }

        public ActionResult UntakenList(int? userId, ViewModel.In.TicketQuery query)
        {
            return Json(ticketService.UntakenList(userId, query));
        }

        public ActionResult Taken(ViewModel.In.TakenTicket takenModel)
        {
            if (ticketService.Taken(takenModel) == ViewModel.OperationState.success)
                return new HttpStatusCodeResult(200);
            return new HttpStatusCodeResult(412);
        }

        public ActionResult SendSMS(string json)
        {
            int[] datas = Library.SerializeHelper.SerializeHelper.DeSerialize<int[]>(json);
            if(this.ticketService.SendSMS(datas) == ViewModel.OperationState.success)
                return new HttpStatusCodeResult(200);
            return new HttpStatusCodeResult(412);
        }
    }
}
