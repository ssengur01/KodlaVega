using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Application.Strategies
{
    public interface ICurrentDocumentStrategy<TDto>
    {
        List<TDto> List();
        TDto? GetById(int id);
    }
}
