using System;
using System.Collections.Generic;

namespace MVCTest.Models
    {
    public class HomePageViewModel
        {
        public List<departamente> departamente { get; set; }
        public List<proiecte> proiecte { get; set; }

        public HomePageViewModel()
            {
            departamente = new List<departamente>();
            proiecte = new List<proiecte>();
            }
        }
    }