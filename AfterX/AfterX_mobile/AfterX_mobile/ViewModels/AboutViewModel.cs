using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using AfterX_mobile.Models;
using System.Collections.Generic;
using AfterX_mobile.Helper;
using System.Threading.Tasks;

using AfterX_mobile.Views;
using System.Collections.ObjectModel;

namespace AfterX_mobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Home";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            LoadCities();
        }

        public void LoadCities()
        {
            citiesList = new List<City>();
            // string res = await RestHelper.GetCities();
            citiesList.Add(new City(1, 1, "Zagreb", 10000));
            citiesList.Add(new City(2, 1, "Osijek", 31000));

        }

        public void LoadClubs(int id)
        {
            ObservableCollection<Club> clubs = new ObservableCollection<Club>();
            clubs.Add(new Club(1, "Roko", 1));
            clubs.Add(new Club(2, "Jazavac", 2));
            clubs.Add(new Club(3, "Jungle", 3));
            ClubsList = clubs;
        }

        private ObservableCollection<Club> clubsList;

        public ObservableCollection<Club> ClubsList
        {
            get { return clubsList; }
            set { clubsList = value; OnPropertyChanged("ClubsList");  }
        }


        private List<City> citiesList;

        public List<City> CitiesList
        {
            get { return citiesList; }
            set { citiesList = value; OnPropertyChanged("CitiesList"); }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set 
            { 
                if(selectedCity != value)
                {
                    selectedCity = value;
                    LoadClubs(selectedCity.Id);
                    //System.Diagnostics.Debug.WriteLine(selectedCity.Id);
                    //OnPropertyChanged("SelectedCity");
                } 
            }
        }

        public ICommand OpenWebCommand { get; }
    }
}