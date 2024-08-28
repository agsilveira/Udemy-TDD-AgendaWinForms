using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.Interface
{
    public interface IContato
    {
         Guid Id { get; set; }
         string Nome { get; set; }
    }
}
