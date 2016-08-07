using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class ExcelController : BaseController
    {

        public ActionResult ImportScenery()
        {
            if (HttpContext.Request.Files.Count <= 0) return new HttpStatusCodeResult(200);
            Excel.Model<Excel.In.Scenery> tickets = Excel.SceneryExcel.Import(HttpContext.Request.Files[0].InputStream);
            if (tickets.Errors.Length > 0)
            {
                return Json(tickets.Errors);
            }
            IService.ISceneryService sceneryService = GetService<IService.ISceneryService>();
            if (sceneryService.Import(tickets.Datas) == ViewModel.OperationState.success)
                return new HttpStatusCodeResult(200);
            else
                return new HttpStatusCodeResult(412);
        }

        public ActionResult ExportScenery()
        {
            IService.ISceneryService sceneryService = GetService<IService.ISceneryService>();
            List<Excel.Out.Scenery> scenerys = sceneryService.Export();
            byte[] stream = Excel.SceneryExcel.Export(scenerys, HttpContext.Server.MapPath("/ExcelFile/exportScenery.xlsx"));
            return File(stream, "application/vnd.ms-excel", "路线编号.xlsx");
        }


        public ActionResult ImportTicket(int? userId)
        {
            if (HttpContext.Request.Files.Count <= 0) return new HttpStatusCodeResult(200);
            Excel.Model<Excel.In.Ticket> tickets = Excel.TicketExcel.Import(HttpContext.Request.Files[0].InputStream);
            if (tickets.Errors.Length > 0)
            {
                return Json(new { type = "error", datas = tickets.Errors });
            }
            IService.ITicketService ticketService = GetService<IService.ITicketService>();
            Excel.In.Ticket[] repeatTickets;
            if (ticketService.Import(tickets.Datas, userId, out repeatTickets) == ViewModel.OperationState.success)
                return Json(new { type = "repeat", datas = repeatTickets });
            else
                return new HttpStatusCodeResult(412);
        }

        public ActionResult ExportTicket(ViewModel.In.TicketQuery query)
        {
            IService.ITicketService ticketService = GetService<IService.ITicketService>();
            List < Excel.Out.Ticket > ticketLists = ticketService.Export(query).Select(d => Excel.Out.Ticket.ToModel(d)).ToList();
            byte[] stream = Excel.TicketExcel.Export(ticketLists, HttpContext.Server.MapPath("/ExcelFile/exportTicket.xlsx"));
            return File(stream, "application/vnd.ms-excel", "订单列表.xlsx");
        }
    }
}
