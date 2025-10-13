using CurrentDocument.Application.Repositories;
using CurrentDocument.Domain.Entities;
using CurrentDocument.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Application.Features.CarCikHarekets.Queries.GetCarCikHareketById.GetCarCikHarekets
{
    public class GetAllCarCikHareketsQueryHandler : IRequestHandler<GetAllCarCikHareketsQuery, List<CarCikHareketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCarCikHareketsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CarCikHareketDto>> Handle(GetAllCarCikHareketsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<CarCikHareket> carCikHarekets;

            carCikHarekets = await _unitOfWork.CarCikHareketRepository.GetAllAsync();

            var dtoList = carCikHarekets.Select(carCikHarekets => new CarCikHareketDto
            {
                Ind = carCikHarekets.Ind,
                Izahat = carCikHarekets.Izahat,
                PortNo = carCikHarekets.PortNo,
                EvrakNo = carCikHarekets.EvrakNo,
                Aciklama = carCikHarekets.Aciklama,
                Vade = carCikHarekets.Vade,
                Tutar = carCikHarekets.Tutar,
                ParaBirimi = carCikHarekets.ParaBirimi,
                BelgeNo = carCikHarekets.BelgeNo,
                Status = carCikHarekets.Status,
                Kur = carCikHarekets.Kur,
                BankaNo = carCikHarekets.BankaNo,
                FirmaNo = carCikHarekets.FirmaNo,
                MuhHesapKodu = carCikHarekets.MuhHesapKodu,
                AylikVade = carCikHarekets.AylikVade
            }).ToList();

            return dtoList;
        }
    }
}
