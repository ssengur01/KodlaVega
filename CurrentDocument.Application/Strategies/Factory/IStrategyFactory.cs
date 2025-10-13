using CurrentDocument.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Application.Strategies.Factory
{
    public interface IStrategyFactory
    {
        object GetStrategy(CurrentType type);
    }
}
