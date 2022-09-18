using System.IO;
using System.Threading.Tasks;
using TracerLibrary.Serialization.JsonSerializer.Service;
using TracerLibrary.Serialization.XmlSerializer.Service;
using TracerLibrary.Tracer.Service;

namespace TracerConsoleApp
{
    public static class Program
    {
        private static void Main()
        {
            var tracer = new Tracer();
            var foo = new Foo(tracer);
            var task = Task.Run(() => foo.MyMethod());
            foo.MyMethod();
            foo.MyMethod();
            task.Wait();
            var result = tracer.GetTraceResult();

            var jsonSerializer = new JsonSerializer();
            using var jsonFileStream = new FileStream("result.json", FileMode.Create);
            jsonSerializer.Serialize(result, jsonFileStream);
            
            var xmlSerializer = new XmlSerializer();
            using var xmlFileStream = new FileStream("result.xml", FileMode.Create);
            xmlSerializer.Serialize(result, xmlFileStream);
        }
    }
}