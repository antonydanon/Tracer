using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TracerLibrary.Tracer.Model;

namespace TracerLibrary.Tracer.Service
{
    public class ThreadTracer
    {
        private ThreadInformation _threadInformation;
        
        private Stack<MethodTracer> _methodTracers = new();

        private List<MethodInformation> _methodInformations = new();
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

        public void StopTrace()
        {
            var methodTracer = new MethodTracer();
            if(_methodTracers.TryPop(out methodTracer))
            {
                methodTracer.StopTrace();
                var methodInformation = methodTracer.GetTraceResult();
                var previousTracer = new MethodTracer();
                if (_methodTracers.TryPeek(out previousTracer))
                {
                    previousTracer.AddMethodInformation(methodInformation);
                }
                else
                {
                    _methodInformations.Add(methodInformation);
                }
            }
        }
        
        public ThreadInformation GetTraceResult()
        {
            _threadInformation.Time = _methodInformations.Sum(methodInf => methodInf.Time);
            _threadInformation.Methods = _methodInformations;

            return _threadInformation;
        }
    }
}