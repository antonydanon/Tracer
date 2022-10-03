using System.IO;
using System.Text;
using Newtonsoft.Json;
using TracerLibrary.Serialization.JsonSerializer.Model;
using TracerLibrary.Tracer.Model;

namespace TracerLibrary.Serialization.JsonSerializer.Service
{
    public class JsonSerializer : ISerializer
    {
        public StringWriter Serialize(TraceResult traceResult)
        {
            var model = new TraceResultOutput(traceResult);
            var res = JsonConvert.SerializeObject(traceResult, Formatting.Indented);
            return new StringWriter(new StringBuilder(res));
        }
    }
}