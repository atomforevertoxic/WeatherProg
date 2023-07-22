using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherProg
{
  /// <summary>
  /// Логика взаимодействия для Answer.xaml
  /// </summary>
  public partial class Answer : Page
  {
    public Answer()
    {
      InitializeComponent();
    }
    DateTime ConvertToDateTime(long millisec)//convert value from OpenWeather(in millisec) to familiar form
    {
      DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
      day = day.AddSeconds(millisec).ToLocalTime();
      return day;
    }
    private void ToBack_Click(object sender, RoutedEventArgs e)//when button "Назад" is presesed we are getting back to the first page
    {
      NavigationService.GoBack();
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {//at the moment when answer page is loading, we are getting info from DataBank class and showing it on this page
      //outputing name of the city that was entered
      char[] nameOfTheCity = DataBank.City.ToCharArray();
      nameOfTheCity[0] = char.ToUpper(nameOfTheCity[0]);
      City.Text = new string(nameOfTheCity);
      //outputting weather values that were saved in DataBank class in familiar form
      Temp.Text = $"{DataBank.Temperature}°C";
      FeelsLikeTemp.Text = $"По ощущениям: {DataBank.FeelsLikeTemperature}°C";
      Press.Text = $"Давление: {DataBank.Pressure} мм.рт.ст";
      Sunr.Text = $"Восход в {ConvertToDateTime(DataBank.Sunrise).ToShortTimeString()} Мск";
      Suns.Text = $"Закат в {ConvertToDateTime(DataBank.Sunset).ToShortTimeString()} Мск";
      //depending of the state of the sky, displaying different picture on the same position 
      if (DataBank.Sky == "Clear")
      {
        Sunny.Visibility = Visibility.Visible;
      }
      else if (DataBank.Sky == "Clouds")
      {
        Cloudy.Visibility = Visibility.Visible;
      }
      else if (DataBank.Sky == "Rain")
      {
        Rainy.Visibility = Visibility.Visible;
      }
      else
      {
        Snowy.Visibility = Visibility.Visible;
      }
    }
  }
}
