using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using BusId.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace BusId.Model
{

    [Serializable()]
    public class Trasa 
    {

        private string busid;

        private string nazwa;

        private string kierowca;
        private string link;

        private List<Przystanek> _Przystanki = new List<Przystanek>();


       
        [System.Xml.Serialization.XmlElement()]       
        public string BusId
        {
            get
            {
                return busid;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || String.IsNullOrEmpty(value))
                {
                    throw new Exception("Wymagane pole");
                }
                busid = value;
                RaisePropertyChanged("BusId");
            }
        }

        [System.Xml.Serialization.XmlElement()]
        public string Nazwa
        {
            get
            {
                return nazwa;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || String.IsNullOrEmpty(value))
                {
                    throw new Exception("Wymagane pole");
                }
                if (value.Length < 3)
                {
                    throw new Exception("Minimum 3 znaki!");
                }
                nazwa = value;
                RaisePropertyChanged("Nazwa");              
            }
        }


      
        [System.Xml.Serialization.XmlElement()]
        public string Kierowca
        {
            get { return kierowca; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || String.IsNullOrEmpty(value))
                {
                    throw new Exception("Wymagane pole");
                }
                if (value.Length < 3)
                {
                    throw new Exception("Minimum 3 znaki!");
                }
                kierowca = value;
                RaisePropertyChanged("Kierowca");
            }
        }
        [System.Xml.Serialization.XmlElement()]
        public string Link
        {
            get { return link; }
            set
            {
              
                link = value;
                RaisePropertyChanged("link");
            }
        }


        [XmlArrayItem()]
        public List<Przystanek> Przystanki
        {
            get
            {
                return _Przystanki;
            }
            set
            {
                _Przystanki = value;
                RaisePropertyChanged("Przystanki");
            }
        }

        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
        });
        }



    #region INotifyPropertyChanged Members  

    public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        #endregion

        public static implicit operator Array(Trasa v)
        {         
            throw new NotImplementedException();
        }

        



    }
}

