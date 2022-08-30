namespace TravelRequisitionSystem.Model
{
    public class CountryDetails
    {
        public string Country { get; set; }
        public string Currency { get; set; }
        public string Province { get; set; }
        public WeatherDetails Weather { get; set; }
    }

    public class WeatherDetails
    {
        public string MinimumTemperature { get; set; }
        public string MaximumTemperature { get; set; }
        public string Presssure { get; set; }
        public string Humidity { get; set; }
        
    }
}
