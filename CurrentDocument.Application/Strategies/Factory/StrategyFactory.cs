using CurrentDocument.Application.Repositories;
using CurrentDocument.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Application.Strategies.Factory
{
    public class StrategyFactory : IStrategyFactory
    {
        private readonly IInvoiceRepository _repository;

        public StrategyFactory(IInvoiceRepository repository)
        {
            _repository = repository;
        }

        public object GetStrategy(CurrentType type)
        {
            return type switch
            {
                CurrentType.CarGir => new CarGirFaturasiStrategy(_repository),
                CurrentType.CarÇık => new CarCikFaturasiStrategy(_repository)
            };
        }
    }
}
