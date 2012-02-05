﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Smeedee.DomainModel.Config;
using Smeedee.DomainModel.Framework;
using Smeedee.DomainModel.SourceControl;
using Smeedee.DomainModel.TaskInstanceConfiguration;
using Smeedee.Framework;
using Smeedee.Integration.VCS.TFSVC.DomainModel.Repositories;
using Smeedee.Tasks.Framework.TaskAttributes;

namespace Smeedee.Tasks.SourceControl
{
    [Task("TFS Changeset Harvester",
       Author = "Smeedee Team",
       Description = "Retrieves information from a Team Foundation version control repository. Used to populate Smeedee's database with information about the latest commits and other commit statistics.",
       Version = 1,
       Webpage = "http://smeedee.org")]
    [TaskSetting(1, USERNAME_SETTING_NAME, typeof(string), "guest", "The username or domain/username of the Team Foundation server that this task may log in with.")]
    [TaskSetting(2, PASSWORD_SETTING_NAME, typeof(string), "")]
    [TaskSetting(3, SOURCECONTROL_SERVER_NAME, typeof(string), "Main Sourcecontrol Server")]
    [TaskSetting(4, URL_SETTING_NAME, typeof(string), "", "Include protocols such as http://\nand port numbers such as :8080")]
    [TaskSetting(5, PROJECT_SETTING_NAME, typeof(string), "")]
    public class TFSChangesetHarvesterTask : ChangesetHarvesterBase
    {
        public const string PROJECT_SETTING_NAME = "Project";
        public const string REQUIRED_PROJECT_NAME_PREFIX = "$\\";
        public override string Name { get { return "TFS Changeset Harvester"; } }

        public string ProjectSettingValue { get; set; }

        public TFSChangesetHarvesterTask(IRepository<Changeset> changesetDbRepository, IPersistDomainModels<Changeset> databasePersister, TaskConfiguration config) 
            : base(changesetDbRepository, databasePersister, config)
        {
            Guard.Requires<ArgumentNullException>(changesetDbRepository != null);
            Guard.Requires<ArgumentNullException>(databasePersister != null);
            Guard.Requires<ArgumentNullException>(config != null);
            Guard.Requires<TaskConfigurationException>(config.Entries.Count() >= 4);            
            
            Interval = TimeSpan.FromMilliseconds(config.DispatchInterval);
        }

        public override void Execute()
        {
            SaveUnsavedChangesets(GetChangesetRepository());
        }

        private TFSChangesetRepository GetChangesetRepository()
        {
            string username = (string)config.ReadEntryValue(USERNAME_SETTING_NAME);
            string domain = username.Contains('\\') ? username.Substring(0, username.IndexOf('\\')) : null;
            username = username.Contains('\\') ? username.Substring(username.IndexOf('\\') + 1) : username;
            string password = (string)config.ReadEntryValue(PASSWORD_SETTING_NAME);

            var cred = string.IsNullOrEmpty(domain) ? new NetworkCredential(username, password) : new NetworkCredential(username, password, domain);

            return new TFSChangesetRepository(
                   (string)config.ReadEntryValue(URL_SETTING_NAME),
                   SetProjectSettingValueWithPrefix(),
                   cred);
        }

        private string SetProjectSettingValueWithPrefix()
        {
            var configValue = (string)config.ReadEntryValue(PROJECT_SETTING_NAME);
            if (configValue.Contains(REQUIRED_PROJECT_NAME_PREFIX))
            {
                return configValue;
            }
            else
            {
                return REQUIRED_PROJECT_NAME_PREFIX + configValue;
            }
        }
    }
}
