

using TracerLibrary.Tracer.Model;

namespace TracerLibrary.Tracer.Service
{
    public interface ITracer
    {
        void StartTrace();

        void StopTrace();
        
        TraceResult GetTraceResult();
    }
}