namespace ElectricTravel.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface IRatingService
    {
        Task SetRateAsync(string userId, string assessorId, double value);

        double GetAverageRating(string userId);
    }
}
