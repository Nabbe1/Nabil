using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;

namespace NabilsRondSystem.Models
{

    [Table("Barcode")]
    public class Barcode : INotifyPropertyChanged
    {
        private string _User;
        private string _Plats;
        private string _Time;
        private string _Date;
        private string _Felrapport;

        [PrimaryKey, AutoIncrement]
        public int ID

        {

            get;

            set;

        }


        public string Plats
        {
            get
            {
                return _Plats;
            }


            set
            {
                this._Plats = value;
                OnPropertyChanged(nameof(Plats));
            }
        }

        public string Time
        {
            get
            {
                return _Time;
            }

            set
            {
                this._Time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

        public string Date
        {
            get
            {
                return _Date;
            }

            set
            {
                this._Date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public string Felrapport
        {
            get
            {
                return _Felrapport;
            }

            set
            {
                this._Felrapport = value;
                OnPropertyChanged(nameof(Felrapport));
            }
        }

        public string User
        {
            get
            {
                return _User;
            }

            set
            {
                this._User = value;
                OnPropertyChanged(nameof(User));
            }
        }





        public void OnPropertyChanged(string propertyName)

        {

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
