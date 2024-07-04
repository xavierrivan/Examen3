using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Examen3.Models;
using Examen3.Services;
using Microsoft.Toolkit.Mvvm.Input;

namespace Examen3.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly CountryService _countryService;
        private readonly DatabaseContext _dbContext;

        public ObservableCollection<Country> Countries { get; set; }
        public ICommand LoadCountriesCommand { get; }
        public ICommand SaveCountryCommand { get; }
        public ICommand DeleteCountryCommand { get; }

        public MainViewModel()
        {
            _countryService = new CountryService();
            _dbContext = new DatabaseContext();
            Countries = new ObservableCollection<Country>();

            LoadCountriesCommand = new RelayCommand(async () => await LoadCountriesAsync());
            SaveCountryCommand = new RelayCommand<Country>(async (country) => await SaveCountryAsync(country));
            DeleteCountryCommand = new RelayCommand<Country>(async (country) => await DeleteCountryAsync(country));
        }

        private async Task LoadCountriesAsync()
        {
            var countries = await _countryService.GetCountriesAsync();
            foreach (var country in countries)
            {
                // Asigna un código único a cada país
                country.Code = GenerateUniqueCode("SC");
                Countries.Add(country);
                _dbContext.Countries.Add(country);
            }
            await _dbContext.SaveChangesAsync();
        }

        private string GenerateUniqueCode(string initials)
        {
            var random = new Random();
            return $"{initials}{random.Next(1000, 2000)}";
        }

        private async Task SaveCountryAsync(Country country)
        {
            _dbContext.Countries.Update(country);
            await _dbContext.SaveChangesAsync();
        }

        private async Task DeleteCountryAsync(Country country)
        {
            _dbContext.Countries.Remove(country);
            await _dbContext.SaveChangesAsync();
            Countries.Remove(country);
        }
    }
}
