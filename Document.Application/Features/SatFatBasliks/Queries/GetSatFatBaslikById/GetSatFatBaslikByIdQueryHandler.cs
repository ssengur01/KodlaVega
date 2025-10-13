using Document.Application.Repositories;
using Document.Domain.Entities;
using Document.Shared.Dtos;
using Document.Shared.DTOs;
using Document.Shared.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Features.SatFatBasliks.Queries.GetSatFatBaslikById
{
    public class GetSatFatBaslikByIdQueryHandler : IRequestHandler<GetSatFatBaslikByIdQuery, SatFatBaslikDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSatFatBaslikByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SatFatBaslikDto?> Handle(GetSatFatBaslikByIdQuery request, CancellationToken cancellationToken)
        {
            var satFatBaslik = await _unitOfWork.SatFatBaslikRepository.GetByIdAsync(request.IND);

            if (satFatBaslik == null)
            {
                return null;
            }

            var dto = new SatFatBaslikDto(satFatBaslik)
            {
                IND = satFatBaslik.IND,
                FIRMAADI = satFatBaslik.FIRMAADI,
                TUTAR = satFatBaslik.TUTAR,
                BELGENO = satFatBaslik.BELGENO,
                TARIH = satFatBaslik.TARIH,
                KDV = satFatBaslik.KDV,
                AK = satFatBaslik.AK,
                ENVANTERUPDATE = satFatBaslik.ENVANTERUPDATE,
                ODEMETARIHI = satFatBaslik.ODEMETARIHI,
                ODMODIFIED = satFatBaslik.ODMODIFIED,
                ALTBELGENO = satFatBaslik.ALTBELGENO,
                ALTBELGETARIHI = satFatBaslik.ALTBELGETARIHI,
                ALT1 = satFatBaslik.ALT1,
                ALT2 = satFatBaslik.ALT2,
                ALT3 = satFatBaslik.ALT3,
                ALT4 = satFatBaslik.ALT4,
                DEPO = satFatBaslik.DEPO,
                SUCCESS = satFatBaslik.SUCCESS,
                ALTNOT = satFatBaslik.ALTNOT,
                OZELKOD = satFatBaslik.OZELKOD,
                OZELKOD1 = satFatBaslik.OZELKOD1,
                OZELKOD2 = satFatBaslik.OZELKOD2,
                KALEM1 = satFatBaslik.KALEM1,
                KALEM2 = satFatBaslik.KALEM2,
                KALEM3 = satFatBaslik.KALEM3,
                KALEM4 = satFatBaslik.KALEM4,
                IADE = satFatBaslik.IADE,
                IPTAL = satFatBaslik.IPTAL,
                CONVERTED = satFatBaslik.CONVERTED,
                CREDATE = satFatBaslik.CREDATE,
                LADATE = satFatBaslik.LADATE,
                FIRMANO = satFatBaslik.FIRMANO,
                PARABIRIMI = satFatBaslik.PARABIRIMI,
                KUR = satFatBaslik.KUR,
                YUVARLAMA = satFatBaslik.YUVARLAMA,
                ALLOWYUVARLAMA = satFatBaslik.ALLOWYUVARLAMA,
                ODENEN = satFatBaslik.ODENEN,
                GIRIS = satFatBaslik.GIRIS,
                BELGETIPI = (InvoiceType?)satFatBaslik.BELGETIPI,
                EKBELGETIPI = satFatBaslik.EKBELGETIPI,
                SELECTED = satFatBaslik.SELECTED,
                MASRAF1 = satFatBaslik.MASRAF1,
                MASRAF2 = satFatBaslik.MASRAF2,
                MASRAF3 = satFatBaslik.MASRAF3,
                MASRAF4 = satFatBaslik.MASRAF4,
                MASRAFKDV1 = satFatBaslik.MASRAFKDV1,
                MASRAFKDV2 = satFatBaslik.MASRAFKDV2,
                MASRAFKDV3 = satFatBaslik.MASRAFKDV3,
                MASRAFKDV4 = satFatBaslik.MASRAFKDV4,
                ENTEGRE = satFatBaslik.ENTEGRE,
                USERNO = satFatBaslik.USERNO,
                KDVISK = satFatBaslik.KDVISK,
                SATISSEKLI = satFatBaslik.SATISSEKLI,
                ARATOPLAM = satFatBaslik.ARATOPLAM,
                KONSOLIDE = satFatBaslik.KONSOLIDE,
                ODEMEOPSIYONU = satFatBaslik.ODEMEOPSIYONU,
                TEVKIFATORAN = satFatBaslik.TEVKIFATORAN,
                STATUS = satFatBaslik.STATUS,
            };

            return dto;
        }
    }
}
