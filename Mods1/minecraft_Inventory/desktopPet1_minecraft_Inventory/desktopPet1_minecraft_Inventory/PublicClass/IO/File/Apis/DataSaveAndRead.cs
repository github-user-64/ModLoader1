using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1_minecraft_Inventory.PublicClass.IO.File.Apis
{
    public interface IDataSaveAndRead<T>
    {
        void Save(T data);
        T Read();
    }
}
