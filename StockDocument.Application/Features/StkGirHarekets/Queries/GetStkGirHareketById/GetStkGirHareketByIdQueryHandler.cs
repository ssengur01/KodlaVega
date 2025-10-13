using MediatR;
using StockDocument.Application.Repositories;
using StockDocument.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Application.Features.StkGirHarekets.Queries.GetStkGirHareketById
{
    public class GetStkGirHareketByIdQueryHandler : IRequestHandler<GetStkGirHareketByIdQuery, List<StkGirHareketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetStkGirHareketByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<StkGirHareketDto>> Handle(GetStkGirHareketByIdQuery request, CancellationToken cancellationToken)
        {
            var stkGirHarekets = await _unitOfWork.StkGirHareketRepository.FindAsync(h => h.Ind == request.Ind);

            if (stkGirHarekets == null || !stkGirHarekets.Any())
                return new List<StkGirHareketDto>();

            var dtoList = stkGirHarekets.Select(h => new StkGirHareketDto
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
                Birim = h.Birim,
                Kdv = h.Kdv,
                GercekToplam = h.GercekToplam,
                Depo = h.Depo,
                Personel = h.Personel,
                Pirim = h.Pirim,
                Opsiyon = h.Opsiyon,
                Termin = h.Termin,
                Taksit = h.Taksit,
                ParaBirimi = h.ParaBirimi,
                Kur = h.Kur,
                Aciklama = h.Aciklama,
                SatirNo = h.SatirNo,
            }).ToList();

            return dtoList;
        }
    }
}
