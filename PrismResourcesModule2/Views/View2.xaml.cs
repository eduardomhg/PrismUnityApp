using System.Diagnostics;
using System.Windows.Controls;

namespace PrismResourcesModule2.Views
{
    /// <summary>
    /// Interaction logic for View1.xaml
    /// </summary>
    public partial class View2 : UserControl
    {
        public View2()
        {
            InitializeComponent();

            Debug.WriteLine($"{nameof(View2)} created");
        }
    }
}
