using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Core.Contracts;

namespace Traveller.Core.Providers
{
    public class StopWatchProvider : IStopwatch
    {
        private readonly Stopwatch stopwatch;

        public StopWatchProvider()
        {
            this.stopwatch = new Stopwatch();
        }

        public long ElapsedMiliSeconds
        {
            get
            {
                return this.stopwatch.ElapsedMilliseconds;
            }
        }

        public void Start()
        {
            this.stopwatch.Start();
        }

        public void Stop()
        {
            this.stopwatch.Stop();
        }
    }
}
