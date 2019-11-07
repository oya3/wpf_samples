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
using WpfApp1.Common;

namespace WpfApp1.Views
{
    /// <summary>
    /// HeaderView.xaml の相互作用ロジック
    /// </summary>
    public partial class HeaderView : UserControl
    {
        // 1. 依存プロパティの作成
        public static readonly DependencyProperty HeaderInfoProperty =
            DependencyProperty.Register("HeaderInfo",
                                        typeof(string),
                                        typeof(HeaderView),
                                        new FrameworkPropertyMetadata("HeaderInfo", new PropertyChangedCallback(OnTitleChanged)));

        // 2. CLI用プロパティを提供するラッパー
        public string HeaderInfo
        {
            get { return (string)GetValue(HeaderInfoProperty); }
            set { SetValue(HeaderInfoProperty, value); }
        }

        // 3. 依存プロパティが変更されたとき呼ばれるコールバック関数の定義
        private static void OnTitleChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            // オブジェクトを取得して処理する
            HeaderView ctrl = obj as HeaderView;
            if (ctrl != null)
            {
                var headerinfo = ctrl.HeaderInfo;
                System.Diagnostics.Debug.WriteLine(string.Format("headerinfo: {0}", headerinfo));
                /*
                System.Diagnostics.Debug.WriteLine(string.Format("headerinfo: number{0}, rectangle:{1}{2}{3}{4}",
                    headerinfo.Number,
                    headerinfo.Rectangle.x, headerinfo.Rectangle.y,
                    headerinfo.Rectangle.w, headerinfo.Rectangle.h));
                    */
            }
        }
        public HeaderView()
        {
            InitializeComponent();
        }
    }
}
