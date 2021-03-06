﻿using System;
using System.ComponentModel;
using Smeedee.Client.Framework.ViewModel;
using Smeedee.DomainModel.Config;
using Smeedee.DomainModel.Config.SlideConfig;
using Smeedee.Widgets.Corkboard.Controllers;
using Smeedee.Widgets.Corkboard.ViewModel;
using Smeedee.Widgets.SL.Corkboard.Views;
using TinyMVVM.Framework;

namespace Smeedee.Widgets.SL.Corkboard
{
    [WidgetInfo(Name = "Retrospective Corkboard",
                Description = "A widget to keep the retrospective notes after a retrospective meeting. Flip the widget over to add notes to either the negative or the positive side. Keep improving! :)",
                Author = "Smeedee team",
                Version = "1.0",
                Tags = new[] { CommonTags.ProjectManagement, CommonTags.TeamCommunication, CommonTags.Agile, CommonTags.Scrum })]
    public class RetrospectiveCorkboardWidget : Client.Framework.ViewModel.Widget
    {
        private CorkboardController controller;
        private const int REFRESH_INTERVAL_MS = 60 * 60 * 1000; 

        public RetrospectiveCorkboardWidget()
        {
            Title = "Retrospective Corkboard";

			var viewModel = GetInstance<CorkboardViewModel>();
        	var settingsViewModel = GetInstance<CorkboardSettingsViewModel>();

        	controller = NewController<CorkboardController>();
        	controller.Start(REFRESH_INTERVAL_MS);

			View = new CorkboardView {DataContext = viewModel};
            SettingsView = new CorkboardSettingsView {DataContext = settingsViewModel};

            PropertyChanged += CorkBoardSlide_PropertyChanged;
            viewModel.PropertyChanged += ViewModelPropertyChanged;

            settingsViewModel.Save.ExecuteDelegate += () => SaveSettings.Execute();
            SaveSettings.BeforeExecute += (s, e) => controller.BeforeSaving();

            ConfigurationChanged += (o, e) => controller.ConfigurationChanged(Configuration);
        }

        private void CorkBoardSlide_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("IsInSettingsMode"))
            {
                if (IsInSettingsMode)
                {
                    controller.Stop();
                }
                else
                {
                    controller.FlippedBackFromSettingsView(REFRESH_INTERVAL_MS);
                }
            }
        }

        private void ViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var viewModel = sender as CorkboardViewModel;
            var isDoneSaving = (viewModel != null && e.PropertyName.Equals("IsSaving") && !viewModel.IsSaving);

            if (isDoneSaving && IsInSettingsMode)
            {
                OnSettings();
            }
        }

		public override void Configure(DependencyConfigSemantics config)
		{
			config.Bind<CorkboardSettingsViewModel>().To<CorkboardSettingsViewModel>().InSingletonScope();
			config.Bind<CorkboardViewModel>().To<CorkboardViewModel>().InSingletonScope();
		}

        protected override Configuration NewConfiguration()
        {
            var config = new Configuration("RetrospectiveCorkboard") { IsConfigured = false };
            config.NewSetting("IsDefault", "Yes");

            return config;
        }
    }
}