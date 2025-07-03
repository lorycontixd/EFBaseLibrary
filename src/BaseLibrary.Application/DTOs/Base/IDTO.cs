using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Dto.Base
{
    public interface IDto
    {
    }

    public interface IdDto : IDto
    {
        int Id { get; set; }
    }
}
