using Document.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Strategies.Factory
{
    public interface IStrategyFactory
    {
        object GetStrategy(InvoiceType type);
    }
}
