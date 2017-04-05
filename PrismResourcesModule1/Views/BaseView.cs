using System;
using System.Windows;
using System.Windows.Controls;
using PrismResourcesShared;

namespace PrismResourcesModule1.Views
{
    public class BaseView : UserControl
    {
        public BaseView()
        {
            //this.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("pack://application:,,,/PrismResourcesModule1;component/Themes/Styles.xaml", UriKind.Absolute) });
            this.Resources.MergedDictionaries.Add(new SharedResourceDictionary { SharedSource = "PrismResourcesModule1;component/Themes/Styles.xaml" });
        }
    }
}
