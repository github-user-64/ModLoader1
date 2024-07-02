using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ModLoaderLibrary1.ModManager.UserControls.items
{
    public partial class item1
    {
        private Apis.ModManagerTS ts = null;

        public const string String_Ico_Enable = "\xe64b";
        public const string String_Ico_Disable = "\xe61a";

        public PublicClass1.Mod.Data_ModConfigAModInfor d_mm
        {
            get => (PublicClass1.Mod.Data_ModConfigAModInfor)GetValue(d_mmProperty);
            set => SetValue(d_mmProperty, value);
        }
        public static DependencyProperty d_mmProperty = DependencyProperty.Register(
            nameof(d_mm), typeof(PublicClass1.Mod.Data_ModConfigAModInfor), typeof(item1), new PropertyMetadata(default(PublicClass1.Mod.Data_ModConfigAModInfor)));

        //mod的标题
        public string mod_Title
        {
            get => (string)GetValue(mod_TitleProperty);
            set => SetValue(mod_TitleProperty, value);
        }
        public static DependencyProperty mod_TitleProperty = DependencyProperty.Register(
            nameof(mod_Title), typeof(string), typeof(item1), new PropertyMetadata(default(string)));
        //mod的版本
        public string mod_Version
        {
            get => (string)GetValue(mod_VersionProperty);
            set => SetValue(mod_VersionProperty, value);
        }
        public static DependencyProperty mod_VersionProperty = DependencyProperty.Register(
            nameof(mod_Version), typeof(string), typeof(item1), new PropertyMetadata(default(string)));
        //mod的详细信息
        public string mod_Information
        {
            get => (string)GetValue(mod_InformationProperty);
            set => SetValue(mod_InformationProperty, value);
        }
        public static DependencyProperty mod_InformationProperty = DependencyProperty.Register(
            nameof(mod_Information), typeof(string), typeof(item1), new PropertyMetadata(default(string)));
        //mod的图标
        public ImageSource mod_Ico_ImageSource
        {
            get => (ImageSource)GetValue(mod_Ico_ImageSourceProperty);
            set => SetValue(mod_Ico_ImageSourceProperty, value);
        }
        public static DependencyProperty mod_Ico_ImageSourceProperty = DependencyProperty.Register(
            nameof(mod_Ico_ImageSource), typeof(ImageSource), typeof(item1), new PropertyMetadata(default(ImageSource)));
    }
}
