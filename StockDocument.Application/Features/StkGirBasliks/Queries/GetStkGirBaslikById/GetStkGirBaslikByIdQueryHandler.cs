using MediatR;
using StockDocument.Application.Repositories;
using StockDocument.Shared.Dtos;
using StockDocument.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Application.Features.StkGirBasliks.Queries.GetStkGirBaslikById
{
    public class GetStkGirBaslikByIdQueryHandler : IRequestHandler<GetStkGirBaslikByIdQuery, StkGirBaslikDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetStkGirBaslikByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<StkGirBaslikDto?> Handle(GetStkGirBaslikByIdQuery request, CancellationToken cancellationToken)
        {
            var stkGirBaslik = await _unitOfWork.StkGirBaslikRepository.GetByIdAsync(request.IND);
            
            if (stkGirBaslik == null)
            {
                return null;
            }

            var dto = new StkGirBaslikDto(stkGirBaslik)
            {
                IND = stkGirBaslik.IND,
                FIRMAADI = stkGirBaslik.FIRMAADI,
                TUTAR = stkGirBaslik.TUTAR,
                BELGENO = stkGirBaslik.BELGENO,
                TARIH = stkGirBaslik.TARIH,
                KDV = stkGirBaslik.KDV,
                BELGETIPI = (StockType?)stkGirBaslik.BELGETIPI,
                CREDATE = stkGirBaslik.CREDATE,
                LADATE = stkGirBaslik.LADATE,
                FIRMANO = stkGirBaslik.FIRMANO,
                PARABIRIMI = stkGirBaslik.PARABIRIMI,
                IADE = stkGirBaslik.IADE,
                KUR = stkGirBaslik.KUR,
                STATUS = stkGirBaslik.STATUS,
                GIRIS = stkGirBaslik.GIRIS,
                ODEMETARIHI = stkGirBaslik.ODEMETARIHI,
                SATISSEKLI = stkGirBaslik.SATISSEKLI,
                ARATOPLAM = stkGirBaslik.ARATOPLAM,
                SELECTED = stkGirBaslik.SELECTED,
                DEPO = stkGirBaslik.DEPO,
                SUCCESS = stkGirBaslik.SUCCESS,
                IPTAL = stkGirBaslik.IPTAL,
                STOKHAREKETEYAZ = stkGirBaslik.STOKHAREKETEYAZ,
                CARIHAREKETEYAZ = stkGirBaslik.CARIHAREKETEYAZ,
                HAREKETDEPOSU = stkGirBaslik.HAREKETDEPOSU,
                MUHASEBELESMEYECEK = stkGirBaslik.MUHASEBELESMEYECEK,
                CONVERTED = stkGirBaslik.CONVERTED,
                ODENEN = stkGirBaslik.ODENEN
            };

            return dto;
        }
    }
}
