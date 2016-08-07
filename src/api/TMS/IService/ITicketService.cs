using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IService
{
    public interface ITicketService
    {
        ViewModel.OperationState Add(ViewModel.In.Ticket ticket);

        ViewModel.PageModel<ViewModel.Out.Ticket> List(ViewModel.In.Page page, ViewModel.In.TicketQuery query);

        ViewModel.Out.TakenTicket[] UntakenList(int? userId, ViewModel.In.TicketQuery query);

        ViewModel.OperationState Taken(ViewModel.In.TakenTicket takenModel);

        ViewModel.OperationState Del(int id);

        ViewModel.OperationState Edit(ViewModel.In.Ticket ticket);

        ViewModel.OperationState Audit(ViewModel.In.AuditTicket[] audits);

        ViewModel.OperationState SendSMS(params int[] ids);

        ViewModel.OperationState Import(Excel.In.Ticket[] tickets, int? userId, out Excel.In.Ticket[] repeatTickets);

        ViewModel.Out.Ticket[] Export(ViewModel.In.TicketQuery query);
    }
}
