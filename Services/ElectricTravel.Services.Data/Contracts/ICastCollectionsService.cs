namespace ElectricTravel.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICastCollectionsService
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetTravelTypesAsKeyValuePairs();

        Task<IEnumerable<KeyValuePair<string, string>>> GetCitiesAsKeyValuePairs();

        Task<IEnumerable<KeyValuePair<string, string>>> GetRegionsAsKeyValuePairs();
    }
}
