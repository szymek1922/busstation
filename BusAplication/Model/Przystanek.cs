using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusId.Model
{
    [Serializable()]
    public class Przystanek
    {
        private string nazwa_przystanku;

        private int czas;


        [System.Xml.Serialization.XmlElement()]
        public string NazwaPrzystanku
        {
            get
            {
                return nazwa_przystanku;
            }
            set
            {
                nazwa_przystanku = value;
                RaisePropertyChanged("Przystanek");
            }
        }
        [System.Xml.Serialization.XmlElement()]
        public int CzasPrzejazdu
        {
            get
            {
                return czas;
            }
            set
            {
                czas = value;
                RaisePropertyChanged("CzasPrzejazdu");
            }
        }

      

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }


    }

}
