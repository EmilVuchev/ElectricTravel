namespace ElectricTravel.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITypeOfTravelService
    {
        Task CreateAsync(string name);

        Task<IEnumerable<T>> GetAll<T>();
    }
}
