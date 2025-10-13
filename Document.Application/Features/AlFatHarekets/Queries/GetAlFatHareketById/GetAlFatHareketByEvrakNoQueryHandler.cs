using Document.Application.Features.AlFatHarekets.Queries.GetAlFatHareketById.GetAllAlFatHarekets;
using Document.Application.Repositories;
using Document.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Features.AlFatHarekets.Queries.GetAlFatHareketById
{
    public class GetAlFatHareketByEvrakNoQueryHandler : IRequestHandler<GetAlFatHareketByEvrakNoQuery, List<AlFatHareketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAlFatHareketByEvrakNoQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<AlFatHareketDto>> Handle(GetAlFatHareketByEvrakNoQuery request, CancellationToken cancellationToken)
        {

            var baslik = await _unitOfWork.AlFatBaslikRepository
                .SingleOrDefaultAsync(b => b.IND == request.EvrakNo);

            if (baslik == null)
                return new List<AlFatHareketDto>();

           
            var hareketler = await _unitOfWork.AlFatHareketRepository
                .FindAsync(h => h.EvrakNo == baslik.IND);

            if (hareketler == null || !hareketler.Any())
                return new List<AlFatHareketDto>();

            var result = hareketler.Select(h => new AlFatHareketDto
            {
                Ind = h.Ind,
                StokKodu = h.StokKodu,
                MalinCinsi = h.MalinCinsi,
                Miktar = h.Miktar,
                Birim = h.Birim,
                Fiyati = h.Fiyati,
                Indirim = h.Indirim,
                Kdv = h.Kdv,
                KdvTutari = h.KdvTutari,
                Aciklama = h.Aciklama,
                Tarih = baslik.TARIH
            }).ToList();

            return result;
        }
    }
}
