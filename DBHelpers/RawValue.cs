﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelpers
{
    public class RawValue
    {
        public RawValue(string value)
        {
            this.Value = value;
        }

        public string Value { get; private set; }
    }
}
