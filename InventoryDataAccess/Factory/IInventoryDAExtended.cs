using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDataAccess.Factory
{
    public interface IInventoryDAExtended<T>: IInventoryDA<T>
    {
        bool DeleteEntity(int id, string key);
        T GetEntityById(int id, string key);
    }
}
