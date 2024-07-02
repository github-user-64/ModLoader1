using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace desktopPet1_Front.Expansion
{
    /// <summary>
    /// 宠物扩展
    /// </summary>
    public class ExpansionPet
    {
        /// <summary>
        /// 扩展的标题
        /// </summary>
        public string Title { get; protected set; } = null;
        /// <summary>
        /// 桌宠管理器的api, 由管理器mod赋值
        /// </summary>
        protected PetManager.Apis.IPetManager petManager = null;
        /// <summary>
        /// 扩展加载完成时触发, 由扩展触发
        /// </summary>
        public event Action Loaded = null;


        /// <summary>
        /// api[桌宠管理器]加载完成后调用
        /// </summary>
        public virtual void PetManagerLoaded(PetManager.Apis.IPetManager petManager)
        {
            this.petManager = petManager;
        }

        /// <summary>
        /// 由扩展mod实现如何将一个宠物对象添加到ui, 该方法会被多次调用
        /// </summary>
        public virtual void AddPat()
        {

        }

        /// <summary>
        /// 由扩展mod实现如何将宠物从ui删除
        /// </summary>
        /// <param name="po"></param>
        public virtual void DelPat(Pet.PetObject po)
        {
            if (po == null) return;

            petManager.DelControl(po);
            petManager.DelControl(po.MainPetObject);

            for (int i = 0; i < po.MainPetObject?.ChildrenPetObject?.Count; ++i)
            {
                petManager.DelControl(po.MainPetObject.ChildrenPetObject[i]);
            }

            for (int i = 0; i < po.ChildrenPetObject?.Count; ++i)
            {
                petManager.DelControl(po.ChildrenPetObject[i]);
            }
        }

        /// <summary>
        /// 由扩展mod实现如何将全部宠物从ui删除
        /// </summary>
        public virtual void ClearPet()
        {

        }
    }
}
