﻿using CV.Map.basicStruct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CV.Ai.Objectives
{
    public class Objective
    {
        public WorldLocation Location { get; set; }

        public bool IsComplete { get; set; }

        public virtual int Score { get; set; }
    }
}