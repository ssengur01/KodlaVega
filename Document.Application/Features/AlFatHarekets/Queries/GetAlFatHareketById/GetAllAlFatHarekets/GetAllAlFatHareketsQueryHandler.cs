using Document.Application.Repositories;
using Document.Domain.Entities;
using Document.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Features.AlFatHarekets.Queries.GetAlFatHareketById.GetAllAlFatHarekets
{
    public class GetAllAlFatHareketsQueryHandler : IRequestHandler<GetAllAlFatHareketsQuery, List<AlFatHareketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAlFatHareketsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<AlFatHareketDto>> Handle(GetAllAlFatHareketsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<AlFatHareket> alFatHarekets;
           
            alFatHarekets = await _unitOfWork.AlFatHareketRepository.GetAllAsync();
          
            var dtoList = alFatHarekets.Select(alFatHareket => new AlFatHareketDto
            {
                Ind = alFatHareket.Ind,
                Tarih = alFatHareket.Tarih,
                Detay = alFatHareket.Detay,
                Selected = alFatHareket.Selected,
                EvrakNo = alFatHareket.EvrakNo,
                FirmaNo = alFatHareket.FirmaNo,
                StokNo = alFatHareket.StokNo,
                MalinCinsi = alFatHareket.MalinCinsi,
                StokKodu = alFatHareket.StokKodu,
                StokTipi = alFatHareket.StokTipi,
                Miktar = alFatHareket.Miktar,
                BirimMiktar = alFatHareket.BirimMiktar,
                Birim = alFatHareket.Birim,
                BirimEx = alFatHareket.BirimEx,
                Kdv = alFatHareket.Kdv,
                KdvTutari = alFatHareket.KdvTutari,
                Isk1 = alFatHareket.Isk1,
                Isk2 = alFatHareket.Isk2,
                Isk3 = alFatHareket.Isk3,
                Isk4 = alFatHareket.Isk4,
                AFiyatı = alFatHareket.AFiyatı,
                Fiyati = alFatHareket.Fiyati,
                GercekToplam = alFatHareket.GercekToplam,
                Depo = alFatHareket.Depo,
                Personel = alFatHareket.Personel,
                Pirim = alFatHareket.Pirim,
                Opsiyon = alFatHareket.Opsiyon,
                Promosyon = alFatHareket.Promosyon,
                SatisKosulu = alFatHareket.SatisKosulu,
                SeriMiktar = alFatHareket.SeriMiktar,
                Envanter = alFatHareket.Envanter,
                KarsiStokKodu = alFatHareket.KarsiStokKodu,
                KarsiBarkod = alFatHareket.KarsiBarkod,
                Termin = alFatHareket.Termin,
                Taksit = alFatHareket.Taksit,
                ParaBirimi = alFatHareket.ParaBirimi,
                Kur = alFatHareket.Kur,
                Barkod = alFatHareket.Barkod,
                Pesinat = alFatHareket.Pesinat,
                Masraf = alFatHareket.Masraf,
                MasrafKdv = alFatHareket.MasrafKdv,
                Aciklama = alFatHareket.Aciklama,
                PAciklama = alFatHareket.PAciklama,
                OIV = alFatHareket.OIV,
                Indirim = alFatHareket.Indirim,
                OTV = alFatHareket.OTV,
                HurdaIndirimi = alFatHareket.HurdaIndirimi,
                GumrukVergisi = alFatHareket.GumrukVergisi,
                DigerVergiler = alFatHareket.DigerVergiler,
                MiktarStr = alFatHareket.MiktarStr,
                Gk = alFatHareket.Gk,
                GrupMiktar = alFatHareket.GrupMiktar,
                TartilanMiktar = alFatHareket.TartilanMiktar,
                Mf = alFatHareket.Mf,
                ItSisK1 = alFatHareket.ItSisK1,
                ItSisK2 = alFatHareket.ItSisK2,
                ItSisK3 = alFatHareket.ItSisK3,
                ItSisK4 = alFatHareket.ItSisK4,
                OrjFiyat = alFatHareket.OrjFiyat,
                GMiktar = alFatHareket.GMiktar,
                Kod1 = alFatHareket.Kod1,
                Isk5 = alFatHareket.Isk5,
                Isk6 = alFatHareket.Isk6,
                Uıd = alFatHareket.Uıd,
                OtvMaTrahi = alFatHareket.OtvMaTrahi,
                Kdv_ExMaTrahi = alFatHareket.Kdv_ExMaTrahi,
                SatirNo = alFatHareket.SatirNo,
                TevkiFatUyg = alFatHareket.TevkiFatUyg,
                TevkiFatTutar = alFatHareket.TevkiFatTutar,
                LinkBelgeInd = alFatHareket.LinkBelgeInd,
                LinkBelgeIzahat = alFatHareket.LinkBelgeIzahat,
                KampanyaAciklamasi = alFatHareket.KampanyaAciklamasi
            }).ToList();

            return dtoList;
        }
    }
}
