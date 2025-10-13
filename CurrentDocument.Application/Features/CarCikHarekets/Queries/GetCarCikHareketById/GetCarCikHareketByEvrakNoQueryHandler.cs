using CurrentDocument.Application.Features.CarCikHarekets.Queries.GetCarCikHareketById.GetCarCikHarekets;
using CurrentDocument.Application.Repositories;
using CurrentDocument.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Application.Features.CarCikHarekets.Queries.GetCarCikHareketById
{
    public class GetCarCikHareketByEvrakNoQueryHandler : IRequestHandler<GetCarCikHareketByEvrakNoQuery, List<CarCikHareketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarCikHareketByEvrakNoQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CarCikHareketDto>> Handle(GetCarCikHareketByEvrakNoQuery request, CancellationToken cancellationToken)
        {
            var baslik = await _unitOfWork.CarCikBaslikRepository
                .SingleOrDefaultAsync(b => b.IND == request.EvrakNo);

            if (baslik == null)
                return new List<CarCikHareketDto>();

            var hareketler = await _unitOfWork.CarCikHareketRepository
                .FindAsync(h => h.EvrakNo == baslik.IND);

            if (hareketler == null || !hareketler.Any())
                return new List<CarCikHareketDto>();

            var result = hareketler.Select(h => new CarCikHareketDto
            {
                Ind = h.Ind,
                Izahat = h.Izahat,
                PortNo = h.PortNo,
                EvrakNo = h.EvrakNo,
                Aciklama = h.Aciklama,
                Vade = h.Vade,
                Tutar = h.Tutar,
                ParaBirimi = h.ParaBirimi,
                BelgeNo = h.BelgeNo,
                Status = h.Status,
                Kur = h.Kur,
                BankaNo = h.BankaNo,
                FirmaNo = h.FirmaNo,
                MuhHesapKodu = h.MuhHesapKodu,
                AylikVade = h.AylikVade
            }).ToList();

            return result;
        }
    }
}
