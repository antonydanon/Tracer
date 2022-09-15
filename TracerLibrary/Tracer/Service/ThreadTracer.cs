using System.Collections.Generic;
using System.Diagnostics;
using TracerLibrary.Tracer.Model;

namespace TracerLibrary.Tracer.Service
{
    public class ThreadTracer
    {
        private ThreadInformation _threadInformation;
        
        private Stack<MethodTracer> _methodTracers = new();
        public ThreadTracer(int id)
        {
            _threadInformation = new ThreadInformation()
            {
                Id = id
            };
        }
        
        public void StartTrace(StackFrame frame)
        {
            var methodTracer = new MethodTracer();
            _methodTracers.Push(methodTracer);
            methodTracer.StartTrace(frame);
        }
    }
}