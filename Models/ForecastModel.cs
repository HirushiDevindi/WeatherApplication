namespace WeatherApplication.Models{

    public class ForecastModel{
        public string cod { get; set; }
        public int message { get; set; }
        public int cnt { get; set; }
        public List<List2> list { get; set; }
        public City city { get; set; }

    }

    public class Main2{
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
        public int humidity { get; set; }
        public double temp_kf { get; set; }
    }

    public class Weather2
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Clouds2
    {
        public int all { get; set; }
    }
    public class Wind2
    {
        public double speed { get; set; }
        public int deg { get; set; }
        public double gust {get;set;}
    }

    public class Sys2{
        public string pod { get; set; }
    }

    public class List2{
        public int dt { get; set; }
        public Main2 main { get; set; }
        public List<Weather2> weather { get; set; }
        public Clouds2 clouds { get; set; }
        public Wind2 wind { get; set; }
        public int visibility { get; set; }
        public double pop { get; set; }
        public Sys2 sys { get; set; }
        public string dt_txt { get; set; }

    }

    public class Coord2
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class City{
        public int id { get; set; }
        public string name { get; set; }
        public Coord2 coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
        public int timezone { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }

    }
}