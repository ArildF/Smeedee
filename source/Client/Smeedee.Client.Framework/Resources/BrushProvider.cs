﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smeedee.Client.Framework.Resources
{
    public class BrushProvider
    {
        public const string DEFAULT_BRUSH = "GreyGradientBrush";
       
        public List<BrushProviderItem> BrushList
        {
            get
            {
                var list = new List<BrushProviderItem>();
                foreach (var key in GetBrushKeys())
                {
                    list.Add(new BrushProviderItem(key, GetBrushName(key)));
                }
                return list;
            }
        }

        private static Dictionary<string, string> brushes = new Dictionary<string, string>
        {   
            {"dark grey", "DarkGreyGradientBrush"},
            {"grey", "GreyGradientBrush"},
            {"light grey", "LightGreyGradientBrush"},

            {"light brown", "LightBrownGradientBrush"},
            {"brown", "BrownGradientBrush"},
            {"dark brown", "DarkBrownGradientBrush"},

            {"red", "RedGradientBrush"},
            {"orange", "OrangeGradientBrush"},
            {"yellow", "YellowGradientBrush"},

            {"light green", "LightGreenGradientBrush"},
            {"green", "MediumGreenGradientBrush"},
            {"dark green", "GreenGradientBrush"},

            {"light blue", "LightBlueGradientBrush"},
            {"blue", "BlueGradientBrush"},
            {"dark blue", "DarkBlueGradientBrush"},
          
            {"pink", "PinkGradientBrush"},
            {"purple", "PurpleGradientBrush"},
            {"dark purple", "DarkPurpleGradientBrush"}
          
        };

        private static List<string> brightBrushes = new List<string>
                                                        {
                                                            "LightGreyGradientBrush",
                                                            "LightBrownGradientBrush",
                                                            "OrangeGradientBrush",
                                                            "YellowGradientBrush",
                                                            "LightGreenGradientBrush",
                                                            "LightBlueGradientBrush",
                                                            "PinkGradientBrush"
                                                        };

        public static string GetBrushName(string color)
        {
            return color != null && brushes.ContainsKey(color) ? brushes[color] : DEFAULT_BRUSH;
        }

        public static string[] GetBrushKeys()
        {
            return brushes.Keys.ToArray();
        }

        public static bool IsBrightBrush(string brushName)
        {
            return brightBrushes.Contains(brushName);
        }
    }

    public class BrushProviderItem
    {
        public BrushProviderItem(string name, string brush)
        {
            BrushKey = name;
            BrushName = brush;
        }
        public string BrushKey { get; set; }
        public string BrushName { get; set; }
    }

}