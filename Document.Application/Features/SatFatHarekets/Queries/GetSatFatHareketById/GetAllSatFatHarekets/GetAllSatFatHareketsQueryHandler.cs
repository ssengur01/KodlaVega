using Document.Application.Features.AlFatHarekets.Queries.GetAlFatHareketById.GetAllAlFatHarekets;
using Document.Application.Repositories;
using Document.Domain.Entities;
using Document.Shared.Dtos;
using Document.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Features.SatFatHarekets.Queries.GetSatFatHareketById.GetAllSatFatHarekets
{
    public class GetAllSatFatHareketsQueryHandler : IRequestHandler<GetAllSatFatHareketsQuery, List<SatFatHareketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSatFatHareketsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SatFatHareketDto>> Handle(GetAllSatFatHareketsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<SatFatHareket> satFatHarekets;

            satFatHarekets = await _unitOfWork.SatFatHareketRepository.GetAllAsync();

            var dtoList = satFatHarekets.Select(satFatHareket => new SatFatHareketDto
            {
                Ind = satFatHareket.Ind,
                Tarih = satFatHareket.Tarih,
                Detay = satFatHareket.Detay,
                Selected = satFatHareket.Selected,
                EvrakNo = satFatHareket.EvrakNo,
                FirmaNo = satFatHareket.FirmaNo,
                StokNo = satFatHareket.StokNo,
                MalinCinsi = satFatHareket.MalinCinsi,
                StokKodu = satFatHareket.StokKodu,
                StokTipi = satFatHareket.StokTipi,
                Miktar = satFatHareket.Miktar,
                BirimMiktar = satFatHareket.BirimMiktar,
                Birim = satFatHareket.Birim,
                BirimEx = satFatHareket.BirimEx,
                Kdv = satFatHareket.Kdv,
                KdvTutari = satFatHareket.KdvTutari,
                Isk1 = satFatHareket.Isk1,
                Isk2 = satFatHareket.Isk2,
                Isk3 = satFatHareket.Isk3,
                Isk4 = satFatHareket.Isk4,
                AFiyatı = satFatHareket.AFiyatı,
                Fiyati = satFatHareket.Fiyati,
                GercekToplam = satFatHareket.GercekToplam,
                Depo = satFatHareket.Depo,
                Personel = satFatHareket.Personel,
                Pirim = satFatHareket.Pirim,
                Opsiyon = satFatHareket.Opsiyon,
                Promosyon = satFatHareket.Promosyon,
                SatisKosulu = satFatHareket.SatisKosulu,
                SeriMiktar = satFatHareket.SeriMiktar,
                Envanter = satFatHareket.Envanter,
                KarsiStokKodu = satFatHareket.KarsiStokKodu,
                KarsiBarkod = satFatHareket.KarsiBarkod,
                Termin = satFatHareket.Termin,
                Taksit = satFatHareket.Taksit,
                ParaBirimi = satFatHareket.ParaBirimi,
                Kur = satFatHareket.Kur,
                Barkod = satFatHareket.Barkod,
                Pesinat = satFatHareket.Pesinat,
                Masraf = satFatHareket.Masraf,
                MasrafKdv = satFatHareket.MasrafKdv,
                Aciklama = satFatHareket.Aciklama,
            }).ToList();

            return dtoList;
        }
    }
}
