using StockDocument.Application.Repositories;
using StockDocument.Shared.Dtos;
using StockDocument.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Application.Strategies
{
    public class StkGirFisStrategy : IStockDocumentStrategy<StkGirBaslikDto>
    {
        private readonly IInvoiceRepository _repository;

        public StkGirFisStrategy(IInvoiceRepository repository)
        {
            _repository = repository;
        }

        public StkGirBaslikDto? GetById(int id)
        {
            var entity = _repository.StkGirBasliks
                .FirstOrDefault(f => f.IND == id && f.BELGETIPI == (short)StockType.StkGirişFişi);

            if (entity == null)
                return null;
            var dto = new StkGirBaslikDto(entity);
            return dto;
        }

        public List<StkGirBaslikDto> List()
        {
            return _repository.StkGirBasliks
               .Where(f => f.BELGETIPI.HasValue && f.BELGETIPI.Value == (short)StockType.StkGirişFişi)
               .Select(f => new StkGirBaslikDto(f))
               .ToList();
        }
    }
}
