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
// </copyright> 
// 
// <contactinfo>
// The project webpage is located at http://agileprojectdashboard.org/
// which contains all the neccessary information.
// </contactinfo>
// 
// <author>Your Name</author>
// <email>your@email.com</email>
// <date>2009-MM-DD</date>

#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Smeedee.DomainModel.Framework.Logging;
using Smeedee.Tasks.Framework;

namespace Smeedee.Scheduler
{
    public class DirectoryTaskCatalogLoader : IGetTaskCatalog
    {
        private readonly ILog logger;
        private DirectoryInfo taskDirectory;

        public DirectoryTaskCatalogLoader(string directoryPath, ILog logger)
        {
            this.logger = logger;
            if( Directory.Exists(directoryPath) == false )
                throw new ArgumentException("The directory " + directoryPath + " does not exist");
            else
                taskDirectory = new DirectoryInfo(directoryPath);
        }


        public IEnumerable<Type> GetCatalog()
        {
            List<Type> tasksInDirectory = new List<Type>();

            LogInfoFormat("Starting discovery of tasks");

            LogInfoFormat("Getting all DLLs (*.dll) in folder '{0}'", taskDirectory.FullName);
            FileInfo[] dllFilesInFolder = taskDirectory.GetFiles("*.dll", SearchOption.AllDirectories);

            LogInfoFormat("Found {0} dlls in folder", dllFilesInFolder.Length);

            foreach (var file in dllFilesInFolder)
            {
                Assembly assembly = LoadAssemblyFromFile(file);
                if( assembly != null )
                {
                    List<Type> tasksInAssembly = GetTasksInAssembly(assembly);
                    tasksInDirectory.AddRange(tasksInAssembly);
                }
            }

            LogInfoFormat("Ended discovery of tasks. (Found {0} of them)", tasksInDirectory.Count);
            return tasksInDirectory;
        }

        private Assembly LoadAssemblyFromFile(FileInfo file)
        {
            Assembly assembly = null;
            try
            {
                assembly = Assembly.LoadFile(file.FullName);
                LogInfoFormat("Loaded the assembly '{0}'", file.Name);
            }
            catch (Exception ex)
            {
                LogWarningFormat("Could not load the file '{0}'. Message: {1}", file.FullName, ex.Message);
            }
            return assembly;
        }

        private List<Type> GetTasksInAssembly(Assembly assembly)
        {
            List<Type> tasksInAssembly =  new List<Type>();
            Type[] typesInAssembly = assembly.GetTypes();
            LogInfoFormat("Found {0} types in '{1}'", typesInAssembly.Length, assembly.FullName);
            foreach (var type in typesInAssembly)
            {
                if( type.IsSubclassOf(typeof(TaskBase)))
                {
                    tasksInAssembly.Add(type);
                    LogInfoFormat("Found task '{0}'", type.Name);
                }
            }

            return tasksInAssembly;
        }


        private void LogInfoFormat(string message, params object[] parameters)
        {
            logger.WriteEntry(new InfoLogEntry("DirectoryTaskCatalogLoader", string.Format(message, parameters)));
        }

        private void LogWarningFormat(string message, params object[] parameters)
        {
            logger.WriteEntry(new WarningLogEntry("DirectoryTaskCatalogLoader", string.Format(message, parameters)));
        }
    }
}
