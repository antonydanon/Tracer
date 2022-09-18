using System;
using System.IO;

namespace TracerLibrary.Writer
{
    public interface IWriter
    {
        public void Write(StringWriter stringWriter);
        
    }
}