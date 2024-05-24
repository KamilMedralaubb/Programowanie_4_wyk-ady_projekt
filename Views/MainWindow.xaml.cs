using Avalonia; 
using Avalonia.Controls; 
using Avalonia.Markup.Xaml; 

namespace ACalc.Views 
{
    public class MainWindow : Window 
    {
        public MainWindow() 
        {
            InitializeComponent();
        }

        private void InitializeComponent() // Prywatna metoda do inicjalizacji komponentów.
        {
            AvaloniaXamlLoader.Load(this); // £aduje XAML dla tego okna, przypisuj¹c elementy zdefiniowane w XAML do tej instancji okna.
        }
    }
}
