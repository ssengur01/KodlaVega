using CurrentDocument.Application.Repositories;
using CurrentDocument.Domain.Entities;
using CurrentDocument.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Application.Features.CarCikHarekets.Queries.GetCarCikHareketById
{
    public class GetCarCikHareketByIdQueryHandler : IRequestHandler<GetCarCikHareketByIdQuery, List<CarCikHareketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarCikHareketByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CarCikHareketDto>> Handle(GetCarCikHareketByIdQuery request, CancellationToken cancellationToken)
        {
            var carCikHareket = await _unitOfWork.CarCikHareketRepository.FindAsync(h => h.Ind == request.Ind);

            if (carCikHareket == null || !carCikHareket.Any())
                return new List<CarCikHareketDto>();

            var dtoList = carCikHareket.Select(h => new CarCikHareketDto
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

            return dtoList;
        }
    }
}
