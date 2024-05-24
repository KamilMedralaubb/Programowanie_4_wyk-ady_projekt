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
            AvaloniaXamlLoader.Load(this); // Ładuje XAML dla tego okna, przypisując elementy zdefiniowane w XAML do tej instancji okna.
        }
    }
}
