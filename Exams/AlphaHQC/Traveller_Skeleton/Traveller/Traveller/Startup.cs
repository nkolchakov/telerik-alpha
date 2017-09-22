using Ninject;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Ninject;

namespace Traveller
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new TravellerModule());
            var engine = kernel.Get<IEngine>("decorator");

            engine.Start();
        }
    }
}
