using System;
using System.IO;
using System.Net;
using CodingChallenge.Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CodingChallenge.Bll
{
    public class CodingChallengeBLL
    {
        static string apiKey = "a8b531a2379f431f40804fed4350a73b";
        public static string GetWeather(string city)
        {
            city = city.Replace(" ", "%20");
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&units=metric&appid=" + apiKey;
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
            Stream ResponseStream = Response.GetResponseStream();
            StreamReader Reader = new StreamReader(ResponseStream);
            string ResponseData = Reader.ReadToEnd();
            JObject ResponseObject = JObject.Parse(ResponseData);
            Weather weather = new Weather();
            weather.City = ResponseObject["name"].ToString();
            weather.Country = ResponseObject["sys"]["country"].ToString();
            weather.WeatherMain = ResponseObject["weather"][0]["main"].ToString();
            weather.WeatherDescription = ResponseObject["weather"][0]["description"].ToString();
            weather.Temperature = Convert.ToDouble(ResponseObject["main"]["temp"].ToString());
            weather.TemperatureMax = Convert.ToDouble(ResponseObject["main"]["temp_min"].ToString());
            weather.TemperatureMin = Convert.ToDouble(ResponseObject["main"]["temp_max"].ToString());
            string responseString = JObject.Parse(JsonConvert.SerializeObject(weather)).ToString(Formatting.Indented);
            return responseString;
        }
        
        public static string Login(User user)
        {
            MySqlConnection conn = DBConnect.GetConnection();
            string query = "SELECT * FROM users where username = '" + user.UserName + "'";
            bool response = false;
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            User loggedinUser = new User();
            while (dataReader.Read())
            {
                if (user.Password == dataReader["password"].ToString())
                {
                    response = true;
                    loggedinUser.UserName = dataReader["username"].ToString();
                    loggedinUser.Email = dataReader["email"].ToString();
                    loggedinUser.FirstName = dataReader["firstname"].ToString();
                    loggedinUser.LastName = dataReader["lastname"].ToString();
                    loggedinUser.Password = dataReader["password"].ToString();
                }
                else
                {
                    response = false;
                }
            }
            DBConnect.CloseConnection();
            if (response)
            {
                return JObject.Parse(JsonConvert.SerializeObject(loggedinUser)).ToString(Formatting.Indented);
            }
            else
            {
                string s = "Login Failed";
                return s;
            }
        }

        public static string Register(User user)
        {
            MySqlConnection conn = DBConnect.GetConnection();
            string query = "INSERT INTO users (username,password,email,firstname,lastname,confirmpassword) VALUES ('" + user.UserName + "','" + user.Password + "','" + user.Email + "','" + user.FirstName + "','" + user.LastName + "','" + user.ConfirmPassword + "');";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            DBConnect.CloseConnection();
            string s = "success";
            return s;
        }

        public static string GetRandomWeatherCity()
        {
            string city = "";
            MySqlConnection conn = DBConnect.GetConnection();
            string query = "SELECT * FROM cities ORDER BY RAND() LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                city = dataReader["name"].ToString();
            }
            string response = GetWeather(city);
            return response;
        }

    }
}
