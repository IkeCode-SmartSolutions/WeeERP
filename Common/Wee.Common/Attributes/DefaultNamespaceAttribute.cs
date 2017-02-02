﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wee.Common
{
    public class DefaultNamespaceAttribute : Attribute
    {
        private string _defaultNamespace;

        public DefaultNamespaceAttribute(string defaultNamespace)
        {
            _defaultNamespace = defaultNamespace;
        }

        public string DefaultNamespace { get { return _defaultNamespace; } }
    }
}
