﻿using System.Diagnostics;
using TracerLibrary.Tracer.Model;

namespace TracerLibrary.Tracer.Service
{
    public class MethodTracer
    {
        private Stopwatch _stopwatch = new();

        private MethodInformation _information = new();

        public void StartTrace(StackFrame frame)
        {
            if (frame is null)
            {
                _information.Name = "no info";
                _information.Class = "no info";
            }
            else
            {
                var method = frame.GetMethod();
                _information.Name = method.Name;
                _information.Class = method.DeclaringType.Name;
            }
            
            _stopwatch.Start();
        }
    }
}