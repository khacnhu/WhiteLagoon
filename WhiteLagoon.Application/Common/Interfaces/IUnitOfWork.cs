using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Common.Interfaces;

namespace WhiteLagoon.Application.Common.Interfaces
{
    public class IUnitOfWork
    {
        IVillaRepository Villa { get; }
    }
}
