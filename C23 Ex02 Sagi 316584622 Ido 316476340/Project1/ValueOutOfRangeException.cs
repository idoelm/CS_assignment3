﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class ValueOutOfRangeException : Exception
    {
        public ValueOutOfRangeException(string message) : base(message)
        {
        }
    }

}
