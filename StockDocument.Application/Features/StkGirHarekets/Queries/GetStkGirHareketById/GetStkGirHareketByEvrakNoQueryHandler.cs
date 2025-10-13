using MediatR;
using StockDocument.Application.Features.StkGirHarekets.Queries.GetStkGirHareketById.GetAllStkGirHarekets;
using StockDocument.Application.Repositories;
using StockDocument.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Application.Features.StkGirHarekets.Queries.GetStkGirHareketById
{
    public class GetStkGirHareketByEvrakNoQueryHandler : IRequestHandler<GetAllStkGirHareketByEvrakNoQuery, List<StkGirHareketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetStkGirHareketByEvrakNoQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<StkGirHareketDto>> Handle(GetAllStkGirHareketByEvrakNoQuery request, CancellationToken cancellationToken)
        {
            var baslik = await _unitOfWork.StkGirBaslikRepository
                .SingleOrDefaultAsync(b => b.IND == request.EvrakNo);

            if (baslik == null)
                return new List<StkGirHareketDto>();

            var hareketler = await _unitOfWork.StkGirHareketRepository
                .FindAsync(h => h.EvrakNo == baslik.IND);

            if (hareketler == null || !hareketler.Any())
                return new List<StkGirHareketDto>();

            var result = hareketler.Select(h => new StkGirHareketDto
            {
                Ind = h.Ind,
                StokKodu = h.StokKodu,
                MalinCinsi = h.MalinCinsi,
                Miktar = h.Miktar,
                Birim = h.Birim,              
                Kdv = h.Kdv,              
                GercekToplam = h.GercekToplam,
                Aciklama = h.Aciklama,
                Tarih = baslik.TARIH
            }).ToList();
            return result;
        }
    }
}
