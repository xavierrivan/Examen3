using System.Windows;

namespace Examen3.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowFavoriteCharacter_Click(object sender, RoutedEventArgs e)
        {
            var favoriteCharacterWindow = new FavoriteCharacter();
            favoriteCharacterWindow.Show();
        }
    }
}
