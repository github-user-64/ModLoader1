﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace desktopPet1.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("desktopPet1.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   重写当前线程的 CurrentUICulture 属性，对
        ///   使用此强类型资源类的所有资源查找执行重写。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 &lt;!--
        ///你在这里写的东西会添加到主界面上，如果你写了啥奇奇怪怪的东西导致程序炸了那就把所有的自定义文件删了就行。
        ///在启用自定义界面后，就会在这个文件夹下依次加载[
        ///Custom_Top1.xaml,
        ///Custom_Top2.xaml,
        ///Custom_Top.....xaml
        ///]这些文件里的内容到界面。 Custom_Bottom*.xaml和Custom_Top*.xaml一样，不过Bottom会被添加到桌宠的下方，而Top会添加到上方。
        ///哦，对了这是WPF的界面代码，写完记得保存，然后再重新加载mod或者在mod设置界面刷新就可以生效了。
        ///
        ///:)
        ///
        ///顺便放些常用的属性，详细的搜索 &quot;WPF xxx&quot; 就好了:
        ///Width=&quot;0&quot;//宽度
        ///Height=&quot;0&quot;//高度
        ///Margin=&quot;0,0,0,0&quot;//边距
        ///Background=&quot;#123456&quot;//背景色
        ///Foreground=&quot;#123456&quot;//字体颜色
        ///FontSize=&quot;0&quot;//字体大小
        ///HorizontalAlignment=&quot;Left&quot;//水平对齐方式(对齐方式有Left,Center,Right,Str [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string Custom_Bottom1 {
            get {
                return ResourceManager.GetString("Custom_Bottom1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 &lt;StackPanel HorizontalAlignment=&quot;Center&quot; VerticalAlignment=&quot;Center&quot;&gt;
        ///&lt;my:Button1 Margin=&quot;6&quot; ClickAction=&quot;open&quot; Datas=&quot;https://space.bilibili.com/397516613?spm_id_from=333.1007.0.0&quot;/&gt;
        ///&lt;my:Button1 Margin=&quot;6&quot; Content=&quot;弹窗&quot; ClickAction=&quot;popup&quot; Datas=&quot;标题|内容&quot;/&gt;
        ///&lt;/StackPanel&gt;
        ///
        ///&lt;!--欸嘿～(∠・ω )⌒☆--&gt; 的本地化字符串。
        /// </summary>
        internal static string Custom_Top1 {
            get {
                return ResourceManager.GetString("Custom_Top1", resourceCulture);
            }
        }
    }
}
