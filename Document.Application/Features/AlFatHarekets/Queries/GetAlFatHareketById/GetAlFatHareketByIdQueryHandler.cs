using Document.Application.Repositories;
using Document.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Features.AlFatHarekets.Queries.GetAlFatHareketById
{
    public class GetAlFatHareketByIdQueryHandler : IRequestHandler<GetAlFatHareketByIdQuery, List<AlFatHareketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAlFatHareketByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<AlFatHareketDto>> Handle(GetAlFatHareketByIdQuery request, CancellationToken cancellationToken)
        {
            var alFatHareket = await _unitOfWork.AlFatHareketRepository.FindAsync(h => h.Ind == request.Ind);

            if (alFatHareket == null || !alFatHareket.Any())
                return new List<AlFatHareketDto>();

            var dtoList = alFatHareket.Select(h => new AlFatHareketDto
            {
                Ind = h.Ind,
                Tarih = h.Tarih,
                Detay = h.Detay,
                Selected = h.Selected,
                EvrakNo = h.EvrakNo,
                FirmaNo = h.FirmaNo,
                StokNo = h.StokNo,
                MalinCinsi = h.MalinCinsi,
                StokKodu = h.StokKodu,
                StokTipi = h.StokTipi,
                Miktar = h.Miktar,
                BirimMiktar = h.BirimMiktar,
                Birim = h.Birim,
                BirimEx = h.BirimEx,
                Kdv = h.Kdv,
                KdvTutari = h.KdvTutari,
                Isk1 = h.Isk1,
                Isk2 = h.Isk2,
                Isk3 = h.Isk3,
                Isk4 = h.Isk4,
                AFiyatı = h.AFiyatı,
                Fiyati = h.Fiyati,
                GercekToplam = h.GercekToplam,
                Depo = h.Depo,
                Personel = h.Personel,
                Pirim = h.Pirim,
                Opsiyon = h.Opsiyon,
                Promosyon = h.Promosyon,
                SatisKosulu = h.SatisKosulu,
                SeriMiktar = h.SeriMiktar,
                Envanter = h.Envanter,
                KarsiStokKodu = h.KarsiStokKodu,
                KarsiBarkod = h.KarsiBarkod,
                Termin = h.Termin,
                Taksit = h.Taksit,
                ParaBirimi = h.ParaBirimi,
                Kur = h.Kur,
                Barkod = h.Barkod,
                Pesinat = h.Pesinat,
                Masraf = h.Masraf,
                MasrafKdv = h.MasrafKdv,
                Aciklama = h.Aciklama,
                PAciklama = h.PAciklama,
                OIV = h.OIV,
                Indirim = h.Indirim,
                OTV = h.OTV,
                HurdaIndirimi = h.HurdaIndirimi,
                GumrukVergisi = h.GumrukVergisi,
                DigerVergiler = h.DigerVergiler,
                MiktarStr = h.MiktarStr,
                Gk = h.Gk,
                GrupMiktar = h.GrupMiktar,
                TartilanMiktar = h.TartilanMiktar,
                Mf = h.Mf,
                ItSisK1 = h.ItSisK1,
                ItSisK2 = h.ItSisK2,
                ItSisK3 = h.ItSisK3,
                ItSisK4 = h.ItSisK4,
                OrjFiyat = h.OrjFiyat,
                GMiktar = h.GMiktar,
                Kod1 = h.Kod1,
                Isk5 = h.Isk5,
                Isk6 = h.Isk6,
                Uıd = h.Uıd,
                OtvMaTrahi = h.OtvMaTrahi,
                Kdv_ExMaTrahi = h.Kdv_ExMaTrahi,
                SatirNo = h.SatirNo,
                TevkiFatUyg = h.TevkiFatUyg,
                TevkiFatTutar = h.TevkiFatTutar,
                LinkBelgeInd = h.LinkBelgeInd,
                LinkBelgeIzahat = h.LinkBelgeIzahat,
                KampanyaAciklamasi = h.KampanyaAciklamasi
            }).ToList();

            return dtoList;
        }
    }
}
