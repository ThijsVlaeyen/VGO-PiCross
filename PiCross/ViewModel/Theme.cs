using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ViewModel
{
    public class Theme
    {
        public Theme(MainViewModel main)
        {
            this.Vm = main;
        }

        private MainViewModel Vm { get; }
        public void Vaporwave()
        {
            SetSkin("Vaporwave");
        }
        
        public void Default()
        {
            SetSkin("Default");
        }

        public void JJBA()
        {
            SetSkin("JJBA");
        }

        private void SetSkin(string name)
        {
            var resourceDictionary = new ResourceDictionary();
            var uri = $"Skins/{name}.xaml";
            resourceDictionary.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(uri, UriKind.Relative)));
            resourceDictionary.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri($"Skins/shared.xaml", UriKind.Relative)));
            Application.Current.Resources = resourceDictionary;
        }
    }
}
