using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Liquinator.ViewModels {
    public abstract class ViewModelBase : INotifyPropertyChanged {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string name = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        #endregion

    }
}
