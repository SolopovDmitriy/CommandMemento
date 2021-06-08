using System;
using System.Collections.Generic;
using System.Text;

namespace Команда
{
    interface ICommand
    {
        void Execute();

        void Rollback();
    }
}
