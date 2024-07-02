using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace desktopPet1_expansion_ldnn.PublicClass1.PetObjects.ldnn
{
    public partial class body : desktopPet1_Front.Pet.PetObject
    {
        //这里真是瞎几把乱写
        public body()
        {
            InitializeComponent();

            LeftClick += (s) =>
            {
                if (isDragDelta) return;
                LeftClick_new?.Invoke(this);
            };
            RightClick += (s) => OpenRightMenu?.Invoke(this);

            if (Class1.modSettings != null) Class1.modSettings.ModSettingsChanged += Class1_ModSettingsChanged;

            Class1_ModSettingsChanged(Class1.modSettings?.thisModSettingsData);

            #region 为了让Thumb这叼毛的事件能传递出去
            thumb1.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler((s, e) =>
            {
                e.Handled = false;
            }), true);
            thumb1.AddHandler(MouseLeftButtonUpEvent, new MouseButtonEventHandler((s, e) =>
            {
                e.Handled = false;
            }), true);
            #endregion

            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(TimeSpan.TicksPerSecond * 10);
        }

        public ExpansionPets.petState petState = ExpansionPets.petState.not;
        public System.Windows.Threading.DispatcherTimer timer = null;
        private ExpansionPets.data1 data_ = null;
        public ExpansionPets.data1 data
        {
            get => data_;
            set
            {
                data_ = value;
                dataChanged();
            }
        }
        public message message = null;
        public FrameworkElement message_Parent = null;
        public event Action<body> LeftClick_new = null;
        public event Action<body> OpenRightMenu = null;
        private bool isDragDelta = false;
        private double scaleTransform = 1;

        public override void SetImg(ImageSource img)
        {
            image1.Source = img;
        }

        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            isDragDelta = true;

            SetX(GetX() + e.HorizontalChange * scaleTransform);
            SetY(GetY() + e.VerticalChange * scaleTransform);
        }

        private void PetObject_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragDelta = false;
        }

        private void Class1_ModSettingsChanged(ModSettings.modSettingsData obj)
        {
            if (obj == null) return;

            scaleTransform = obj.scaleTransform;

            RenderTransform_ScaleTransform.ScaleX = scaleTransform;
            RenderTransform_ScaleTransform.ScaleY = scaleTransform;

            DebugUI_grid1.Visibility = obj.isDebug ? Visibility.Visible : Visibility.Collapsed;

            if (obj.isDebug) dataChanged();
        }

        private void dataChanged()
        {
            ExpansionPets.data1 data = this.data ?? new ExpansionPets.data1();

            DebugUI_grid1_ActualSize_border1.Margin = new Thickness(data.imgActual_StartX, data.imgActual_StartY, 0, 0);

            DebugUI_grid1_ActualSize_border1.Width = data.imgActual_Width;
            DebugUI_grid1_ActualSize_border1.Height = data.imgActual_Height;
        }
    }
}
