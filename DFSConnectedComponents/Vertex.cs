﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSConnectedComponents
{
    public class Vertex //<T> where T : IComparable
    {
        public bool IsDiscovered; 
        public int Index;

        public Vertex(int index)
        {
            Index = index;
        }
    }
}
