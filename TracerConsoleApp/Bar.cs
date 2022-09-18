using TracerLibrary.Tracer.Service;
using static System.Threading.Thread;

namespace TracerConsoleApp
{
    public class Bar
    {
        private readonly ITracer _tracer;

        internal Bar(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void InnerMethod()
        {
            _tracer.StartTrace();
            Sleep(200);
            _tracer.StopTrace();
        }
    }
}