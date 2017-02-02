using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wee.Common.Contracts
{
    public interface IWeePackage
    {
        string Name { get; }
        string Description { get; }
        int? Order { get; }

        void RegisterServices();
    }
}
