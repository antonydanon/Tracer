using System.IO;
using System.Text;
using TracerLibrary.Tracer.Model;

namespace TracerLibrary.Serialization.JsonSerializer
{
    public class JsonSerializer : ISerializer
    {
        public void Serialize(TraceResult traceResult, Stream to)
        {
            var res = System.Text.Json.JsonSerializer.Serialize(traceResult);
            to.Write(Encoding.Default.GetBytes(res));
        }
    }
}