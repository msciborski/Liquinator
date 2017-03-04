using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Liquinator.MVVM;

namespace Liquinator.ViewModels {
    public class MainWindowViewModel : ViewModelBase {
        public MainWindowViewModel() {
            SwitchViewModel = "FlavourView";
        }

        private string _switchViewModel;

        public string SwitchViewModel {
            get { return _switchViewModel; }
            set {
                _switchViewModel = value;
                NotifyPropertyChanged();
            }
        }
        public ICommand ChangeViewCommand => new RelayCommand(ChangeView);

        /// <summary>
        /// Take param from LeftButtonUp attached property and change SwitchViewModel(switching view)
        /// </summary>
        /// <param name="name"></param>
        private void ChangeView(object name) {

            switch (name.ToString()) {
                case "FlavourView":
                    SwitchViewModel = "FlavourView";
                    Console.WriteLine(SwitchViewModel);
                    break;
                case "RecipeView":
                    SwitchViewModel = "RecipeView";
                    Console.WriteLine(SwitchViewModel);
                    break;
                default:
                    throw new Exception("NIE MA TAKIEGO WIDOKU");
            }
        }



    }
}
