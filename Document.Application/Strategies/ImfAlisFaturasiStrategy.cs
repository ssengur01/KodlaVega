using Document.Application.Repositories;
using Document.Shared.DTOs;
using Document.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Strategies
{
    public class ImfAlisFaturasiStrategy : IDocumentStrategy<AlFatBaslikDto>
    {
        private readonly IInvoiceRepository _repository;

        public ImfAlisFaturasiStrategy(IInvoiceRepository repository)
        {
            _repository = repository;
        }

        public AlFatBaslikDto? GetById(int id)
        {
            var entity = _repository.AlFatBasliks
                .FirstOrDefault(f => f.IND == id && f.BELGETIPI == (short)InvoiceType.AlFat);

            if (entity == null)
                return null;
            var dto = new AlFatBaslikDto(entity);
            return dto;
        }

        public List<AlFatBaslikDto> List()
        {
            return _repository.AlFatBasliks
                .Where(f => f.BELGETIPI.HasValue && f.BELGETIPI.Value == (short)InvoiceType.IMFAlFat)
                .Select(f => new AlFatBaslikDto(f))
                .ToList();
        }
    }
}
