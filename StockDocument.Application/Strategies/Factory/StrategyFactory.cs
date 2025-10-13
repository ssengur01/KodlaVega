using StockDocument.Application.Repositories;
using StockDocument.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Application.Strategies.Factory
{
    public class StrategyFactory : IStrategyFactory
    {
        private readonly IInvoiceRepository _repository;

        public StrategyFactory(IInvoiceRepository repository)
        {
            _repository = repository;
        }

        public object GetStrategy(StockType type)
        {
            return type switch
            {
                StockType.StkGirişFişi => new StkGirFisStrategy(_repository),
                StockType.StkÇıkışFişi => new StkCikFisStrategy(_repository)
            };
        }
    }
}
