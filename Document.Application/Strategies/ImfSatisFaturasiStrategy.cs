using Document.Application.Repositories;
using Document.Shared.Dtos;
using Document.Shared.DTOs;
using Document.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Strategies
{
    public class ImfSatisFaturasiStrategy : IDocumentStrategy<SatFatBaslikDto>
    {
        private readonly IInvoiceRepository _repository;

        public ImfSatisFaturasiStrategy(IInvoiceRepository repository)
        {
            _repository = repository;
        }

        public SatFatBaslikDto? GetById(int id)
        {
            var entity = _repository.SatFatBasliks
                .FirstOrDefault(f => f.IND == id && f.BELGETIPI == (short)InvoiceType.SatFat);

            if (entity == null)
                return null;
            var dto = new SatFatBaslikDto(entity);
            return dto;
        }

        public List<SatFatBaslikDto> List()
        {
            return _repository.SatFatBasliks
                .Where(f => f.BELGETIPI.HasValue && f.BELGETIPI.Value == (short)InvoiceType.IMFSatFat)
                .Select(f => new SatFatBaslikDto(f))
                .ToList();
        }
    }
}
