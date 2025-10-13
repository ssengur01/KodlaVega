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
    public class CarGirFaturasiStrategy : ICurrentDocumentStrategy<CarGirBaslikDto>
    {
        private readonly IInvoiceRepository _repository;

        public CarGirFaturasiStrategy(IInvoiceRepository repository)
        {
            _repository = repository;
        }

        public CarGirBaslikDto? GetById(int id)
        {
            var entity = _repository.CarGirBasliks
                .FirstOrDefault(f => f.IND == id && f.BELGETIPI == (short)CurrentType.CarGir);

            if (entity == null)
                return null;
            var dto = new CarGirBaslikDto(entity);
            return dto;
        }

        public List<CarGirBaslikDto> List()
        {
            return _repository.CarGirBasliks
               .Where(f => f.BELGETIPI.HasValue && f.BELGETIPI.Value == (short)CurrentType.CarGir)
               .Select(f => new CarGirBaslikDto(f))
               .ToList();
        }
    }
}
