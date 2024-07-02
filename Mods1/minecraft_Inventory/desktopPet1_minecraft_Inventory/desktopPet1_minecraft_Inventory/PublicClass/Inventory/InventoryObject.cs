using desktopPet1_minecraft_Inventory.PublicClass.InventoryItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopPet1_minecraft_Inventory.PublicClass.Inventory
{
    public class InventoryObject<T> : Inventory<T> where T : InventoryItem.InventoryItem
    {
        public InventoryObject(int lenght, Func<T> get_itme_default) : base(lenght)
        {
            this.get_itme_default = get_itme_default;
        }

        private Func<T> get_itme_default = null;

        protected override T GetInventoryItemDefault()
        {
            return get_itme_default?.Invoke();
        }
    }
}
