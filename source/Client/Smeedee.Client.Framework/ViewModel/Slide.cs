﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smeedee.Client.Framework.ViewModel
{
    public partial class Slide
    {
        public void OnSettings()
        {
            IsInSettingsMode = !IsInSettingsMode;
        }
    }
}
