using sb_task_8.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sb_task_8.UserControls
{
    /// <summary>
    /// Interaction logic for Resultcontrol.xaml
    /// </summary>
    public partial class ResultControl : UserControl
    {
        public ResultControl()
        {
            InitializeComponent();
        }

        private CommonBase _viewModel = null;

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel = (CommonBase)this.DataContext;
        }
    }
}
