using CurrentDocument.Application.Features.CarGirHarekets.Queries.GetCarGirHareketById.GetAllCarGirHarekets;
using CurrentDocument.Application.Repositories;
using CurrentDocument.Domain.Entities;
using CurrentDocument.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Application.Features.CarGirHarekets.Queries.GetCarGirHareketById
{
    public class GetCarGirHareketByEvrakNoQueryHandler : IRequestHandler<GetAllCarGirHareketByEvrakNoQuery, List<CarGirHareketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarGirHareketByEvrakNoQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CarGirHareketDto>> Handle(GetAllCarGirHareketByEvrakNoQuery request, CancellationToken cancellationToken)
        {
            var baslik = await _unitOfWork.CarGirBaslikRepository
               .SingleOrDefaultAsync(b => b.IND == request.EvrakNo);

            if (baslik == null)
                return new List<CarGirHareketDto>();


            var hareketler = await _unitOfWork.CarGirHareketRepository
                .FindAsync(h => h.EvrakNo == baslik.IND);

            if (hareketler == null || !hareketler.Any())
                return new List<CarGirHareketDto>();

            var result = hareketler.Select(h => new CarGirHareketDto
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
                VisaTahsilHareketNo = h.VisaTahsilHareketNo,
                MuhHesapKodu = h.MuhHesapKodu,
                GercekVade = h.GercekVade,
                AylikVade = h.AylikVade
            }).ToList();

            return result;
        }
    }
}
