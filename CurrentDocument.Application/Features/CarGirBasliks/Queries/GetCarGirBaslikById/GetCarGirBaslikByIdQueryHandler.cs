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

namespace CurrentDocument.Application.Features.CarGirBasliks.Queries.GetCarGirBaslikById
{
    public class GetCarGirBaslikByIdQueryHandler : IRequestHandler<GetCarGirBaslikByIdQuery, CarGirBaslikDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarGirBaslikByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarGirBaslikDto?> Handle(GetCarGirBaslikByIdQuery request, CancellationToken cancellationToken)
        {
            var carGirBasliks = await _unitOfWork.CarGirBaslikRepository.GetByIdAsync(request.IND);

            if (carGirBasliks == null)
            {
                return null;
            }

            var dto = new CarGirBaslikDto(carGirBasliks)
            {
                IND = carGirBasliks.IND,
                FIRMANO = carGirBasliks.FIRMANO,
                BELGENO = carGirBasliks.BELGENO,
                TARIH = carGirBasliks.TARIH,
                IADE = carGirBasliks.IADE,
                AYLIKVADE = carGirBasliks.AYLIKVADE,
                TUTAR = carGirBasliks.TUTAR,
                PARABIRIMI = carGirBasliks.PARABIRIMI,
                KAPATMABELGESI = carGirBasliks.KAPATMABELGESI,
                GIRIS = carGirBasliks.GIRIS,
                KUR = carGirBasliks.KUR,
                BELGETIPI = (CurrentType?)carGirBasliks.BELGETIPI,
                IPTAL = carGirBasliks.IPTAL,
                ENTEGRE = carGirBasliks.ENTEGRE,
                USERNO = carGirBasliks.USERNO,
                KDVISK = carGirBasliks.KDVISK,
                ACIKLAMA = carGirBasliks.ACIKLAMA,
                KONSOLIDE = carGirBasliks.KONSOLIDE,
                MUHASEBELESMEYECEK = carGirBasliks.MUHASEBELESMEYECEK,
                CREDATE = carGirBasliks.CREDATE,
            };

            return dto;
        }
    }
}
