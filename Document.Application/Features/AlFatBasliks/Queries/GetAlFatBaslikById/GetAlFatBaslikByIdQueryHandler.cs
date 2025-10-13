using Document.Application.Repositories;
using Document.Shared.DTOs;
using Document.Shared.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Features.AlFatBasliks.Queries.GetAlFatBaslikById
{
    public class GetAlFatBaslikByIdQueryHandler : IRequestHandler<GetAlFatBaslikByIdQuery, AlFatBaslikDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAlFatBaslikByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AlFatBaslikDto?> Handle(GetAlFatBaslikByIdQuery request, CancellationToken cancellationToken)
        {
            var alFatBaslik = await _unitOfWork.AlFatBaslikRepository.GetByIdAsync(request.IND);

            if (alFatBaslik == null)
            {
                return null;
            }

           
            var dto = new AlFatBaslikDto(alFatBaslik)
            {
                IND = alFatBaslik.IND,
                FIRMAADI = alFatBaslik.FIRMAADI,
                TUTAR = alFatBaslik.TUTAR,
                BELGENO = alFatBaslik.BELGENO,
                TARIH = alFatBaslik.TARIH,
                KDV = alFatBaslik.KDV,
                AK = alFatBaslik.AK,
                ENVANTERUPDATE = alFatBaslik.ENVANTERUPDATE,
                ODEMETARIHI = alFatBaslik.ODEMETARIHI,
                ODMODIFIED = alFatBaslik.ODMODIFIED,
                ALTBELGENO = alFatBaslik.ALTBELGENO,
                ALTBELGETARIHI = alFatBaslik.ALTBELGETARIHI,
                ALT1 = alFatBaslik.ALT1,
                ALT2 = alFatBaslik.ALT2,
                ALT3 = alFatBaslik.ALT3,
                ALT4 = alFatBaslik.ALT4,
                DEPO = alFatBaslik.DEPO,
                SUCCESS = alFatBaslik.SUCCESS,
                ALTNOT = alFatBaslik.ALTNOT,
                OZELKOD = alFatBaslik.OZELKOD,
                OZELKOD1 = alFatBaslik.OZELKOD1,
                OZELKOD2 = alFatBaslik.OZELKOD2,
                KALEM1 = alFatBaslik.KALEM1,
                KALEM2 = alFatBaslik.KALEM2,
                KALEM3 = alFatBaslik.KALEM3,
                KALEM4 = alFatBaslik.KALEM4,
                IADE = alFatBaslik.IADE,
                IPTAL = alFatBaslik.IPTAL,
                CONVERTED = alFatBaslik.CONVERTED,
                CREDATE = alFatBaslik.CREDATE,
                LADATE = alFatBaslik.LADATE,
                FIRMANO = alFatBaslik.FIRMANO,
                PARABIRIMI = alFatBaslik.PARABIRIMI,
                KUR = alFatBaslik.KUR,
                YUVARLAMA = alFatBaslik.YUVARLAMA,
                ALLOWYUVARLAMA = alFatBaslik.ALLOWYUVARLAMA,
                ODENEN = alFatBaslik.ODENEN,
                GIRIS = alFatBaslik.GIRIS,
                BELGETIPI = (InvoiceType?)alFatBaslik.BELGETIPI,
                EKBELGETIPI = alFatBaslik.EKBELGETIPI,
                SELECTED = alFatBaslik.SELECTED,
                MASRAF1 = alFatBaslik.MASRAF1,
                MASRAF2 = alFatBaslik.MASRAF2,
                MASRAF3 = alFatBaslik.MASRAF3,
                MASRAF4 = alFatBaslik.MASRAF4,
                MASRAFKDV1 = alFatBaslik.MASRAFKDV1,
                MASRAFKDV2 = alFatBaslik.MASRAFKDV2,
                MASRAFKDV3 = alFatBaslik.MASRAFKDV3,
                MASRAFKDV4 = alFatBaslik.MASRAFKDV4,
                ENTEGRE = alFatBaslik.ENTEGRE,
                USERNO = alFatBaslik.USERNO,
                KDVISK = alFatBaslik.KDVISK,
                SATISSEKLI = alFatBaslik.SATISSEKLI,
                ARATOPLAM = alFatBaslik.ARATOPLAM,
                KONSOLIDE = alFatBaslik.KONSOLIDE,
                ODEMEOPSIYONU = alFatBaslik.ODEMEOPSIYONU,
                TEVKIFATORAN = alFatBaslik.TEVKIFATORAN,
                STATUS = alFatBaslik.STATUS,
                YURTDISI = alFatBaslik.YURTDISI,
                MUHASEBELESMEYECEK = alFatBaslik.MUHASEBELESMEYECEK,
                OZELKOD3 = alFatBaslik.OZELKOD3,
                OZELKOD4 = alFatBaslik.OZELKOD4,
                PESINFIRMAADI = alFatBaslik.PESINFIRMAADI,
                PESINADRES = alFatBaslik.PESINADRES,
                PESINVERGIDAIRESI = alFatBaslik.PESINVERGIDAIRESI,
                PESINVERGINO = alFatBaslik.PESINVERGINO,
                HAREKETDEPOSU = alFatBaslik.HAREKETDEPOSU,
                KAYNAK = alFatBaslik.KAYNAK,
                OZELKOD5 = alFatBaslik.OZELKOD5,
                OZELKOD6 = alFatBaslik.OZELKOD6,
                OZELKOD7 = alFatBaslik.OZELKOD7,
                OZELKOD8 = alFatBaslik.OZELKOD8,
                ALAN1 = alFatBaslik.ALAN1,
                ALAN2 = alFatBaslik.ALAN2,
                EFATURA = alFatBaslik.EFATURA,
                EFATURANO = alFatBaslik.EFATURANO,
                EFATURAUUID = alFatBaslik.EFATURAUUID,
                EFATURANUMBER = alFatBaslik.EFATURANUMBER,
                EFATURASTATE = alFatBaslik.EFATURASTATE,
                OZELKOD9 = alFatBaslik.OZELKOD9,
                STOKHAREKETEYAZ = alFatBaslik.STOKHAREKETEYAZ,
                CARIHAREKETEYAZ = alFatBaslik.CARIHAREKETEYAZ,
                IRSALIYELIFATURA = alFatBaslik.IRSALIYELIFATURA,
                YAZARKASAFISI = alFatBaslik.YAZARKASAFISI,
                UID = alFatBaslik.UID,
                IntegrationFolder = alFatBaslik.IntegrationFolder,
                SENTSTATUS = alFatBaslik.SENTSTATUS,
                PESINMAIL = alFatBaslik.PESINMAIL
            };

            return dto;
        }
    }
}
