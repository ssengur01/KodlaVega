using Document.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Strategies
{
    public interface IDocumentStrategy<TDto>
    {
        List<TDto> List();
        TDto? GetById(int id);
    }
}
