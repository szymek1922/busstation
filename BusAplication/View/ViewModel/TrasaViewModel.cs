using BusAplication.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BusAplication.ViewModel
{
    class TrasaViewModel
    {
        private IList<Trasa> _TrasaList;

        public TrasaViewModel()
        {
            _TrasaList = new List<Trasa>
            {
               new Trasa{ id_busa=1, nazwa="Solar", kierowca="Lotek", _Przystanek= new List<Przystanek>{ new Przystanek {nazwa_przystanku = "Płaska", czas = 240 }, new Przystanek { nazwa_przystanku = "Prosta", czas = 280 }, new Przystanek { nazwa_przystanku = "Tatrzanska", czas = 280 }, new Przystanek {nazwa_przystanku="Krzywa", czas=470 } } } ,
               new Trasa{ id_busa=2, nazwa="Polaris", kierowca="Paczes", _Przystanek= new List<Przystanek>{ new Przystanek {nazwa_przystanku = "Policyjna", czas = 250 }, new Przystanek {  nazwa_przystanku = "Strazacka",czas = 200 }, new Przystanek { nazwa_przystanku = "Karetkowa", czas = 350 } } },
               new Trasa{ id_busa=3, nazwa="Polaris", kierowca="Rucinski", _Przystanek= new List<Przystanek>{ new Przystanek {nazwa_przystanku = "Konopnicja", czas = 300 }, new Przystanek {  nazwa_przystanku = "Ziemniaczana",czas = 450 } , new Przystanek {nazwa_przystanku="Cytrynowa", czas=80 } } } ,
               new Trasa{ id_busa=4, nazwa="Merecedes", kierowca="Mroczek", _Przystanek= new List<Przystanek>{ new Przystanek {nazwa_przystanku = "Bananowa", czas = 300 }, new Przystanek {  nazwa_przystanku = "Arbuzowa",czas = 450 }, new Przystanek { nazwa_przystanku="Zielona", czas=110}, new Przystanek {nazwa_przystanku="Czerwona",czas = 210 } } },
               new Trasa{ id_busa=5, nazwa="Audi", kierowca="Klinsman", _Przystanek= new List<Przystanek>{ new Przystanek {nazwa_przystanku = "Biała", czas = 300 }, new Przystanek {  nazwa_przystanku = "Kolorowa",czas = 450 }, new Przystanek { nazwa_przystanku = "Ciemna", czas = 280 }, new Przystanek {nazwa_przystanku="Ciemna", czas= 100 }, new Przystanek {nazwa_przystanku="Hazardowa", czas= 130 } } },
               new Trasa{ id_busa=6, nazwa="Polo", kierowca="Małysz", _Przystanek= new List<Przystanek>{ new Przystanek {nazwa_przystanku = "Lukakowa", czas = 300 }, new Przystanek {  nazwa_przystanku = "Hernandezowa",czas = 450 }, new Przystanek { nazwa_przystanku="Hazardpwa", czas =145} } },
               new Trasa{ id_busa=7, nazwa="Volvo", kierowca="Piątek", _Przystanek= new List<Przystanek>{ new Przystanek {nazwa_przystanku = "Testowa", czas = 300 }, new Przystanek {  nazwa_przystanku = "Środkowa",czas = 450 }, new Przystanek { nazwa_przystanku = "Końcowa", czas = 280 }  } }
            };
        }
        public IList<Trasa> Trasa_przystankow
        {
            get { return _TrasaList; }
            set { _TrasaList = value; }
        }

        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

        private Trasa _selectedTrasa;

        public Trasa SelectedTrasa
        {
            get
            {
                return _selectedTrasa;
            }

            set
            {
                OnPropertyChanged("SelectedTrasa");
                _selectedTrasa = value;
            }
        }


        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


        private class Updater : ICommand
        {
            event EventHandler ICommand.CanExecuteChanged
            {
                add
                {
                    throw new NotImplementedException();
                }

                remove
                {
                    throw new NotImplementedException();
                }
            }
            #region ICommand Members  

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {

            }

            #endregion
        }
    }


}

