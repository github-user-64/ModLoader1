using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModLoaderLibrary1.ModManager.PublicClass1.Configs
{
    public class Config1
    {
        public Enums.Language1 language { get; set; } = Enums.Language1.China;


        public void Save()
        {
            throw new NotImplementedException();
            //string path1 = $@"{GetVal1.procedure1.StartupPath1}{GetVal1.Paths.Folders.Mods}\{Class1.c1.thisModObject.modConfig.path}\{GetVal1.Paths.Files.MyConfig}";

            //try
            //{
            //    new PublicLibrary1.JsonDispose1.MyJson1(path1).Save(this);
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception($"保存配置文件失败: {ex.Message}");
            //}
        }

        public Config1 Read()
        {
            throw new NotImplementedException();
            //string path1 = $@"{GetVal1.procedure1.StartupPath1}{GetVal1.Paths.Folders.Mods}\{Class1.c1.thisModObject.modConfig.path}\{GetVal1.Paths.Files.MyConfig}";

            //try
            //{
            //    return new PublicLibrary1.JsonDispose1.MyJson1(path1).Get2<MyConfig>();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception($"读取配置文件失败: {ex.Message}");
            //}
        }
    }
}
