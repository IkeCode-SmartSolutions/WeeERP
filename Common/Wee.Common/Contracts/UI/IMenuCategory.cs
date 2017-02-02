using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wee.Common.Contracts
{
    public interface IMenuCategory
    {
        string Title { get; }
        int Order { get; }
    }
}
