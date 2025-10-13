using CurrentDocument.Application.Repositories;
using CurrentDocument.Shared.Dtos;
using CurrentDocument.Shared.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Application.Features.CarCikBasliks.Queries.GetCarCikBaslikById
{
    public class GetCarCikBaslikByIdQueryHandler : IRequestHandler<GetCarCikBaslikByIdQuery, CarCikBaslikDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarCikBaslikByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarCikBaslikDto?> Handle(GetCarCikBaslikByIdQuery request, CancellationToken cancellationToken)
        {
            var carCikBaslik = await _unitOfWork.CarCikBaslikRepository.GetByIdAsync(request.IND);

            if (carCikBaslik == null)
            {
                return null;
            }

            var dto = new CarCikBaslikDto(carCikBaslik)
            {
                IND = carCikBaslik.IND,
                FIRMANO = carCikBaslik.FIRMANO,
                BELGENO = carCikBaslik.BELGENO,
                TARIH = carCikBaslik.TARIH,
                IADE = carCikBaslik.IADE,
                AYLIKVADE = carCikBaslik.AYLIKVADE,
                TUTAR = carCikBaslik.TUTAR,
                PARABIRIMI = carCikBaslik.PARABIRIMI,
                KAPATMABELGESI =carCikBaslik.KAPATMABELGESI,
                GIRIS = carCikBaslik.GIRIS,
                KUR = carCikBaslik.KUR,
                BELGETIPI = (CurrentType?)carCikBaslik.BELGETIPI,
                IPTAL = carCikBaslik.IPTAL,
                ENTEGRE = carCikBaslik.ENTEGRE,
                USERNO = carCikBaslik.USERNO,
                KDVISK = carCikBaslik.KDVISK,
                ACIKLAMA = carCikBaslik.ACIKLAMA,
                KONSOLIDE = carCikBaslik.KONSOLIDE,
                MUHASEBELESMEYECEK = carCikBaslik.MUHASEBELESMEYECEK,
                CREDATE = carCikBaslik.CREDATE,
                HESAPKAPATMADISI = carCikBaslik.HESAPKAPATMADISI,
                UID = carCikBaslik.UID
            };
            return dto;
        }
    }
}
