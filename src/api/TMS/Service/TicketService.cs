using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Service
{
    public class TicketService : IService.ITicketService
    {
        private IRepository.IRepository repository;

        public TicketService(IRepository.IRepository repository)
        {
            this.repository = repository;
        }

        public ViewModel.OperationState Add(ViewModel.In.Ticket ticket)
        {
            this.repository.GetReposirotyFactory<Entity.Ticket>().Add(ticket.ToAddEntity());
            if (this.repository.SaveChange() > 0)
                return ViewModel.OperationState.success;
            return ViewModel.OperationState.dataError;
        }


        public ViewModel.PageModel<ViewModel.Out.Ticket> List(ViewModel.In.Page page, ViewModel.In.TicketQuery query)
        {
            int sceneryId;
            DateTime playTime;
            DateTime createStartTime;
            DateTime createEndTime;
            bool isSceneryId = int.TryParse(query.SceneryId, out sceneryId);
            bool isPlayTime = DateTime.TryParse(query.PlayTime, out playTime);
            bool isCreateStartTime = DateTime.TryParse(query.CreateStartTime, out createStartTime);
            bool isCreateEndTime = DateTime.TryParse(query.CreateEndTime, out createEndTime);
            IBaseRepository<Entity.TicketInfo> ticketEntity = this.repository.GetReposirotyFactory<Entity.TicketInfo>();
            IQueryable<Entity.TicketInfo> wheres = ticketEntity.Query(d => d.IsDel == false);
            if (!string.IsNullOrEmpty(query.Code))
            {
                wheres = wheres.Where(d => d.Code == query.Code);
            }
            if (!string.IsNullOrEmpty(query.Phone))
            {
                wheres = wheres.Where(d => d.Phone == query.Phone);
            }
            if (isPlayTime)
            {
                wheres = wheres.Where(d => d.PlayDate == playTime);
            }
            if (isSceneryId)
            {
                wheres = wheres.Where(d => d.SceneryId == sceneryId);
            }
            if (!string.IsNullOrEmpty(query.SceneryName))
            {
                wheres = wheres.Where(d => d.SceneryTitle.Contains(query.SceneryName));
            }
            if (query.IsPay != null)
            {
                wheres = wheres.Where(d => d.IsPay == query.IsPay);
            }
            if (query.State != null)
            {
                wheres = wheres.Where(d => d.State == query.State);
            }
            if (isCreateStartTime && isCreateEndTime)
            {
                wheres = wheres.Where(d => d.CreateTime >= createStartTime && d.CreateTime <= createEndTime);
            }
            if (!string.IsNullOrEmpty(query.Recommender))
            {
                wheres = wheres.Where(d => d.Recommender == query.Recommender);
            }
            if (query.TakeState != null)
            {
                wheres = wheres.Where(d => d.TakeState == query.TakeState);
            }
            if (query.SMSState != null)
            {
                wheres = wheres.Where(d => d.SmsState == query.SMSState || (query.SMSState == 0 && d.SmsState == null));
            }
            if (query.CreateUserId != null)
            {
                wheres = wheres.Where(d => d.UserId == query.CreateUserId);
            }
            int pageCount = wheres.Count();
            ViewModel.Out.Ticket[] dataArr = wheres.OrderByDescending(d => d.Id).Skip((page.PageIndex - 1) * page.PageSize).Take(page.PageSize).ToList().Select(d => ViewModel.Out.Ticket.ToModel(d)).ToArray();
            return new ViewModel.PageModel<ViewModel.Out.Ticket>(pageCount, dataArr);
        }

        public ViewModel.OperationState Del(int id)
        {
            this.repository.GetReposirotyFactory<Entity.Ticket>().Query(d => d.Id == id).ToList().ForEach(d => d.IsDel = true);
            if (this.repository.SaveChange() > 0)
                return ViewModel.OperationState.success;
            return ViewModel.OperationState.dataError;
        }

        public ViewModel.OperationState Edit(ViewModel.In.Ticket ticket)
        {
            this.repository.GetReposirotyFactory<Entity.Ticket>().Query(d => d.Id == ticket.Id).ToList().ForEach(d => ticket.SetEntity(d));
            if (this.repository.SaveChange() > 0)
                return ViewModel.OperationState.success;
            return ViewModel.OperationState.dataError;
        }



        public ViewModel.OperationState Audit(ViewModel.In.AuditTicket[] audits)
        {
            int[] ids = audits.Select(d => d.Id).ToArray();
            Dictionary<string, KeyValuePair<string, Entity.TicketCode>> codeModel = new Dictionary<string, KeyValuePair<string, Entity.TicketCode>>();
            this.repository.GetReposirotyFactory<Entity.Ticket>().Query(d => ids.Contains(d.Id)).ToList()
                .ForEach(d =>
                {
                    foreach (var audit in audits)
                    {
                        if (audit.Id == d.Id)
                        {
                            d.State = audit.State;
                            d.StateMsg = audit.StateMsg;
                            d.StateUserId = audit.StateUserId;
                            d.IsCode = audit.IsStateCode;
                            if (d.State != 1) continue;
                            Entity.TicketCode codeEntity = this.repository.GetReposirotyFactory<Entity.TicketCode>()
                                .Query(t => t.SceneryId == d.SceneryId && t.Phone == d.Phone && t.PlayDate == d.PlayDate && t.IsCode == d.IsCode).FirstOrDefault();
                            if (codeEntity == null)
                            {
                                codeEntity = new Entity.TicketCode();
                                codeEntity.Phone = d.Phone;
                                codeEntity.PlayDate = d.PlayDate;
                                codeEntity.SceneryId = d.SceneryId;
                                codeEntity.Code = audit.IsStateCode ? Library.SerializeHelper.SerialNumberUtil.ToSerialNumber(long.Parse(d.Phone + d.Id.ToString())) : null;
                                codeEntity.State = 0;
                                codeEntity.IsCode = audit.IsStateCode;
                                this.repository.GetReposirotyFactory<Entity.TicketCode>().Add(codeEntity);
                                this.repository.SaveChange();
                            }
                            if (codeEntity.State != 1)
                            {
                                string key = d.Phone + d.PlayDate.ToString("yyyy/MM/dd") + d.SceneryId.ToString() + d.IsCode.ToString();
                                if (!codeModel.ContainsKey(key))
                                {
                                    string sceneryName = this.repository.GetReposirotyFactory<Entity.Scenery>().Query(t => t.Id == d.SceneryId).Select(t => t.Title).FirstOrDefault();
                                    if (sceneryName == null) sceneryName = "";
                                    string context = "";
                                    if (codeEntity.IsCode)
                                        context = Library.SMS.Action.ToContext(d.Name, sceneryName, codeEntity.Code);
                                    else
                                        context = Library.SMS.Action.ToContext(d.Name, sceneryName);
                                    codeModel.Add(key, new KeyValuePair<string, Entity.TicketCode>(context, codeEntity));
                                }
                            }
                        }
                    }
                });
            foreach (KeyValuePair<string, KeyValuePair<string, Entity.TicketCode>> code in codeModel)
            {
                if (Library.SMS.Action.Send(code.Value.Value.Phone, code.Value.Key))
                {
                    code.Value.Value.State = 1;
                }
                else
                {
                    code.Value.Value.State = 2;
                }
            }
            this.repository.SaveChange();
            return ViewModel.OperationState.success;
        }


        public ViewModel.Out.TakenTicket[] UntakenList(int? userId, ViewModel.In.TicketQuery query)
        {
            if (string.IsNullOrEmpty(query.Code) && string.IsNullOrEmpty(query.Phone) && string.IsNullOrEmpty(query.IdCard))
                return new ViewModel.Out.TakenTicket[0];
            IQueryable<Entity.TicketInfo> wheres = this.repository.GetReposirotyFactory<Entity.TicketInfo>().Query(d => d.IsDel == false && d.State == 1 && d.TakeState == false && d.TakeNum > 0);
            if (!string.IsNullOrEmpty(query.Code))
            {
                wheres = wheres.Where(d => d.Code == query.Code);
            }
            if (!string.IsNullOrEmpty(query.Phone))
            {
                wheres = wheres.Where(d => d.Phone == query.Phone);
            }
            if (!string.IsNullOrEmpty(query.IdCard))
            {
                wheres = wheres.Where(d => d.IdCard == query.IdCard);
            }
            return wheres.ToList().Select(d =>
            {
                bool state = true;
                if (userId != null)
                {
                    state = this.repository.GetReposirotyFactory<Entity.UserScenery>().Query(t => d.SceneryId == t.SceneryId && userId == t.UserId).Any();
                }
                return ViewModel.Out.TakenTicket.ToModel(d, state);
            }).ToArray();
        }

        public ViewModel.OperationState Taken(ViewModel.In.TakenTicket takenModel)
        {
            this.repository.GetReposirotyFactory<Entity.Ticket>().Query(d => d.Id == takenModel.Id).ToList()
                .ForEach(d =>
                {
                    d.TakeNum = d.TakeNum - takenModel.TakenNum;
                    if (d.TakeNum <= 0) d.TakeState = true;
                });
            if (this.repository.SaveChange() > 0)
                return ViewModel.OperationState.success;
            return ViewModel.OperationState.dataError;
        }


        public ViewModel.OperationState SendSMS(params int[] ids)
        {
            Dictionary<string, KeyValuePair<string, Entity.TicketCode>> codeModel = new Dictionary<string, KeyValuePair<string, Entity.TicketCode>>();
            this.repository.GetReposirotyFactory<Entity.TicketInfo>().Query(d => ids.Contains(d.Id) && d.State == 1).ToList()
                .ForEach(d =>
                {
                    string key = d.Phone + d.PlayDate.ToString("yyyy/MM/dd") + d.SceneryId.ToString() + d.IsCode.ToString();
                    if (!codeModel.ContainsKey(key))
                    {
                        Entity.TicketCode codeEntity = this.repository.GetReposirotyFactory<Entity.TicketCode>()
                            .Query(t => t.SceneryId == d.SceneryId && t.Phone == d.Phone && t.PlayDate == d.PlayDate && t.IsCode == d.IsCode).FirstOrDefault();
                        string context = "";
                        if (codeEntity.IsCode)
                            context = Library.SMS.Action.ToContext(d.Name, d.SceneryTitle, codeEntity.Code);
                        else
                            context = Library.SMS.Action.ToContext(d.Name, d.SceneryTitle);
                        codeModel.Add(key, new KeyValuePair<string, Entity.TicketCode>(context, codeEntity));
                    }
                });
            foreach (KeyValuePair<string, KeyValuePair<string, Entity.TicketCode>> code in codeModel)
            {
                bool state = Library.SMS.Action.Send(code.Value.Value.Phone, code.Value.Key);
                if (state && code.Value.Value.State != 1)
                {
                    code.Value.Value.State = 1;
                }
                else if (!state && code.Value.Value.State != 1)
                {
                    code.Value.Value.State = 2;
                }
            }
            this.repository.SaveChange();
            return ViewModel.OperationState.success;
        }


        public ViewModel.OperationState Import(Excel.In.Ticket[] tickets, int? userId, out Excel.In.Ticket[] repeatTickets)
        {
            List<Excel.In.Ticket> repeatList = new List<Excel.In.Ticket>();
            IList<Entity.Ticket> ticketList = new List<Entity.Ticket>();
            foreach (var ticket in tickets)
            {
                ticket.UserId = userId;
                if(this.repository.GetReposirotyFactory<Entity.Ticket>().Query(d=> d.PlayDate == ticket.PlayTime && d.SceneryId == ticket.SceneryId && d.Phone == ticket.Phone).Any())
                {
                    repeatList.Add(ticket);
                }
                else
                { 
                    ticketList.Add(ticket.ToEntity());
                }
            }

            this.repository.GetReposirotyFactory<Entity.Ticket>().Add(ticketList);
            this.repository.SaveChange();
            repeatTickets = repeatList.ToArray();
            return ViewModel.OperationState.success;
        }


        public ViewModel.Out.Ticket[] Export(ViewModel.In.TicketQuery query)
        {
            int sceneryId;
            DateTime playTime;
            DateTime createStartTime;
            DateTime createEndTime;
            bool isSceneryId = int.TryParse(query.SceneryId, out sceneryId);
            bool isPlayTime = DateTime.TryParse(query.PlayTime, out playTime);
            bool isCreateStartTime = DateTime.TryParse(query.CreateStartTime, out createStartTime);
            bool isCreateEndTime = DateTime.TryParse(query.CreateEndTime, out createEndTime);
            IBaseRepository<Entity.TicketInfo> ticketEntity = this.repository.GetReposirotyFactory<Entity.TicketInfo>();
            IQueryable<Entity.TicketInfo> wheres = ticketEntity.Query(d => d.IsDel == false);
            if (!string.IsNullOrEmpty(query.Code))
            {
                wheres = wheres.Where(d => d.Code == query.Code);
            }
            if (!string.IsNullOrEmpty(query.Phone))
            {
                wheres = wheres.Where(d => d.Phone == query.Phone);
            }
            if (isPlayTime)
            {
                wheres = wheres.Where(d => d.PlayDate == playTime);
            }
            if (isSceneryId)
            {
                wheres = wheres.Where(d => d.SceneryId == sceneryId);
            }
            if (!string.IsNullOrEmpty(query.SceneryName))
            {
                wheres = wheres.Where(d => d.SceneryTitle.Contains(query.SceneryName));
            }
            if (query.IsPay != null)
            {
                wheres = wheres.Where(d => d.IsPay == query.IsPay);
            }
            if (query.State != null)
            {
                wheres = wheres.Where(d => d.State == query.State);
            }
            if (isCreateStartTime && isCreateEndTime)
            {
                wheres = wheres.Where(d => d.CreateTime >= createStartTime && d.CreateTime <= createEndTime);
            }
            if (!string.IsNullOrEmpty(query.Recommender))
            {
                wheres = wheres.Where(d => d.Recommender == query.Recommender);
            }
            if (query.TakeState != null)
            {
                wheres = wheres.Where(d => d.TakeState == query.TakeState);
            }
            if (query.SMSState != null)
            {
                wheres = wheres.Where(d => d.SmsState == query.SMSState || (query.SMSState == 0 && d.SmsState == null));
            }
            if (query.CreateUserId != null)
            {
                wheres = wheres.Where(d => d.UserId == query.CreateUserId);
            }
            if (!string.IsNullOrEmpty(query.CreateIds))
            {
                string[] idsStrs = query.CreateIds.Trim().Split(',');
                int?[] ids = idsStrs.Select(d => { int i; return int.TryParse(d, out i) ? i : -1; }).Where(d => d >= 0).Select(d=> (int?)d).ToArray();
                if(ids.Length > 0)
                {
                    wheres = wheres.Where(d => ids.Contains(d.UserId));
                }
            }
            return wheres.OrderByDescending(d => d.Id).ToList().Select(d => ViewModel.Out.Ticket.ToModel(d)).ToArray();
        }
    }
}
