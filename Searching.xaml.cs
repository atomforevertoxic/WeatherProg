using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Net.Http;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json.Linq;

namespace WeatherProg
{
  public partial class Searching : Page
  {
    //API key to connect with OpenQeather server
    const string apiKey = "71da8bcd9dabca3709f89e692b8be7dc";
    public Searching()
    {
      InitializeComponent();
    }

    private async void Search_Click(object sender, RoutedEventArgs e)//when button "Поиск" is pressed
    {
      string cityForSearch = city.Text.Trim().ToLower();//getting name of city from TextBox in correct form
      if (cityForSearch.Length>2 && cityForSearch.Length < 59)
      {
        //clearing TextBox for next using 
        city.Text = "";
        city.Background = null;
        HttpClient client = new HttpClient();
        try
        {//trying to send request to server 
          string url = $"https://api.openweathermap.org/data/2.5/weather?q={cityForSearch}&appid={apiKey}&units=metric";
          string result = await client.GetStringAsync(url);//getting the answer from OpenWeather
          var json = JObject.Parse(result);//parse result to convenient JsonObject form
          //getting the weather values from json object in a certain city and saving it in DataBank class
          DataBank.Temperature = json["main"]["temp"].ToString();//value of the temperature
          DataBank.FeelsLikeTemperature = json["main"]["feels_like"].ToString();//value of the temperature(feels like)
          DataBank.Sky = json["weather"][0]["main"].ToString();//value of the state of the sky
          DataBank.Pressure = json["main"]["pressure"].ToString();//value of the pressure 
          DataBank.Sunrise = Convert.ToInt64(json["sys"]["sunrise"].ToString());//time of the sunrise
          DataBank.Sunset = Convert.ToInt64(json["sys"]["sunset"].ToString());//time of the sunset
          DataBank.City = cityForSearch;//saving the city that was entered by the user
          NavigationService.Navigate(new Answer());//going to the page that stores the answer
        }
        catch //if name of city is incorrect
        {
          Error();
        }
      }
      else //if nothing is in TextBox
      {
        Error();
      }
    }
    private void Error()//filling in TextBox in light red color
    {
      city.Text = "";
      city.Background = new SolidColorBrush(Color.FromRgb(250, 55, 113));
    }
  }
}
