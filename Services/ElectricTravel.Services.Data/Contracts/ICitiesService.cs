namespace ElectricTravel.Services.Data.Contracts
{
    using System.Collections.Generic;

    public interface ICitiesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
