using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selling.Repo
{
    interface iSelling<Sellings>
    {
        bool Create(Sellings m);
        bool Update(Sellings n);
        bool Delete(string o);
        List<Sellings> GetAll();
        Sellings GetById(string code);
    }
}
