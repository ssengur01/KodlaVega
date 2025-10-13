using MediatR;
using StockDocument.Application.Features.StkCikHarekets.Queries.GetStkCikHareketById.GetStkCikHarekets;
using StockDocument.Application.Repositories;
using StockDocument.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Application.Features.StkCikHarekets.Queries.GetStkCikHareketById
{
    public class GetStkCikHareketByEvrakNoQueryHandler : IRequestHandler<GetStkCikHareketByEvrakNoQuery, List<StkCikHareketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetStkCikHareketByEvrakNoQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<StkCikHareketDto>> Handle(GetStkCikHareketByEvrakNoQuery request, CancellationToken cancellationToken)
        {
            var baslik = await _unitOfWork.StkCikBaslikRepository
                .SingleOrDefaultAsync(b => b.IND == request.EvrakNo);

            if (baslik == null)
                return new List<StkCikHareketDto>();

            var hareketler = await _unitOfWork.StkCikHareketRepository
                .FindAsync(h => h.EvrakNo == baslik.IND);

            if (hareketler == null || !hareketler.Any())
                return new List<StkCikHareketDto>();

            var result = hareketler.Select(h => new StkCikHareketDto
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
