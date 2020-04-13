using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Sline.View.Views
{
    public class MainDummy
    {
        public string Result => "HALLO";
    }
    public class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
