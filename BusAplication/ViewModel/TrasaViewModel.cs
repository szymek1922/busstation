using BusId.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Windows;
using BusAplication.ViewModel;
using System.Windows.Controls;

namespace BusId.ViewModel
{
    internal class TrasaViewModel : BaseViewModel
    {
        private IList<Trasa> _TrasaList;
        
        
        public bool IsMyIdIndividual(string newId)
        {
           
            foreach (var item in _TrasaList)
            {
                if(Equals(item.BusId, newId))
                {
                    return false;
                }
            }
            return true;
        }

        public TrasaViewModel()
        {
            SaveXmlCommand = new RelayCommand(o => { SaveXml(); }, o => true);
            ShowMap = new RelayCommand(o => { metoda(); }, o => true);
            var filePath = Path.Combine(Environment.CurrentDirectory, "./", "data.xml");

            if (File.Exists(filePath))
            {
                XmlSerializer xmlser = new XmlSerializer(typeof(List<Trasa>));
                using (StreamReader srdr = new StreamReader(filePath))
                {
                    _TrasaList = (List<Trasa>)xmlser.Deserialize(srdr);
                    srdr.Close();
                }
            }
        }

       



        public IList<Trasa> Trasa_przystankow
        {
            get
            {
                return _TrasaList;
            }
            set
            {
                _TrasaList = value;
                RaisePropertyChanged("Trasa_przystankow");
            }
        }

        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                {
                    mUpdater = new Updater();
                }
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
                _selectedTrasa = value;
                RaisePropertyChanged("SelectedTrasa");
            }
        }

        private Uri _showUrl;
        public Uri ShowUrl
        {
            get
            {
                return _showUrl;
            }
            set
            {
                _showUrl = value;
                RaisePropertyChanged("ShowUrl");
            }
        }

        public static class WebBrowserUtility
        {
            public static readonly DependencyProperty BindableSourceProperty =
                DependencyProperty.RegisterAttached("BindableSource", typeof(string), typeof(WebBrowserUtility), new UIPropertyMetadata(null, BindableSourcePropertyChanged));

            public static string GetBindableSource(DependencyObject obj)
            {
                return (string)obj.GetValue(BindableSourceProperty);
            }

            public static void SetBindableSource(DependencyObject obj, string value)
            {
                obj.SetValue(BindableSourceProperty, value);
            }

            public static void BindableSourcePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
            {
                WebBrowser browser = o as WebBrowser;
                if (browser != null)
                {
                    string uri = e.NewValue as string;
                    browser.Source = !String.IsNullOrEmpty(uri) ? new Uri(uri) : null;
                }
            }

        }



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
        public System.Windows.Media.Brush MyBrush { get; set; }
        public ICommand SaveXmlCommand { get; set; }

        public ICommand ShowMap { get; set; }

        private void metoda()
        {
            var test = _TrasaList;
            string[] tab = new string[11];
            int count=0;
            foreach (var trasa in test)
            {
                tab[count] = trasa.Link;
                count++;
            }
        }
        public bool CheckIfTheSame()
        {
            var test = _TrasaList;
            int count = 0;
            int[] tab = new int[11];
            foreach (var trasa in test)
            {
                try
                {
                    tab[count] = Int32.Parse(trasa.BusId);
                    count++;
                }
                catch (System.FormatException e)
                {
                    //throw new ArgumentException("Minimum 3 znaki!");
                }
               
            }
            int i = 0;
            count = 0;

            int n = tab.Length;
            do
            {
                for (i = 0; i < n - 1; i++)
                {
                    if (tab[i] > tab[i + 1])
                    {
                        int tmp = tab[i];
                        tab[i] = tab[i + 1];
                        tab[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);

            while (count < tab.Length - 1)
            {
                if (tab[count] == tab[count + 1])
                {                  
                    return true;
                
                }
            //    Console.WriteLine("{0} {1}", tab[count], tab[count +1]);
                count++;

            }

            


            return false; 
        }
        private bool CheckIfTMinus()
        {
            var test = _TrasaList;
            int count = 0;
            int[] tab = new int[11];
            foreach (var trasa in test)
            {
                try
                {
                    tab[count] = Int32.Parse(trasa.BusId);
                    count++;
                }
                catch (System.FormatException e)
                {

                }
            }
            int i = 0;
            count = 0;

            int n = tab.Length;
            do
            {
                for (i = 0; i < n - 1; i++)
                {
                    if (tab[i] > tab[i + 1])
                    {
                        int tmp = tab[i];
                        tab[i] = tab[i + 1];
                        tab[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);

            count = 0;
            while (count < tab.Length)
            {
                if (tab[count] < 1)
                {
                    return true;
                }

                var temp = tab[count];
                string temp1 = Convert.ToString(temp);
                Console.WriteLine("{0}",temp1);
                if (string.IsNullOrEmpty(temp1))
                {
                    Console.WriteLine("Spacja");
                    return true;
                }
                //    Console.WriteLine("{0} {1}", tab[count], tab[count +1]);
                count++;
            }
            return false;
        }
        private bool CheckIfDriver()
        {
            var test = _TrasaList;
            int count = 0;
            string[] tab = new string[11];

            foreach (var trasa in test)
            {
                tab[count] = trasa.Kierowca;
                count++;
            }
            count = 0;
            while (count < tab.Length)
            {
                string temp = tab[count];
                
                if (temp.Length<=2)
                {
                    return true;
                }
                //Console.WriteLine("{0}", tab[count]);
                count++;
            }
            return false;
        }
        private bool CheckIfName()
        {
            var test = _TrasaList;
            int count = 0;
            string[] tab = new string[11];
          
            foreach (var trasa in test)
            {
                tab[count] = trasa.Nazwa;
                count++;
            }


            count = 0;
            while (count < tab.Length)
            {
                string temp = tab[count];

                if (temp.Length <=2)
                {
                    Console.WriteLine("{0}", tab[count]);
                    Console.WriteLine("{0}", temp.Length);
                    return true;

                }

                count++;
            }
            return false;
        }
        private bool CheckIfSpace()
        {
            var test = _TrasaList;
            int count = 0;
            string[] tab = new string[11];
            string[] tab1 = new string[11];

            foreach (var trasa in test)
            {
                tab[count] = trasa.Nazwa;
                count++;
            }
            count = 0;
            foreach (var trasa in test)
            {
                tab1[count] = trasa.Kierowca;
                count++;
            }
            int i = 0;
            int number_of_space = 0;
            int number_of_space1 = 0;
            while (i < 11)
            {
                int count1 = 0;

                string temp = tab[i];
                
                while (count1 < temp.Length)
                {
                    //   Console.WriteLine("Tessst: {0}", temp);
                    char first_of_string = temp[0];
                    char last_of_string = temp[temp.Length-1];
                    //Console.WriteLine("Tesss 1t: {0}, {1}", first_of_string, last_of_string);
                    if (first_of_string== ' ' || last_of_string==' ')
                    {
                        number_of_space++;
                        return true;
                        //   Console.WriteLine("znalazlem spacje: {0}", S);
                    }

                    // Console.WriteLine("Tessst: {0}", S);
                    count1++;

                }
                i++;
            }
            i = 0;
            while (i < 11)
            {
                int count1 = 0;

                string temp = tab1[i];

                while (count1 < temp.Length)
                {
                    //   Console.WriteLine("Tessst: {0}", temp);
                    char first_of_string = temp[0];
                    char last_of_string = temp[temp.Length - 1];
                    //Console.WriteLine("Tesss 1t: {0}, {1}", first_of_string, last_of_string);
                    if (first_of_string == ' ' || last_of_string == ' ')
                    {
                        number_of_space++;
                        return true;
                        //   Console.WriteLine("znalazlem spacje: {0}", S);
                    }

                    // Console.WriteLine("Tessst: {0}", S);
                    count1++;

                }
                i++;
            }

            if (number_of_space != 0 || number_of_space1 != 0)
                return true;
            return false;
        }
        private bool ValidateNummber()
        {
            var test = _TrasaList;
            int count = 0;
            int[] tab = new int[11];
            foreach (var trasa in test)
            {
                try
                {
                    tab[count] = Int32.Parse(trasa.BusId);
                    count++;
                }
                catch (System.FormatException e)
                {
                    return true;
                }
            }
            return false;
      }
        private void SaveXml()
        {
            bool flag = true;
            if (CheckIfTheSame() == true)
            {
                    MessageBox.Show("Linia o danym numerze już istnieje, zmiany nie zostaną zapisane", "Błąd danych wejsciowych");
                    flag = false;
                    RaisePropertyChanged("PropertyChanged");
            }
            else if (CheckIfTMinus() == true)
            {
                MessageBox.Show("Błędny numer autobusu, zmiany nie zostaną zapisane", "Błąd danych wejsciowych");
                flag = false;
            }
            else if (CheckIfDriver() == true)
            {
                MessageBox.Show("Pole kierowca musi mieć conajmniej 3 znaki, zmiany nie zostaną zapisane.", "Błąd danych wejsciowych");
                flag = false;
            }
            else if (CheckIfName() == true)
            {
                MessageBox.Show("Pole nazwa musi mieć conajmniej 3 znaki, zmiany nie zostaną zapisane.", "Błąd danych wejsciowych");
                flag = false;
            }
            else if (CheckIfSpace() == true)
            {
                MessageBox.Show("Pole posiada za duzo pustych znakow, zmiany nie zostaną zapisane.", "Błąd danych wejsciowych");
                flag = false;
            }
            else if (ValidateNummber() == true)
            {
                MessageBox.Show("Błędny numer autobusu, zmiany nie zostaną zapisane.", "Błąd danych wejsciowych");
                flag = false;
            }

            if (flag == false)
            {
               
               
                Console.WriteLine("ma tu wejsc");
               
                
                var filePath = Path.Combine(Environment.CurrentDirectory, "./", "data.xml");
                if (File.Exists(filePath))
                {
                    XmlSerializer xmlser = new XmlSerializer(typeof(List<Trasa>));
                    using (StreamReader srdr = new StreamReader(filePath))
                    {
                        Trasa_przystankow = (List<Trasa>)xmlser.Deserialize(srdr);
                        srdr.Close();
                    }
                }
                
                    
            }
            else
            {
                XmlSerializer x = new XmlSerializer(typeof(List<Trasa>));
                using (TextWriter writer = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "./", "data.xml"), false))
                {
                    x.Serialize(writer, _TrasaList);
                    writer.Close();
                }
                MessageBox.Show("Zmiany zostały zapisane", "Zapisanie danych");
            }
        }
    }
   
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null, bool v = false) : this(execute, canExecute)
        {
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}

