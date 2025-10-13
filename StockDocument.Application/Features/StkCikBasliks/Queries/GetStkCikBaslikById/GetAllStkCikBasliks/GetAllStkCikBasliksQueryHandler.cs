using MediatR;
using StockDocument.Application.Repositories;
using StockDocument.Shared.Dtos;
using StockDocument.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Application.Features.StkCikBasliks.Queries.GetStkCikBaslikById.GetAllStkCikBasliks
{
    public class GetAllStkCikBasliksQueryHandler : IRequestHandler<GetAllStkCikBasliksQuery, List<StkCikBaslikDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllStkCikBasliksQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<StkCikBaslikDto>> Handle(GetAllStkCikBasliksQuery request, CancellationToken cancellationToken)
        {
            var stkCikBasliks = await _unitOfWork.StkCikBaslikRepository.GetAllAsync();

            var dtoList = stkCikBasliks.Select(stkCikBasliks => new StkCikBaslikDto(stkCikBasliks)
            {
                IND = stkCikBasliks.IND,
                FIRMANO = stkCikBasliks.FIRMANO,
                FIRMAADI = stkCikBasliks.FIRMAADI,
                BELGENO = stkCikBasliks.BELGENO,
                BELGETIPI = (StockType?)stkCikBasliks.BELGETIPI,
                PARABIRIMI = stkCikBasliks.PARABIRIMI,
                KUR = stkCikBasliks.KUR,
                KDV = stkCikBasliks.KDV,
                ARATOPLAM = stkCikBasliks.ARATOPLAM,
                MUHASEBELESMEYECEK = stkCikBasliks.MUHASEBELESMEYECEK,
                CHECKAPATMA = stkCikBasliks.CHECKAPATMA,
                SUCCESS = stkCikBasliks.SUCCESS,
                STATUS = stkCikBasliks.STATUS,
                STOKHAREKETEYAZ = stkCikBasliks.STOKHAREKETEYAZ,
                CARIHAREKETEYAZ = stkCikBasliks.CARIHAREKETEYAZ,
                CREDATE = stkCikBasliks.CREDATE
            }).ToList();
            return dtoList;
        }
    }
}
