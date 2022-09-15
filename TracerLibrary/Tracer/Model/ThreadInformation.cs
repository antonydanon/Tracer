using System.Collections.Generic;

namespace TracerLibrary.Tracer.Model
{
    public class ThreadInformation
    {
        public int Id { get; internal set; }

        public long Time { get; internal set; }

        public List<MethodInformation> Methods { get;  internal set; }
    }
}