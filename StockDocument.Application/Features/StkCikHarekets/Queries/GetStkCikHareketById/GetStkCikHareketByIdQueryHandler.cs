using MediatR;
using StockDocument.Application.Repositories;
using StockDocument.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Application.Features.StkCikHarekets.Queries.GetStkCikHareketById
{
    public class GetStkCikHareketByIdQueryHandler : IRequestHandler<GetStkCikHareketByIdQuery, List<StkCikHareketDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetStkCikHareketByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<StkCikHareketDto>> Handle(GetStkCikHareketByIdQuery request, CancellationToken cancellationToken)
        {
            var stkCikHareket = await _unitOfWork.StkCikHareketRepository.FindAsync(h => h.Ind == request.Ind);

            if(stkCikHareket == null || !stkCikHareket.Any())
                return new List<StkCikHareketDto>();

            var dtoList = stkCikHareket.Select(h => new StkCikHareketDto
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
                Termin = h.Termin,
                Taksit = h.Taksit,
                ParaBirimi = h.ParaBirimi,            
                Aciklama = h.Aciklama,               
            }).ToList();
            return dtoList;
        }
    }
}
