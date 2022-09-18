using System.Threading.Tasks;
using TracerLibrary.Serialization;
using TracerLibrary.Serialization.JsonSerializer.Service;
using TracerLibrary.Serialization.XmlSerializer.Service;
using TracerLibrary.Tracer.Model;
using TracerLibrary.Tracer.Service;
using TracerLibrary.Writer;

namespace TracerConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            var program = new Program();
            program.WriteData(program.TracerWork());
        }
        
        private TraceResult TracerWork()
        {
            var tracer = new Tracer();
            var foo = new Foo(tracer);
            var task = Task.Run(() => foo.MyMethod());
            foo.MyMethod();
            foo.MyMethod();
            task.Wait();
            return tracer.GetTraceResult();    
        }

        private void WriteData(TraceResult traceResult)
        {
            IWriter consoleWriter = new ConsoleWriter();
            IWriter fileWriter = new FileWriter();
            
            ISerializer jsonSerializer = new JsonSerializer();
            var jsonStringWriter = jsonSerializer.Serialize(traceResult);

            ISerializer xmlSerializer = new XmlSerializer();
            var xmlStringWriter = xmlSerializer.Serialize(traceResult);
            
            consoleWriter.Write(jsonStringWriter);
            fileWriter.Write(jsonStringWriter);   
            
            consoleWriter.Write(xmlStringWriter);
        }
    }
}