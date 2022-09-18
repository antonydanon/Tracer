using TracerLibrary.Tracer.Service;
using static System.Threading.Thread;

namespace TracerConsoleApp
{
    public class Foo
    {
        private readonly Bar _bar;
        private readonly ITracer _tracer;

        internal Foo(ITracer tracer)
        {
            _tracer = tracer;
            _bar = new Bar(_tracer);
        }

        public void MyMethod()
        {
            _tracer.StartTrace();
            Sleep(100);
            _bar.InnerMethod();
            SomeMethod();
            _tracer.StopTrace();
        }

        private void SomeMethod()
        {
            _tracer.StartTrace();
            Sleep(150);
            _tracer.StopTrace();
        }
    }
}