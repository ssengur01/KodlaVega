using CurrentDocument.Application.Repositories;
using CurrentDocument.Shared.Dtos;
using CurrentDocument.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Application.Strategies
{
    public class CarCikFaturasiStrategy : ICurrentDocumentStrategy<CarCikBaslikDto>
    {
        private readonly IInvoiceRepository _repository;

        public CarCikFaturasiStrategy(IInvoiceRepository repository)
        {
            _repository = repository;
        }

        public CarCikBaslikDto? GetById(int id)
        {
            var entity = _repository.CarCikBasliks
                .FirstOrDefault(f => f.IND == id && f.BELGETIPI == (short)CurrentType.CarÇık);

            if (entity == null)
                return null;
            var dto = new CarCikBaslikDto(entity);
            return dto;
        }

        public List<CarCikBaslikDto> List()
        {
            return _repository.CarCikBasliks
               .Where(f => f.BELGETIPI.HasValue && f.BELGETIPI.Value == (short)CurrentType.CarÇık)
               .Select(f => new CarCikBaslikDto(f))
               .ToList();
        }
    }
}
