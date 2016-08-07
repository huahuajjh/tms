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
    public class SceneryExcel
    {
        public static Model<In.Scenery> Import(Stream stream)
        {
            ErrMsg msg = new ErrMsg();
            IImport import = ExcelFactory.Instance().GetExcelImporter(new ExcelConfiguration(2, 0, 0), msg);
            IList<In.Scenery> list = import.Import<In.Scenery>(stream);
            return new Model<In.Scenery>(list, msg.GetErrors());
        }

        public static byte[] Export(List<Out.Scenery> scenerys, string templatePath)
        {
            ExcelConfiguration cfg = new ExcelConfiguration();
            cfg.TemplateRowIndex = 1;
            cfg.TemplateSheetIndex = 0;
            cfg.TemplatePath = templatePath;
            ErrMsg err = new ErrMsg();
            IExport export = ExcelFactory.Instance().GetExcelExporter(cfg, err);
            return export.Export<Out.Scenery>(scenerys);
        }
    }
}
