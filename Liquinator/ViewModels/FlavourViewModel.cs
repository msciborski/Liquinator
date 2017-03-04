using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Liquinator.Models;
using Liquinator.MVVM;

namespace Liquinator.ViewModels {
    public class FlavourViewModel : ViewModelBase {
        #region Fields

        private ObservableCollection<Flavour> _flavours;
        private Flavour _selectedFlavour;
        private bool _isEditButtonEnable;
        private bool _isDialogHostOpen;
        private string _name;
        private string _company;
        private string _shop;
        private string _amount; //String, becouse i want to try parse it and trigger validation error

        #endregion

        #region Properties

        public string Name {
            get { return _name; }
            set {
                if (_name == value) return;
                _name = value;
                NotifyPropertyChanged();
            }
        }

        public string Company {
            get {
                return _company;
            }
            set {
                if (_company == value) return;
                _company = value;
                NotifyPropertyChanged();
            }
        }

        public string Shop {
            get { return _shop; }
            set {
                if (_shop == value) return;
                _shop = value;
                NotifyPropertyChanged();
            }
        }

        public string Amount {
            get { return _amount; }
            set {
                if (_amount == value) return;
                _amount = value;
                NotifyPropertyChanged();
            }
        }

        public Flavour SelectedFlavour {
            get { return _selectedFlavour; }
            set {
                if (_selectedFlavour == value) return;
                IsEditButtonEnable = true;
                _selectedFlavour = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsEditButtonEnable {
            get { return _isEditButtonEnable; }
            set {
                if (_isEditButtonEnable == value) return;
                _isEditButtonEnable = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsDialogHostOpen {
            get { return _isDialogHostOpen; }
            set {
                if (_isDialogHostOpen == value) return;
                _isDialogHostOpen = value;
                NotifyPropertyChanged();
            }

        }

        public ObservableCollection<Flavour> Flavours{
            get { return _flavours; }
            set{
                _flavours = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Commands

        public ICommand AddFlavourCommand => new RelayCommand(AddFlavour);
        public ICommand OpenDialogCommand => new RelayCommand(OpenDialog);
        public ICommand CloseDialogCommand => new RelayCommand(CloseDialog);

        #endregion


        #region Constructor

        public FlavourViewModel() {
            Flavours = new ObservableCollection<Flavour>();
            IsEditButtonEnable = false;
            SelectedFlavour = null;
            Name = null;
            Company = null;
            Shop = null;
            Amount = null;
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject())) {
                RefreshDataGrid();
            }

        }

        #endregion

        #region Methods



        public void AddFlavour() {

            double? amount = Double.Parse(Amount);
            Flavour flavourToAdd = new Flavour(Name, Company, Shop, amount);
            AddToDataBaseFlavour(flavourToAdd);
            RefreshDataGrid();
            ResetValues();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flavour"></param>
        private void AddToDataBaseFlavour(Flavour flavour) {
        }
        /// <summary>
        /// Fetch whole data from Flavour table
        /// </summary>
        public void RefreshDataGrid() {
        }

        /// <summary>
        /// Opening Edit Dialog. Set IsDialongOpen to True
        /// </summary>
        public void OpenDialog() {
            IsDialogHostOpen = true;
        }
        /// <summary>
        /// Closing Edit Dialog. Set IsDalogOpen to false. Create new query which will update SelectedFlavour
        /// </summary>
        public void CloseDialog() {
            IsDialogHostOpen = false;
        }

        /// <summary>
        /// Reset state of TextBoxes
        /// </summary>
        private void ResetValues() {
            Name = null;
            Company = null;
            Shop = null;
            Amount = null;
        }

        #endregion

    }
}
