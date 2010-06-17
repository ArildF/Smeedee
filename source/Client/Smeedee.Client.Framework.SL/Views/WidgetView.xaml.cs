﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Smeedee.Client.Framework.SL.Views
{
    public partial class WidgetView : UserControl
    {
        public WidgetView(UIElement control)
        {
            InitializeComponent();

            contentControl.Content = control;
        }
    }
}
