﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2b
{
    public interface IPeristence
    {
        bool Load(string filename);
        bool Save(string filename);
    }
}
