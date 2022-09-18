using System.Collections.Generic;
using TracerLibrary.Tracer.Model;

namespace TracerLibrary.Serialization.XmlSerializer.Model
{
    public class ThreadInformationOutput
    {
        public int Id { get; set; }

        public string Time { get; set; }

        public List<MethodInformationOutput> Methods { get; set; }

        public ThreadInformationOutput(ThreadInformation thread)
        {
            Id = thread.Id;
            Time = $"{thread.Time}ms";
            Methods = new(thread.Methods.Count);
            foreach (var method in thread.Methods)
            {
                var model = new MethodInformationOutput(method);
                Methods.Add(model);
            }
        }
    }
}