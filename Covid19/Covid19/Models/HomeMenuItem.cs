﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Home,
        CurrentCovid19Status
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
