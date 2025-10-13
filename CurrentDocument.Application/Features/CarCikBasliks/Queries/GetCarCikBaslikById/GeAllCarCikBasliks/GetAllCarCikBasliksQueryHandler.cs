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

namespace CurrentDocument.Application.Features.CarCikBasliks.Queries.GetCarCikBaslikById.GeAllCarCikBasliks
{
    public class GetAllCarCikBasliksQueryHandler : IRequestHandler<GetAllCarCikBasliksQuery, List<CarCikBaslikDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCarCikBasliksQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CarCikBaslikDto>> Handle(GetAllCarCikBasliksQuery request, CancellationToken cancellationToken)
        {
            var carCikBasliks = await _unitOfWork.CarCikBaslikRepository.GetAllAsync();

            var dtoList = carCikBasliks.Select(carCikBasliks => new CarCikBaslikDto(carCikBasliks)
            {
                IND = carCikBasliks.IND,
                FIRMANO = carCikBasliks.FIRMANO,
                BELGENO = carCikBasliks.BELGENO,
                TARIH = carCikBasliks.TARIH,
                IADE = carCikBasliks.IADE,
                AYLIKVADE = carCikBasliks.AYLIKVADE,
                TUTAR = carCikBasliks.TUTAR,
                PARABIRIMI = carCikBasliks.PARABIRIMI,
                KAPATMABELGESI = carCikBasliks.KAPATMABELGESI,
                GIRIS = carCikBasliks.GIRIS,
                KUR = carCikBasliks.KUR,
                BELGETIPI = (CurrentType?)carCikBasliks.BELGETIPI,
                IPTAL = carCikBasliks.IPTAL,
                ENTEGRE = carCikBasliks.ENTEGRE,
                USERNO = carCikBasliks.USERNO,
                KDVISK = carCikBasliks.KDVISK,
                ACIKLAMA = carCikBasliks.ACIKLAMA,
                KONSOLIDE = carCikBasliks.KONSOLIDE,
                MUHASEBELESMEYECEK = carCikBasliks.MUHASEBELESMEYECEK,
                CREDATE = carCikBasliks.CREDATE,
                HESAPKAPATMADISI = carCikBasliks.HESAPKAPATMADISI,
                UID = carCikBasliks.UID
            }).ToList();

            return dtoList;
        }
    }
}
