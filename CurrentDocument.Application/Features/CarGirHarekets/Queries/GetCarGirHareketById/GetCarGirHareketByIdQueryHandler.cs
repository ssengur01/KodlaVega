using CurrentDocument.Application.Repositories;
using CurrentDocument.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Application.Features.CarGirHarekets.Queries.GetCarGirHareketById
{
    public class GetCarGirHareketByIdQueryHandler : IRequestHandler<GetCarGirHareketByIdQuery, List<CarGirHareketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarGirHareketByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CarGirHareketDto>> Handle(GetCarGirHareketByIdQuery request, CancellationToken cancellationToken)
        {
            var carGirHareket = await _unitOfWork.CarGirHareketRepository.FindAsync(h => h.Ind == request.Ind);

            if (carGirHareket == null || !carGirHareket.Any())
                return new List<CarGirHareketDto>();

            var dtoList = carGirHareket.Select(h => new CarGirHareketDto
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
                VisaTahsilHareketNo = h.VisaTahsilHareketNo,
                GercekVade = h.GercekVade,
                AylikVade = h.AylikVade
            }).ToList();

            return dtoList;
        }
    }
}
