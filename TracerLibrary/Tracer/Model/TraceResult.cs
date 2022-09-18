using System;
using System.Collections.Generic;

namespace TracerLibrary.Tracer.Model
{
    public class TraceResult
    {
        public List<ThreadInformation> Threads { get; init; }

        public TraceResult(List<ThreadInformation> threads)
        {
            if (threads is null)
            {
                throw new ArgumentNullException(nameof(threads));
            }

            Threads = threads;
        }
    }
}