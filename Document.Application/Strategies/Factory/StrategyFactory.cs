using Document.Application.Repositories;
using Document.Shared.Dtos;
using Document.Shared.DTOs;
using Document.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Strategies.Factory
{
    public class StrategyFactory : IStrategyFactory
    {
        private readonly IInvoiceRepository _repository;

        public StrategyFactory(IInvoiceRepository repository)
        {
            _repository = repository;
        }

        public object GetStrategy(InvoiceType type)
        {
            return type switch
            {
                InvoiceType.AlFat => new AlisFaturasiStrategy(_repository),
                InvoiceType.SatFat => new SatisFaturasiStrategy(_repository),
            };

        }
    }
}
