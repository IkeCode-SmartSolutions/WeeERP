using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wee.Common.Contracts
{
    public interface IMenuItem
    {
        string Parent { get; set; }
        string Title { get; set; }
        string Hint { get; set; }
        int Order { get; set; }
        string RouteName { get; set; }

        string ControllerName { get; }

        string ActionName { get; }

        string Icon { get; set; }
        List<IMenuItem> Children { get; set; }
    }
}
