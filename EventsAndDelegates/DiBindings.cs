using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class DiBindings : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IConsoleWrapper>().To<ConsoleWrapper>();
        }
    }
}
