using System.IO;
using System.Text;
using TracerLibrary.Serialization.JsonSerializer.Model;
using TracerLibrary.Tracer.Model;

namespace TracerLibrary.Serialization.JsonSerializer.Service
{
    public class JsonSerializer : ISerializer
    {
        public StringWriter Serialize(TraceResult traceResult)
        {
            var model = new TraceResultOutput(traceResult);
            var res = System.Text.Json.JsonSerializer.Serialize(model);
            return new StringWriter(new StringBuilder(res));
        }
    }
}