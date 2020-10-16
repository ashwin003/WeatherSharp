using WeatherSharp.Shared.Entities.Request;

namespace WeatherSharp.Client.Models
{
    public class SelectionItem
    {
        public SelectionItem(string displayName, string shortName, Unit unit)
        {
            DisplayName = displayName;
            ShortName = shortName;
            Unit = unit;
        }

        public string DisplayName { get; }
        public string ShortName { get; }
        public Unit Unit { get; }
    }
}
