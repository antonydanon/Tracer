﻿using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using TracerLibrary.Tracer.Model;

namespace TracerLibrary.Tracer.Service
{
    public class Tracer : ITracer
    {
        private readonly ConcurrentDictionary<int, ThreadTracer> _threads = new();
        
        public void StartTrace()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            var thread = _threads.GetOrAdd(threadId, new ThreadTracer(threadId));
            var frame = new StackTrace(true).GetFrame(1);
            thread.StartTrace(frame);
        }
        
        public void StopTrace()
        {
        }
        
        public TraceResult GetTraceResult()
        {
            return new TraceResult();
        }
    }
}