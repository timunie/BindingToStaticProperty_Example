using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticPropertyExample.model
{
    public class VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
        

        void RaisePropertyChanged (string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public static void RaiseStaticPropertyChanged(string PropertyName)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(PropertyName));
        }

        private int _Age;
        public int Age
        {
            get { return _Age; }
            set { _Age = value; RaisePropertyChanged("Age"); ValidateAge(); }
        }


        static bool _IsAgeValid;
        public static bool IsAgeValid => _IsAgeValid;

        void ValidateAge()
        {
            _IsAgeValid = Age > 0 && Age < 120 ? true : false;
            RaiseStaticPropertyChanged(nameof(IsAgeValid));
        }

    }
}
