using System.Text.Json;
using System.Text.Json.Serialization;

using WeatherApplication.Models;

namespace WeatherApplication.Services{
public class WeatherService{
    public async Task<ResponseModel>  GetWeatherData(string City){
        string appId = "80de4d9176a8b731aa443784d04c7f9b";
        // API path with CITY parameter and other parameters.
        string apiUrl = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&APPID={1}", City, appId);
        //string apiUrl = "http://api.openweathermap.org/data/2.5/weather?q={City}&units=metric&cnt=1&APPID={appId}";
        
        using HttpClient client = new();
        try
        {
            var response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                // Ensure the WeatherModel structure matches the JSON structure returned by OpenWeatherMap.
                var weatherData = JsonSerializer.Deserialize<WeatherModel>(responseData);
                return ResponseModel.Success(weatherData);
            }
            return ResponseModel.Error($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        }
        catch (HttpRequestException ex)
        {
            return ResponseModel.Error($"Request error: {ex.Message}");
        }
            
            

        }

        //forcast data
        public async Task<ResponseModel>  GetForecastData(string City){
        string appId = "80de4d9176a8b731aa443784d04c7f9b";
        // API path with CITY parameter and other parameters.
        string apiUrl = string.Format("https://api.openweathermap.org/data/2.5/forecast?q={0}&appid={1}", City, appId);
        
        
        using HttpClient client = new();
        try
        {
            var response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                // Ensure the WeatherModel structure matches the JSON structure returned by OpenWeatherMap.
                var forecastData = JsonSerializer.Deserialize<ForecastModel>(responseData);
                return ResponseModel.Success(forecastData);
            }
            return ResponseModel.Error($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        }
        catch (HttpRequestException ex)
        {
            return ResponseModel.Error($"Request error: {ex.Message}");
        }
            
            

        }
    }
}