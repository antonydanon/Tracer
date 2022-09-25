using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using TracerLibrary.Tracer.Service;

namespace TracerTests
{
    public class TraceTests
    {
        private class Foo
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
                Thread.Sleep(100);
                Task.Run(() => _bar.InnerMethod()).Wait();
                _tracer.StopTrace();
            }

            public void MethodWithNoNested()
            {
                _tracer.StartTrace();
                Thread.Sleep(105);
                _tracer.StopTrace();
            }
        }

        private class Bar
        {
            private readonly ITracer _tracer;

            internal Bar(ITracer tracer)
            {
                _tracer = tracer;
            }

            public void InnerMethod()
            {
                _tracer.StartTrace();
                Thread.Sleep(200);
                PrivateMethod();
                _tracer.StopTrace();
            }

            private void PrivateMethod()
            {
                _tracer.StartTrace();
                Thread.Sleep(200);
                _tracer.StopTrace();
            }
        }

        [Test]
        public void SingleThreadTest()
        {
            var tracer = new Tracer();
            var bar = new Bar(tracer);
            bar.InnerMethod();
            var result = tracer.GetTraceResult();
        
            Assert.That(result.Threads, Has.Count.EqualTo(1));
            Assert.That(result.Threads[0].Methods, Has.Count.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(result.Threads[0].Methods[0].Name, Is.EqualTo("InnerMethod"));
                Assert.That(result.Threads[0].Methods[0].Class, Is.EqualTo("Bar"));
                Assert.That(result.Threads[0].Methods[0].Time, Is.GreaterThanOrEqualTo(400));
            });
            Assert.That(result.Threads[0].Methods[0].InnerMethods, Has.Count.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(result.Threads[0].Methods[0].InnerMethods[0].Name, Is.EqualTo("PrivateMethod"));
                Assert.That(result.Threads[0].Methods[0].InnerMethods[0].Class, Is.EqualTo("Bar"));
                Assert.That(result.Threads[0].Methods[0].InnerMethods[0].Time, Is.GreaterThanOrEqualTo(200));
            });
            Assert.That(result.Threads[0].Methods[0].InnerMethods[0].InnerMethods, Has.Count.EqualTo(0));
        }

        [Test]
        public void MultiThreadedTest()
        { 
            var tracer = new Tracer();
            var foo = new Foo(tracer);
            foo.MethodWithNoNested();
            foo.MyMethod();
            var result = tracer.GetTraceResult();
        
            Assert.That(result.Threads, Has.Count.EqualTo(2));
            Assert.That(result.Threads[0].Methods, Has.Count.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(result.Threads[0].Methods[0].Name, Is.EqualTo("InnerMethod"));
                Assert.That(result.Threads[0].Methods[0].Class, Is.EqualTo("Bar"));
                Assert.That(result.Threads[0].Methods[0].Time, Is.GreaterThanOrEqualTo(400));
            });
            Assert.That(result.Threads[0].Methods[0].InnerMethods, Has.Count.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(result.Threads[0].Methods[0].InnerMethods[0].Name, Is.EqualTo("PrivateMethod"));
                Assert.That(result.Threads[0].Methods[0].InnerMethods[0].Class, Is.EqualTo("Bar"));
                Assert.That(result.Threads[0].Methods[0].InnerMethods[0].Time, Is.GreaterThanOrEqualTo(200));
            });
            Assert.That(result.Threads[0].Methods[0].InnerMethods[0].InnerMethods, Has.Count.EqualTo(0));
        
            Assert.That(result.Threads[1].Methods, Has.Count.EqualTo(2));
            Assert.That(result.Threads[1].Methods[0].InnerMethods, Has.Count.EqualTo(0));
            Assert.Multiple(() =>
            {
                Assert.That(result.Threads[1].Methods[0].Name, Is.EqualTo("MethodWithNoNested"));
                Assert.That(result.Threads[1].Methods[0].Class, Is.EqualTo("Foo"));
                Assert.That(result.Threads[1].Methods[0].Time, Is.GreaterThanOrEqualTo(105));
            });
        
            Assert.That(result.Threads[1].Methods[1].InnerMethods, Has.Count.EqualTo(0));
            Assert.Multiple(() =>
            {
                Assert.That(result.Threads[1].Methods[1].Name, Is.EqualTo("MyMethod"));
                Assert.That(result.Threads[1].Methods[1].Class, Is.EqualTo("Foo"));
                Assert.That(result.Threads[1].Methods[1].Time, Is.GreaterThanOrEqualTo(300));
            });
        }
    }
}