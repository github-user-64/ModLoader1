using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;

namespace PublicLibrary1.JsonDispose1
{
    /// <summary>
    /// Json的简易操作
    /// </summary>
    public partial class MyJson1
    {
        /// <summary>
        /// Json文件位置
        /// </summary>
        public string FilePath1 { set; get; } = null;
        /// <summary>
        /// 默认结构, 但文件操作出错时根据该对象修复文件
        /// </summary>
        public object DefaultStructure { set; get; } = null;


        /// <summary>
        /// MyJson1()//不修改
        /// </summary>
        public MyJson1() { }
        /// <summary>
        /// MyJson1(Json文件位置)
        /// </summary>
        /// <param name="FilePath1"></param>
        public MyJson1(string FilePath1)
        {
            this.FilePath1 = FilePath1;
        }


        //private void RepairFile()
        //{
        //    try
        //    {
        //        if (!Repair) return;
        //        File.WriteAllText(FilePath1, JsonConvert.SerializeObject(DefaultStructure), Encoding.UTF8);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception($"MyJson1.RepairFile:{e.Message}");
        //    }
        //}

        /// <summary>
        /// 获取数据<将数据转为该类型的对象>()
        /// </summary>
        /// <typeparam name="T">将数据转为该类型的对象</typeparam>
        /// <returns>指定类型的对象, 出错时返回该类型的空值</returns>
        public T Get<T>()
        {
            try
            {
                if (!File.Exists(FilePath1)) throw new Exception($"文件不存在:{FilePath1}");

                JObject jObject1 = JObject.Parse(File.ReadAllText(FilePath1, Encoding.UTF8));

                return JsonConvert.DeserializeObject<T>(jObject1.ToString());
            }
            catch (Exception ex)
            {
                //RepairFile();
                //return default;
                MethodBase mb = MethodBase.GetCurrentMethod();
                throw new Exception($"{mb?.DeclaringType.Name}.{mb?.Name}:{ex.Message}");
            }
        }
        /// <summary>
        /// 获取数据<将数据转为该类型的对象>(), 上面的Get在转化直接保存的数组会出问题
        /// </summary>
        /// <typeparam name="T">将数据转为该类型的对象</typeparam>
        /// <returns>指定类型的对象, 出错时返回该类型的空值</returns>
        public T Get2<T>()
        {
            try
            {
                if (!File.Exists(FilePath1)) throw new Exception($"文件不存在:{FilePath1}");

                return JsonConvert.DeserializeObject<T>(File.ReadAllText(FilePath1, Encoding.UTF8));
            }
            catch (Exception ex)
            {
                //RepairFile();
                //return default;
                MethodBase mb = MethodBase.GetCurrentMethod();
                throw new Exception($"{mb?.DeclaringType.Name}.{mb?.Name}:{ex.Message}");
            }
        }
        /// <summary>
        /// 获取数据()
        /// </summary>
        /// <returns>JObject</returns>
        public JObject Get()
        {
            try
            {
                if (!File.Exists(FilePath1)) throw new Exception($"文件不存在:{FilePath1}");

                return JObject.Parse(File.ReadAllText(FilePath1, Encoding.UTF8));
            }
            catch (Exception ex)
            {
                //RepairFile();
                //return default;
                MethodBase mb = MethodBase.GetCurrentMethod();
                throw new Exception($"{mb?.DeclaringType.Name}.{mb?.Name}:{ex.Message}");
            }
        }

        /// <summary>
        /// 保存数据(要保存的对象)
        /// </summary>
        /// <param name="val">要保存的对象</param>
        public void Save(object val)
        {
            try
            {
                File.WriteAllText(FilePath1, JsonConvert.SerializeObject(val), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                //RepairFile();
                MethodBase mb = MethodBase.GetCurrentMethod();
                throw new Exception($"{mb?.DeclaringType.Name}.{mb?.Name}:{ex.Message}");
            }
        }
        /// <summary>
        /// 保存数据(文本)
        /// </summary>
        /// <param name="val">文本</param>
        public void Save(string val)
        {
            try
            {
                File.WriteAllText(FilePath1, val, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                //RepairFile();
                MethodBase mb = MethodBase.GetCurrentMethod();
                throw new Exception($"{mb?.DeclaringType.Name}.{mb?.Name}:{ex.Message}");
            }
        }

        /// <summary>
        /// 字符串转对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="string1"></param>
        /// <returns></returns>
        public T StringToObject<T>(string string1)
        {
            try
            {
                JObject jObject1 = JObject.Parse(string1.ToString());

                return JsonConvert.DeserializeObject<T>(jObject1.ToString());
            }
            catch (Exception ex)
            {
                MethodBase mb = MethodBase.GetCurrentMethod();
                throw new Exception($"{mb?.DeclaringType.Name}.{mb?.Name}:{ex.Message}");
            }
        }
    }
}
