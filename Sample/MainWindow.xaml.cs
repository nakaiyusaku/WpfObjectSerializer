using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace Sample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Window> windowList = new List<Window>();
        string xaml = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded( object sender, RoutedEventArgs e )
        {
            windowList.Add( new Window1() );
            windowList.Last().Show();
        }

        private void Button_Click( object sender, RoutedEventArgs e )
        {
            xaml = WpfObjectSerializer.WpfObjectSerializer.Serialize( windowList.Last() );
            MessageBox.Show( xaml );
        }

        private void Button_Click_1( object sender, RoutedEventArgs e )
        {
            if( xaml == "" )
            {
                MessageBox.Show( "Not Serialized." );
                return;
            }

            var window = WpfObjectSerializer.WpfObjectSerializer.Deserialize( xaml ) as Window;
            windowList.Add( window );
            windowList.Last().Show();
        }

        private void Window_Closed( object sender, System.EventArgs e )
        {
            foreach( var item in windowList )
            {
                item.Close();
            }
        }
    }
}
