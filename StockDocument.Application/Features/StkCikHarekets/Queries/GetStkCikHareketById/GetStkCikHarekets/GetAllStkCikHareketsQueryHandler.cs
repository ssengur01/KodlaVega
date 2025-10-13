using MediatR;
using StockDocument.Application.Repositories;
using StockDocument.Domain.Entities;
using StockDocument.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Application.Features.StkCikHarekets.Queries.GetStkCikHareketById.GetStkCikHarekets
{
    public class GetAllStkCikHareketsQueryHandler : IRequestHandler<GetAllStkCikHareketsQuery, List<StkCikHareketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllStkCikHareketsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<StkCikHareketDto>> Handle(GetAllStkCikHareketsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<StkCikHareket> stkCikHarekets;

            stkCikHarekets = await _unitOfWork.StkCikHareketRepository.GetAllAsync();

            var dtoList = stkCikHarekets.Select(stkCikHarekets => new StkCikHareketDto
            {
                Ind = stkCikHarekets.Ind,
                StokKodu = stkCikHarekets.StokKodu,
                MalinCinsi = stkCikHarekets.MalinCinsi,
                Miktar = stkCikHarekets.Miktar,
                Birim = stkCikHarekets.Birim,
                Kdv = stkCikHarekets.Kdv,
                GercekToplam = stkCikHarekets.GercekToplam,
                Aciklama = stkCikHarekets.Aciklama,
                Tarih = stkCikHarekets.Tarih
            }).ToList();
            return dtoList;
        }
    }
}
