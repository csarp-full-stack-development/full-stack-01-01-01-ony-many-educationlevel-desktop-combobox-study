﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kreta.Desktop.ViewModels.Base;
using Kreta.HttpService.Services;
using Kreta.Shared.Models;
using Kreta.Shared.Responses;
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

        public async override Task InitializeAsync()
        {
            await UpdateView();
            await base.InitializeAsync();
        }

        [RelayCommand]
        private void DoNewEducationLevel()
        {
            SelectedEducationLevel = new();
        }

        [RelayCommand]
        private async Task DoDeleteEducationLevel(EducationLevel educationLevel)
        {
            if (_educationLevelService is not null)
            {
                ControllerResponse result= await _educationLevelService.DeleteAsync(educationLevel.Id);
                if (result.IsSuccess)
                {
                    await UpdateView();
                }
            }
        }

        [RelayCommand]
        private async Task DoSaveEducationLevel(EducationLevel educationLevel)
        {
            if (_educationLevelService is not null)
            {
                ControllerResponse response = new();
                if (educationLevel.HasId)
                {
                    response = await _educationLevelService.UpdateAsync(educationLevel);   
                }
                else
                {
                    response=await _educationLevelService.InsertAsync(educationLevel);
                }
                if (response.IsSuccess) 
                {
                    await UpdateView();
                }
            }
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
