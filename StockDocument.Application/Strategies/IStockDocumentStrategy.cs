using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Application.Strategies
{
    public interface IStockDocumentStrategy<TDto>
    {
        List<TDto> List();
        TDto? GetById(int id);
    }
}
