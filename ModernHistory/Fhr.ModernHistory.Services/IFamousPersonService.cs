using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Models;

namespace Fhr.ModernHistory.Services
{
    public interface IFamousPersonService
    {
            IEnumerable<FamousPerson> FindAll();

            FamousPerson FindById(Object id);
      }
}
