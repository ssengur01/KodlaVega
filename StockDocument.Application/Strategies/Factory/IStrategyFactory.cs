using StockDocument.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Application.Strategies.Factory
{
    public interface IStrategyFactory
    {
        object GetStrategy(StockType type);
    }
}
