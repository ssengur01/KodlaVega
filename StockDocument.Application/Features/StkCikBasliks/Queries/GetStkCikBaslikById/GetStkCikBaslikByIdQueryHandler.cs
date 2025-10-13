using MediatR;
using StockDocument.Application.Repositories;
using StockDocument.Shared.Dtos;
using StockDocument.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Application.Features.StkCikBasliks.Queries.GetStkCikBaslikById
{
    public class GetStkCikBaslikByIdQueryHandler : IRequestHandler<GetStkCikBaslikByIdQuery, StkCikBaslikDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetStkCikBaslikByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<StkCikBaslikDto?> Handle(GetStkCikBaslikByIdQuery request, CancellationToken cancellationToken)
        {
            var stkCikBaslik = await _unitOfWork.StkCikBaslikRepository.GetByIdAsync(request.IND);

            if (stkCikBaslik == null)
            {
                return null;
            }

            var dto = new StkCikBaslikDto(stkCikBaslik)
            {
                IND = stkCikBaslik.IND,  
                FIRMANO = stkCikBaslik.FIRMANO,
                FIRMAADI = stkCikBaslik.FIRMAADI,
                BELGENO = stkCikBaslik.BELGENO,
                BELGETIPI =(StockType?)stkCikBaslik.BELGETIPI,
                TARIH = stkCikBaslik.TARIH,
                TUTAR = stkCikBaslik.TUTAR,
                ARATOPLAM = stkCikBaslik.ARATOPLAM,
                PARABIRIMI = stkCikBaslik.PARABIRIMI,
                IADE = stkCikBaslik.IADE,
                GIRIS = stkCikBaslik.GIRIS,
                KUR = stkCikBaslik.KUR,
                KDV = stkCikBaslik.KDV,
                IPTAL = stkCikBaslik.IPTAL,
                MUHASEBELESMEYECEK = stkCikBaslik.MUHASEBELESMEYECEK,
                ODEMETARIHI = stkCikBaslik.ODEMETARIHI,
                CARIHAREKETEYAZ = stkCikBaslik.CARIHAREKETEYAZ,
                STATUS = stkCikBaslik.STATUS,
                STOKHAREKETEYAZ = stkCikBaslik.STOKHAREKETEYAZ,
                SUCCESS = stkCikBaslik.SUCCESS
            };
            return dto;
        }
    }
}
