using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CodingChallenge.Bll;
using CodingChallenge.Models;

namespace CodingChallenge.Controllers
{
    public class CodingChallengeApiController : ApiController
    {
        [HttpGet]
        [Route("hello")]
        public HttpResponseMessage HelloWorldMessage()
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent("Hello World!")
            };
            return response;
        }

        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(User user)
        {
            string s = CodingChallengeBLL.Login(user);
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(s)
            };
            return response;
        }

        [HttpPost]
        [Route("api/register")]
        public HttpResponseMessage Register(User user)
        {
            string s = CodingChallengeBLL.Register(user);
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(s)
            };
            return response;
        }

        [HttpPost]
        [Route("api/weather")]
        public HttpResponseMessage GetWeather(Weather weather)
        {
            string s = CodingChallengeBLL.GetWeather(weather.City);
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(s)
            };
            return response;
        }

        [HttpPost]
        [Route("api/random/weather")]
        public HttpResponseMessage GetRandomWeather()
        {
            string s = CodingChallengeBLL.GetRandomWeatherCity();
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(s)
            };
            return response;
        }

    }
}
