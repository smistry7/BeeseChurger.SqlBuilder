using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeseChurger.SqlBuilder.Builders.Update
{
    public interface IUpdateBuilder
    {
        /// <summary>
        /// The Update Method
        /// 
        /// Use this to initialise an UPDATE SQL query
        /// </summary>
        /// <param name="table">String representation of the table to update</param>
        /// <returns></returns>
        //ISetBuilder Update(string table);
    }
}
