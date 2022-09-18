using System.IO;
using System.Text;
using TracerLibrary.Serialization.JsonSerializer.Model;
using TracerLibrary.Tracer.Model;

namespace TracerLibrary.Serialization.JsonSerializer.Service
{
    public class JsonSerializer : ISerializer
    {
        public void Serialize(TraceResult traceResult, Stream to)
        {
            var model = new TraceResultOutput(traceResult);
            var res = System.Text.Json.JsonSerializer.Serialize(model);
            to.Write(Encoding.Default.GetBytes(res));
        }
    }
}