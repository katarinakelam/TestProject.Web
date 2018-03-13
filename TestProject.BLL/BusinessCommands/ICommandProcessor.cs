﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.BLL.BusinessCommands
{
    public interface ICommandProcessor
    {
        void Process(ICommand command);
    }
}
