using MediatR;
using StockDocument.Application.Repositories;
using StockDocument.Domain.Entities;
using StockDocument.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Application.Features.StkGirHarekets.Queries.GetStkGirHareketById.GetAllStkGirHarekets
{
    public class GetAllStkGirHareketsQueryHandler : IRequestHandler<GetAllStkGirHareketsQuery, List<StkGirHareketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllStkGirHareketsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<StkGirHareketDto>> Handle(GetAllStkGirHareketsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<StkGirHareket> stkGirHarekets;

            stkGirHarekets = await _unitOfWork.StkGirHareketRepository.GetAllAsync();

            var dtoList = stkGirHarekets.Select(stkGirHareket => new StkGirHareketDto
            {
                Ind = stkGirHareket.Ind,
                StokKodu = stkGirHareket.StokKodu,
                MalinCinsi = stkGirHareket.MalinCinsi,
                Miktar = stkGirHareket.Miktar,
                Birim = stkGirHareket.Birim,
                Kdv = stkGirHareket.Kdv,
                GercekToplam = stkGirHareket.GercekToplam,
                Aciklama = stkGirHareket.Aciklama,
                Tarih = stkGirHareket.Tarih
            }).ToList();

            return dtoList;
        }
    }
}
