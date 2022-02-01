using Raminagrobi.WPF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobi.WPF.ViewModels
{
    public class MainWindowsViewModel : BaseViewModel
    {
        private BaseViewModel _content;
        public BaseViewModel Content
        {
            get => _content;
            set { _content = value; }
        }

        public Command MySuperButtonCommand { get; private set; }

        public MainWindowsViewModel()
        {
            Content = new CartViewModel();
            MySuperButtonCommand = new Command(OnMySuperButtonCommand);
        }

        private void OnMySuperButtonCommand()
        {
            //Content = new CartViewModel();
        }
    }
}