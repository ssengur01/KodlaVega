using CurrentDocument.Application.Repositories;
using CurrentDocument.Domain.Entities;
using CurrentDocument.Shared.Dtos;
using CurrentDocument.Shared.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Application.Features.CarGirBasliks.Queries.GetCarGirBaslikById.GetAllCarGirBasliks
{
    public class GetAllCarGirBasliksQueryHandler : IRequestHandler<GetAllCarGirBasliksQuery, List<CarGirBaslikDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCarGirBasliksQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CarGirBaslikDto>> Handle(GetAllCarGirBasliksQuery request, CancellationToken cancellationToken)
        {
            var carGirBaslik = await _unitOfWork.CarGirBaslikRepository.GetAllAsync();

            var dtoList = carGirBaslik.Select(carGirBaslik => new CarGirBaslikDto(carGirBaslik)
            {
                IND = carGirBaslik.IND,
                FIRMANO = carGirBaslik.FIRMANO,
                BELGENO = carGirBaslik.BELGENO,
                TARIH = carGirBaslik.TARIH,
                IADE = carGirBaslik.IADE,
                AYLIKVADE = carGirBaslik.AYLIKVADE,
                TUTAR = carGirBaslik.TUTAR,
                PARABIRIMI = carGirBaslik.PARABIRIMI,
                KAPATMABELGESI = carGirBaslik.KAPATMABELGESI,
                GIRIS = carGirBaslik.GIRIS,
                KUR = carGirBaslik.KUR,
                BELGETIPI = (CurrentType?)carGirBaslik.BELGETIPI,
                IPTAL = carGirBaslik.IPTAL,
                ENTEGRE = carGirBaslik.ENTEGRE,
                USERNO = carGirBaslik.USERNO,
                KDVISK = carGirBaslik.KDVISK,
                ACIKLAMA = carGirBaslik.ACIKLAMA,
                KONSOLIDE = carGirBaslik.KONSOLIDE,
                MUHASEBELESMEYECEK = carGirBaslik.MUHASEBELESMEYECEK,
                CREDATE = carGirBaslik.CREDATE,
            }).ToList();

            return dtoList;
        }
    }
}
