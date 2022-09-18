using System.Collections.Generic;
using TracerLibrary.Tracer.Model;

namespace TracerLibrary.Serialization.XmlSerializer.Model
{
    public class TraceResultOutput
    {
        public List<ThreadInformationOutput> Threads { get; set; }

        public TraceResultOutput()
        {

        }

        public TraceResultOutput(TraceResult result)
        {
            Threads = new(result.Threads.Count);
            foreach (var thread in result.Threads)
            {
                var model = new ThreadInformationOutput(thread);
                Threads.Add(model);
            }
        }  
    }
}