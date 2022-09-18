using System.IO;
using System.Xml;
using TracerLibrary.Serialization.XmlSerializer.Model;
using TracerLibrary.Tracer.Model;

namespace TracerLibrary.Serialization.XmlSerializer.Service
{
    public class XmlSerializer : ISerializer
    {
        public StringWriter Serialize(TraceResult traceResult)
        {
            using var stringWriter = new StringWriter();
            using var xmlTextWriter = new XmlTextWriter(stringWriter);
            xmlTextWriter.Formatting = Formatting.Indented;
        
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(TraceResultOutput));
            var traceResultOutput = new TraceResultOutput(traceResult);
            xmlSerializer.Serialize(xmlTextWriter, traceResultOutput);

            return stringWriter;
        }
    }
}