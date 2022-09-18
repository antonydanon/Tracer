using System.IO;
using TracerLibrary.Tracer.Model;

namespace TracerLibrary.Serialization
{
    public interface ISerializer
    {
        void Serialize(TraceResult traceResult, Stream to);    
    }
}