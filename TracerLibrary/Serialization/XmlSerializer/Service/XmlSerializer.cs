using System.IO;
using TracerLibrary.Serialization.XmlSerializer.Model;
using TracerLibrary.Tracer.Model;

namespace TracerLibrary.Serialization.XmlSerializer.Service
{
    public class XmlSerializer : ISerializer
    {
        public void Serialize(TraceResult traceResult, Stream to)
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(TraceResultOutput));
            var traceResultOutput = new TraceResultOutput(traceResult);
            xmlSerializer.Serialize(to, traceResultOutput);
        }
    }
}