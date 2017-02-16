using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wee.Common.Contracts
{
    public interface IWeeRegister<TExtensionReturnType> : IWeeRegister
    {
        TExtensionReturnType Invoke<T>()
            where T : class;
    }

    public interface IWeeRegister
    {
        string AssembliesPath { get; }
    }
}
