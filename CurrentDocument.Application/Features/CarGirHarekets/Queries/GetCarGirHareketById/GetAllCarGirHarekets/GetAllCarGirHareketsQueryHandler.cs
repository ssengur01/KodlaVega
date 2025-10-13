using CurrentDocument.Application.Repositories;
using CurrentDocument.Domain.Entities;
using CurrentDocument.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Application.Features.CarGirHarekets.Queries.GetCarGirHareketById.GetAllCarGirHarekets
{
    public class GetAllCarGirHareketsQueryHandler : IRequestHandler<GetAllCarGirHareketsQuery, List<CarGirHareketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCarGirHareketsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CarGirHareketDto>> Handle(GetAllCarGirHareketsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<CarGirHareket> carGirHarekets;

            carGirHarekets = await _unitOfWork.CarGirHareketRepository.GetAllAsync();

            var dtoList = carGirHarekets.Select(carGirHarekets => new CarGirHareketDto
            {
                Ind = carGirHarekets.Ind,
                Izahat = carGirHarekets.Izahat,
                PortNo = carGirHarekets.PortNo,
                EvrakNo = carGirHarekets.EvrakNo,
                Aciklama = carGirHarekets.Aciklama,
                Vade = carGirHarekets.Vade,
                Tutar = carGirHarekets.Tutar,
                ParaBirimi = carGirHarekets.ParaBirimi,
                BelgeNo = carGirHarekets.BelgeNo,
                Status = carGirHarekets.Status,
                Kur = carGirHarekets.Kur,
                BankaNo = carGirHarekets.BankaNo,
                FirmaNo = carGirHarekets.FirmaNo,
                VisaTahsilHareketNo = carGirHarekets.VisaTahsilHareketNo,
                MuhHesapKodu = carGirHarekets.MuhHesapKodu,
                GercekVade = carGirHarekets.GercekVade,
                AylikVade = carGirHarekets.AylikVade

            }).ToList();

            return dtoList;
        }
    }
}
