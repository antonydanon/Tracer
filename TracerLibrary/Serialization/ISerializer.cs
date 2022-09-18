using System.IO;
using TracerLibrary.Tracer.Model;

namespace TracerLibrary.Serialization
{
    public interface ISerializer
    {
        StringWriter Serialize(TraceResult traceResult);    
    }
}