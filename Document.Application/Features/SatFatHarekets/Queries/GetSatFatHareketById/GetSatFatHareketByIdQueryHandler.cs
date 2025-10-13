using Document.Application.Features.AlFatHarekets.Queries.GetAlFatHareketById;
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

namespace Document.Application.Features.SatFatHarekets.Queries.GetSatFatHareketById
{
    public class GetSatFatHareketByIdQueryHandler : IRequestHandler<GetSatFatHareketByIdQuery, List<SatFatHareketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSatFatHareketByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SatFatHareketDto>> Handle(GetSatFatHareketByIdQuery request, CancellationToken cancellationToken)
        {
            var satFatHarekets = await _unitOfWork.SatFatHareketRepository.FindAsync(h => h.Ind == request.Ind);

            if (satFatHarekets == null || !satFatHarekets.Any())
                return new List<SatFatHareketDto>();

            var dtoList = satFatHarekets.Select(h => new SatFatHareketDto
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
            }).ToList();

            return dtoList;
        }
    }
}
