using System.IO;
using TracerLibrary.Tracer.Model;

namespace TracerLibrary.Serialization.XmlSerializer
{
    public class XmlSerializer : ISerializer
    {
        public void Serialize(TraceResult traceResult, Stream to)
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(TraceResult));
            xmlSerializer.Serialize(to, traceResult);
        }
    }
}