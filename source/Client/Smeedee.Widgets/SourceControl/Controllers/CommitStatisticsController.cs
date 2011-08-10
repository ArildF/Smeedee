﻿#region File header

// <copyright>
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
// /copyright> 
// 
// <contactinfo>
// The project webpage is located at http://smeedee.org/
// which contains all the neccessary information.
// </contactinfo>

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Smeedee.Client.Framework.Services;
using Smeedee.Client.Framework.ViewModel;
using Smeedee.DomainModel.Config;
using Smeedee.DomainModel.Framework;
using Smeedee.DomainModel.Framework.Logging;
using Smeedee.DomainModel.SourceControl;
using Smeedee.Framework;
using Smeedee.Widgets.SourceControl.ViewModels;
using TinyMVVM.Framework.Services;

namespace Smeedee.Widgets.SourceControl.Controllers
{
    public class CommitStatisticsController : ChangesetControllerBase<CommitStatisticsForDate>
    {
        private readonly CommitStatisticsSettingsViewModel settingsViewModel;
        private DateTime projectStart;
        private DateTime dateToModelFrom;
        private DateTime modelTimeStart;

        private static readonly CultureInfo dateFormatingRules = new CultureInfo("en-US");
        public static readonly Configuration defaultConfig = CreateConfig(DateTime.Now, 14, false, true);

        private const string Commit_Statistics_Configuration_Name = "Commit Statistics";
        private const string Date_Entry_Name = "SinceDate";
        private const string Timespan_Entry_Name = "CommitTimespanDays";
        private const string Using_Date_Entry_Name = "IsUsingDate";
        private const string Using_Timespan_Entry_Name = "IsUsingTimespan";
        private readonly IEnumerable<string> settingsEntryList = new List<string>() {
                                                    Date_Entry_Name, 
                                                    Timespan_Entry_Name,
                                                    Using_Date_Entry_Name, 
                                                    Using_Timespan_Entry_Name       };

        public CommitStatisticsController(
            BindableViewModel<CommitStatisticsForDate> viewModel,
            CommitStatisticsSettingsViewModel settingsViewModel,
            IAsyncRepository<Changeset> changesetRepo,
            ITimer timer,
            IUIInvoker uiInvoke,
            IPersistDomainModelsAsync<Configuration> configPersister,
            ILog logger,
            IProgressbar loadingNotifier,
            IWidget widget)
            : base(viewModel, changesetRepo, timer, uiInvoke, logger, loadingNotifier, widget, configPersister)
        {
            Guard.Requires<ArgumentException>(configPersister != null, "configPersister");
            Guard.Requires<ArgumentException>(settingsViewModel != null, "settingsViewModel");

            this.settingsViewModel = settingsViewModel;

            settingsViewModel.SaveSettings.ExecuteDelegate += SaveSettings;
            settingsViewModel.ReloadSettings.ExecuteDelegate += ReloadSettings;            

            settingsViewModel.PropertyChanged += ViewModelPropertyChanged;

            Start();

            LoadDummyDataIntoViewModel();
            CopyConfigurationToViewModel(Widget.Configuration);
            LoadNewData();
        }

        public static Configuration CreateDefaultConfig()
        {
            return CreateConfig(DateTime.Today, 14, false, true);
        } 

        private void LoadDummyDataIntoViewModel()
        {

            ViewModel.Data.Add(new CommitStatisticsForDate()
            {
                Date = DateTime.Today,
                NumberOfCommits = 0
            });
            ViewModel.Data.Add(new CommitStatisticsForDate()
            {
                Date = DateTime.Today.AddDays(1),
                NumberOfCommits = 0
            });
        }

        private static Configuration CreateConfig(DateTime sinceDate, int timeSpan, bool isUsingDate, bool isUsingTimespan)
        {
            var newConfig = new Configuration(Commit_Statistics_Configuration_Name);

            newConfig.NewSetting(Timespan_Entry_Name, timeSpan.ToString());
            newConfig.NewSetting(Date_Entry_Name, sinceDate.ToString(dateFormatingRules));
            newConfig.NewSetting(Using_Timespan_Entry_Name, isUsingTimespan.ToString());
            newConfig.NewSetting(Using_Date_Entry_Name, isUsingDate.ToString());
            return newConfig;
        }
       
        private void SaveSettings()
        {
            SaveConfigToRepository(); 
        }

        private void SaveConfigToRepository()
        {
            var newSinceDate = settingsViewModel.SinceDate;
            var newTimespan = settingsViewModel.CommitTimespanDays;
            var newUsingDate = settingsViewModel.IsUsingDate;
            var newUsingTimespan = settingsViewModel.IsUsingTimespan;
            try
            {
                var config = Widget.Configuration;
                config.ChangeSetting(Timespan_Entry_Name, newTimespan.ToString());
                config.ChangeSetting(Date_Entry_Name, newSinceDate.ToString(dateFormatingRules));
                config.ChangeSetting(Using_Timespan_Entry_Name, newUsingTimespan.ToString());
                config.ChangeSetting(Using_Date_Entry_Name, newUsingDate.ToString());
                config.IsConfigured = true;

                SaveConfiguration();
            }
            catch (Exception exception)
            {
                LogErrorMsg(exception);
            }
        }

        protected override void OnConfigurationChanged(Configuration configuration)
        {
            configIsChanged = true;
            CopyConfigurationToViewModel(configuration);
            LoadNewData();
        }

        private void CopyConfigurationToViewModel(Configuration configuration)
        {
            uiInvoker.Invoke(() =>
            {
                foreach (var entry in settingsEntryList)
                {
                    TryToLoadSpecificSetting(configuration, entry);
                }
            });
        }

        private void TryToLoadSpecificSetting(Configuration config, string entry)
        {
            uiInvoker.Invoke(() =>
            {
                try
                {
                    LoadSpecificSetting(config.GetSetting(entry));
                }
                catch (Exception e)
                {
                    LogErrorMsg(e);
                }
            });
        }

        private void LoadSpecificSetting(SettingsEntry setting)
        {
            switch (setting.Name)
            {
                case Date_Entry_Name:
                    settingsViewModel.SinceDate = DateTime.Parse(setting.Value.Trim(), dateFormatingRules).Date;
                    break;
                case Timespan_Entry_Name:
                    settingsViewModel.CommitTimespanDays = Int32.Parse(setting.Value.Trim());
                    break;
                case Using_Date_Entry_Name:
                    settingsViewModel.IsUsingDate = Boolean.Parse(setting.Value.Trim());
                    break;
                case Using_Timespan_Entry_Name:
                    settingsViewModel.IsUsingTimespan = Boolean.Parse(setting.Value.Trim());
                    break;
            }
        }

        private void LoadNewData()
        {
            if (configIsChanged)
            {
                LoadData(new AllChangesetsSpecification());
            }
            else
            {
                LoadData(new ChangesetsAfterRevisionSpecification(ViewModel.CurrentRevision));
            }
        }

        protected override void LoadDataIntoViewModel(IEnumerable<Changeset> qChangesets)
        {
            if (qChangesets == null || qChangesets.Count() == 0) return;

            UpdateRevision(qChangesets);
            if (!ViewModel.RevisionIsChanged && !configIsChanged) return;

            modelTimeStart = settingsViewModel.ActualDateUsed.Date;
            projectStart = qChangesets.Min(c => c.Time.Date).Date;
            dateToModelFrom = projectStart > modelTimeStart ? projectStart.Date : modelTimeStart.Date;

            var commitStatisticsForDates = GetCommitStatisticsForDates(qChangesets);

            if (configIsChanged)
            {
                ViewModel.Data.Clear();
                configIsChanged = false;
            }

            InsertPointsToImproveTheGraph(commitStatisticsForDates);

            foreach (var commit in commitStatisticsForDates)
            {
                AddDaysOfNoCommitsInBetween(commit);

                var existingPointOnDate = ViewModel.Data.Where(c => c.Date.Equals(commit.Date)).SingleOrDefault();

                if (existingPointOnDate != null)
                {
                    existingPointOnDate.NumberOfCommits += commit.NumberOfCommits;
                }
                else
                {
                    ViewModel.Data.Add(commit);
                }

            }

            InsertPointTodayIfNeeded(commitStatisticsForDates);

            if (ViewModel.Data.Count() == 0)
            {
                LoadDummyDataIntoViewModel();
            }
        }

        private IEnumerable<CommitStatisticsForDate> GetCommitStatisticsForDates(IEnumerable<Changeset> changesets)
        {
            return (from changeset in changesets
                    where changeset.Time.Date >= modelTimeStart
                    group changeset by changeset.Time.Date
                        into g
                        select new CommitStatisticsForDate()
                        {
                            Date = g.Key,
                            NumberOfCommits = g.Count(),
                        }).OrderBy(r => r.Date);
        }

        private void InsertPointsToImproveTheGraph(IEnumerable<CommitStatisticsForDate> commitStatisticsForDates)
        {
            if (ThereAreNoCommitDataOnDate(dateToModelFrom, commitStatisticsForDates))
            {
                ViewModel.Data.Add(new CommitStatisticsForDate() { Date = dateToModelFrom, NumberOfCommits = 0 });
            }

            //Modelling one day is not pretty so in thoose cases this inserts a dummypoint on the next day
            if (modelTimeStart.Date.Equals(DateTime.Today.Date) && ViewModel.Data.Count < 2)
            {
                ViewModel.Data.Add(new CommitStatisticsForDate() { Date = dateToModelFrom.AddDays(1), NumberOfCommits = 0 });
            }
        }

        private bool ThereAreNoCommitDataOnDate(DateTime date, IEnumerable<CommitStatisticsForDate> commitStatisticsForDates)
        {
            if (ViewModel.Data == null || commitStatisticsForDates == null) { return false; }

            var noNewDataOnDate = commitStatisticsForDates.Where(c => c.Date.Equals(date)).Count() == 0;
            var noOldDataOnDate = ViewModel.Data.Where(c => c.Date.Equals(date)).Count() == 0;

            return noNewDataOnDate && noOldDataOnDate;
        }

        private void AddDaysOfNoCommitsInBetween(CommitStatisticsForDate commit)
        {
            int diff = GetTotalNumberOfDays(ViewModel.Data, commit);
            while (diff > 1)
            {
                diff--;
                ViewModel.Data.Add(new CommitStatisticsForDate() { Date = ViewModel.Data.Max(c => c.Date).AddDays(1), NumberOfCommits = 0 });
            }
        }

        private static int GetTotalNumberOfDays(IEnumerable<CommitStatisticsForDate> timeData, CommitStatisticsForDate commit)
        {
            if (timeData.Count() <= 0) return 0;
            var lastDay = timeData.Max(c => c.Date);
            var thisDay = commit.Date;
            TimeSpan difference = thisDay.Subtract(lastDay);
            return difference.Days;
        }

        private void InsertPointTodayIfNeeded(IEnumerable<CommitStatisticsForDate> commitStatisticsForDates)
        {
            if (ThereAreNoCommitDataOnDate(DateTime.Today, commitStatisticsForDates))
            {
                var commitsToday = new CommitStatisticsForDate() { Date = DateTime.Today, NumberOfCommits = 0 };

                AddDaysOfNoCommitsInBetween(commitsToday);
                ViewModel.Data.Add(commitsToday);
            }
        }

        private void ReloadSettings()
        {
            CopyConfigurationToViewModel(Widget.Configuration);
            configIsChanged = true;
            LoadNewData();
        }

        private void ViewModelPropertyChanged(object sender, PropertyChangedEventArgs propertyEvent)
        {
            configIsChanged |= settingsEntryList.Contains(propertyEvent.PropertyName);
        }

        protected override void OnNotifiedToRefresh(object sender, EventArgs e)
        {
            LoadNewData();
        }
    }
}