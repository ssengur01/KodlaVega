using Document.Application.Features.AlFatHarekets.Queries.GetAlFatHareketById.GetAllAlFatHarekets;
using Document.Application.Features.SatFatHarekets.Queries.GetSatFatHareketById.GetAllSatFatHarekets;
using Document.Application.Repositories;
using Document.Shared.Dtos;
using Document.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Features.SatFatHarekets.Queries.GetSatFatHareketById
{
    public class GetSatFatHareketByEvrakNoQueryHandler : IRequestHandler<GetAllSatFatHareketByEvrakNoQuery, List<SatFatHareketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSatFatHareketByEvrakNoQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SatFatHareketDto>> Handle(GetAllSatFatHareketByEvrakNoQuery request, CancellationToken cancellationToken)
        {
            var baslik = await _unitOfWork.SatFatBaslikRepository
               .SingleOrDefaultAsync(b => b.IND == request.EvrakNo);

            if (baslik == null)
                return new List<SatFatHareketDto>();


            var hareketler = await _unitOfWork.SatFatHareketRepository
                .FindAsync(h => h.EvrakNo == baslik.IND);

            if (hareketler == null || !hareketler.Any())
                return new List<SatFatHareketDto>();

            var result = hareketler.Select(h => new SatFatHareketDto
            {
                Ind = h.Ind,
                StokKodu = h.StokKodu,
                MalinCinsi = h.MalinCinsi,
                Miktar = h.Miktar,
                Birim = h.Birim,
                Fiyati = h.Fiyati,
                Kdv = h.Kdv,
                KdvTutari = h.KdvTutari,
                Aciklama = h.Aciklama,
                Tarih = baslik.TARIH
            }).ToList();

            return result;
        }
    }
}
