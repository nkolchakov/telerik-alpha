using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Core.Contracts;

namespace Traveller.Core.Decorators
{
    public class PerformanceTesterEngine : IEngine
    {
        private readonly IEngine engine;
        private readonly IStopwatch stopwatch;
        private readonly IWriter writer;

        public PerformanceTesterEngine(IEngine engine, IStopwatch stopwatch, IWriter writer)
        {
            Guard.WhenArgument(engine, "engine").IsNull().Throw();
            Guard.WhenArgument(stopwatch, "stopwatch").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();

            this.engine = engine;
            this.stopwatch = stopwatch;
            this.writer = writer;
        }

        public void Start()
        {
            this.writer.Write($"The Engine is starting...");

            this.stopwatch.Start();
            this.engine.Start();
            this.stopwatch.Stop();

            this.writer.Write($"The Engine worked for {this.stopwatch.ElapsedMiliSeconds} milliseconds.");
        }
    }
}
