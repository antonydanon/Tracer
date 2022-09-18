using System;
using System.IO;

namespace TracerLibrary.Writer
{
    public class ConsoleWriter : IWriter
    {
        public void Write(StringWriter stringWriter)
        {
            Console.WriteLine(stringWriter);    
        }
    }
}