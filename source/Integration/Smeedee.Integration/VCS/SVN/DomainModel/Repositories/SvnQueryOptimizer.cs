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
// The project webpage is located at http://smeedee.org/
// which contains all the neccessary information.
// </contactinfo>
// 
// <author>Your Name</author>
// <email>your@email.com</email>
// <date>2009-MM-DD</date>

#endregion

using Smeedee.DomainModel.SourceControl;
using SharpSvn;
using Smeedee.DomainModel.Framework;


namespace Smeedee.Integration.VCS.SVN.DomainModel.Repositories
{
    public class SvnQueryOptimizer
    {
        SpecificationHandler handler;

        public SvnQueryOptimizer()
        {
            handler = new RevisionHandler();
        }

        public SvnLogArgs Optimize(Specification<Changeset> specification)
        {
            var args = new SvnLogArgs();
            handler.Request(new SpecificationRequest(specification, args));
            return args;
        }
    }
}