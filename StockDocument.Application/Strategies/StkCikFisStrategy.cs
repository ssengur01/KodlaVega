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
    public class StkCikFisStrategy : IStockDocumentStrategy<StkCikBaslikDto>
    {
        private readonly IInvoiceRepository _repository;

        public StkCikFisStrategy(IInvoiceRepository repository)
        {
            _repository = repository;
        }

        public StkCikBaslikDto? GetById(int id)
        {
            var entity = _repository.StkCikBasliks
                .FirstOrDefault(f => f.IND == id && f.BELGETIPI == (short)StockType.StkÇıkışFişi);

            if (entity == null)
                return null;
            var dto = new StkCikBaslikDto(entity);
            return dto;
        }

        public List<StkCikBaslikDto> List()
        {
            return _repository.StkCikBasliks
               .Where(f => f.BELGETIPI.HasValue && f.BELGETIPI.Value == (short)StockType.StkÇıkışFişi)
               .Select(f => new StkCikBaslikDto(f))
               .ToList();
        }
    }
}
