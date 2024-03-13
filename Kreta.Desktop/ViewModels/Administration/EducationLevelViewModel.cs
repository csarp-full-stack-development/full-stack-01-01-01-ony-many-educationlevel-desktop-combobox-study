using CommunityToolkit.Mvvm.ComponentModel;
using Kreta.Desktop.ViewModels.Base;
using Kreta.HttpService.Services;
using Kreta.Shared.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Kreta.Desktop.ViewModels.Administration
{
    public partial class EducationLevelViewModel : BaseViewModel
    {
        private readonly IEducationLevelService? _educationLevelService;
        public string Title { get; set; } = "Tanulmányi szint kezelése";

        [ObservableProperty]
        private ObservableCollection<EducationLevel> _educationLevels = new();

        [ObservableProperty]
        private EducationLevel _selectedEducationLevel = new();

        public EducationLevelViewModel()
        {
        }

        public EducationLevelViewModel(IEducationLevelService? educationLevelService)
        {
            _educationLevelService = educationLevelService;
        }

        private async Task UpdateView()
        {
            if (_educationLevelService is not null)
            {
                List<EducationLevel> educationLevels = await _educationLevelService.SelectAllAsync();
                EducationLevels = new ObservableCollection<EducationLevel>(educationLevels);
            }
        }
    }
}
