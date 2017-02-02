using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wee.Common.Contracts
{
    public interface IWeeModule : IWeePackage
    {
        string RootMenuDefaultTitle { get; }
    }
}
