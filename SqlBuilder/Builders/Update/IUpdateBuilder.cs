using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeseChurger.SqlBuilder.Builders.Update
{
    public interface IUpdateBuilder
    {
        ISetBuilder Update(string table);
    }
}
