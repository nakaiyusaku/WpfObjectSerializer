using System.Windows;

namespace Sample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        Window window = null;
        string xaml = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded( object sender, RoutedEventArgs e )
        {
            window = new Window1();
            window.Show();
        }

        private void Button_Click( object sender, RoutedEventArgs e )
        {
            xaml = WpfObjectSerializer.WpfObjectSerializer.Serialize( window );
            MessageBox.Show( xaml );
        }

        private void Button_Click_1( object sender, RoutedEventArgs e )
        {
            if( xaml == "" )
            {
                MessageBox.Show( "Not Serialized." );
                return;
            }

            window = WpfObjectSerializer.WpfObjectSerializer.Deserialize( xaml ) as Window;
            window.Show();
        }
    }
}
