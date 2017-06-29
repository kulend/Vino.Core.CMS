﻿using System;
using System.Diagnostics;
using System.Threading;
using Vino.Core.TimedTask.Attribute;

namespace Vino.Core.CMS.Job
{
    public class TestJob: VinoJob
    {
        [Invoke(Interval = 5000)]
        [Invoke(Interval = 3000)]
        [SingleTask]
        public void Run()
        {
            Debug.WriteLine(DateTime.Now + " Test dynamic invoke...");
        }
    }
}