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


namespace Smeedee.DomainModel.Framework
{
    [Obsolete("This interface is obsolete in favor of the IPersistDomainModelsAsync. Please use the new Async interface")]
    public interface IPersistDomainModels<TDomainModel>
    {
        void Save(TDomainModel domainModel);
        void Save(IEnumerable<TDomainModel> domainModels);
    }

    public interface IPersistDomainModelsAsync<TDomainModel> : IPersistDomainModels<TDomainModel>
    {
        event EventHandler<SaveCompletedEventArgs> SaveCompleted;
    }

    public class SaveCompletedEventArgs : AsyncCompletedEventArgs
    {
        public SaveCompletedEventArgs()
            : this(null)
        {
        }

        public SaveCompletedEventArgs(Exception error) 
            : base(error, false, null)
        {
        }
    }
}