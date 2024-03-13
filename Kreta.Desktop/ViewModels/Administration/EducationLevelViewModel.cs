﻿using CommunityToolkit.Mvvm.ComponentModel;
using Kreta.Desktop.ViewModels.Base;
using Kreta.Shared.Models;
using System.Collections.ObjectModel;

namespace Kreta.Desktop.ViewModels.Administration
{
    public partial class EducationLevelViewModel : BaseViewModel
    {
        public string Title { get; set; } = "Tanulmányi szint kezelése";

        [ObservableProperty]
        private ObservableCollection<EducationLevel> _educationLevels=new();

        [ObservableProperty]
        private EducationLevel _selectedEducationLevel = new();
    }
}
