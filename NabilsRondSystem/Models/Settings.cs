using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NabilsRondSystem.Models
{

    [Table("Settings")]
    public class Settings : INotifyPropertyChanged
    {
        private string _Key;
        private string _Value;


        [PrimaryKey]
        public string Key
        {
            get
            {
                return _Key;
            }

            set
            {
                this._Key = value;
                OnPropertyChanged(nameof(Key));
            }
        }

        public string Value
        {
            get
            {
                return _Value;
            }

            set
            {
                this._Value = value;
                OnPropertyChanged(nameof(Value));
            }
        }



        public void OnPropertyChanged(string propertyName)

        {

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
