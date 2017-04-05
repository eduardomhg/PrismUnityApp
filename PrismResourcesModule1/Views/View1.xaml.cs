using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PrismResourcesShared;

namespace PrismResourcesModule1.Views
{
    /// <summary>
    /// Interaction logic for View1.xaml
    /// </summary>
    public partial class View1 : BaseView
    {
        public View1()
        {
            InitializeComponent();

            Debug.WriteLine($"Resources for {this.GetType().Name}: {this.Resources.Count}");

            if (this.TryFindResource("TestResourceKey") != null)
            {
                Debug.WriteLine($"TestResourceKey found");
            }
            else
            {
                Debug.WriteLine($"TestResourceKey NOT found");
            }            

            //Debug.WriteLine($"Parent of {this.GetType().Name}: {this.Parent.GetType().Name}");

            //Debug.WriteLine($"Resources for {this.Parent.GetType().Name}: {(this.Parent as FrameworkElement)?.Resources.Count}");
        }
    }
}
