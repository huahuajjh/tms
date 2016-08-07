using eh.impls;
using eh.impls.configurations;
using eh.impls.errs;
using eh.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Excel
{
    public class TicketExcel
    {
        public static Model<In.Ticket> Import(Stream stream)
        {
            ErrMsg msg = new ErrMsg();
            IImport import = ExcelFactory.Instance().GetExcelImporter(new ExcelConfiguration(2, 0, 0), msg);
            IList<In.Ticket> list = import.Import<In.Ticket>(stream);
            return new Model<In.Ticket>(list, msg.GetErrors());
        }

        public static byte[] Export(List<Out.Ticket> ticket, string templatePath)
        {
            ExcelConfiguration cfg = new ExcelConfiguration();
            cfg.TemplateRowIndex = 1;
            cfg.TemplateSheetIndex = 0;
            cfg.TemplatePath = templatePath;
            ErrMsg err = new ErrMsg();
            IExport export = ExcelFactory.Instance().GetExcelExporter(cfg, err);
            return export.Export<Out.Ticket>(ticket);
        }
    }
}
