﻿using SchoolSystem.Core.Providers;

namespace SchoolSystem
{
    // I am not responsible of this code.
    // They made me write it, against my will.
    // - Steven, October 2016, Telerik Academy

    class Startup
    {
        static void Main()
        {
            // TODO: abstract at leest 2 mor provider like thiso ne
            var padhana = new ConsoleReaderProvider();
            var service = new BusinessLogicService();

            service.Execute(padhana);
        }
    }
}