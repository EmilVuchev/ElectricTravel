namespace ElectricTravel.Services.Data.Contracts
{
    using System.Collections.Generic;

    public interface ITypeOfTravelService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
