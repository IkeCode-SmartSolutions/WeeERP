using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wee.Common.Contracts
{
    public interface IWeeRegister<TExtensionReturnType>
    {
        TExtensionReturnType Invoke<T>()
            where T : class;
    }
}
