using System.Collections.Generic;

namespace TracerLibrary.Tracer.Model
{
    public class MethodInformation
    {
        public string Name { get; internal set; }

        public string Class { get; internal set; }
        
        public long Time { get; internal set; }
        
        public List<MethodInformation> InnerMethods { get; } = new();
    }
}