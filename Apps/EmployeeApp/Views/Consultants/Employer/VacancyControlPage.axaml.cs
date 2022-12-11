﻿using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using EmployeeApp.ViewModels.Consultants.Employer;
using PropertyChanged;
using ReactiveUI;

namespace EmployeeApp.Views.Consultants.Employer;

[DoNotNotify]
public partial class VacancyControlPage : ReactiveUserControl<VacancyControlViewModel>
{
    public VacancyControlPage()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}