using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IService
{
    public interface ISceneryService
    {
        ViewModel.OperationState Add(ViewModel.In.Scenery scenery);

        ViewModel.PageModel<ViewModel.Out.Scenery> List(ViewModel.In.Page page, ViewModel.In.SceneryQuery query);

        ViewModel.OperationState Edit(ViewModel.In.Scenery scenery);

        ViewModel.OperationState Del(int id);

        ViewModel.OperationState Import(Excel.In.Scenery[] tickets);

        List<Excel.Out.Scenery> Export();
    }
}
