using System.Collections.Generic;
using TracerLibrary.Tracer.Model;

namespace TracerLibrary.Serialization.JsonSerializer.Model
{
    public class MethodInformationOutput
    {
        public string Name { get; set; }

        public string Class { get; set; }

        public string Time { get; set; }

        public List<MethodInformationOutput> Methods { get; set; }

        public MethodInformationOutput(MethodInformation method)
        {
            Name = method.Name;
            Class = method.Class;
            Time = $"{method.Time}ms";
            Methods = new(method.InnerMethods.Count);
            foreach (var m in method.InnerMethods)
            {
                var model = new MethodInformationOutput(m);
                Methods.Add(model);
            }
        }
    }
}