using System.IO;

namespace TracerLibrary.Writer
{
    public class FileWriter : IWriter
    {
        public void Write(StringWriter stringWriter)
        {
            using var writer = new StreamWriter("result.txt", false);
            writer.WriteLine(stringWriter);
        }
    }
}