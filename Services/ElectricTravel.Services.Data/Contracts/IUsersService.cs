namespace ElectricTravel.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Web.ViewModels.SharedTravels;

    public interface IUsersService
    {
        ////Task<ImageViewModel> GetUserPictureByAdvertId(string id);
        Task<T> GetDriverInfo<T>(string id);

        Task UpdateUser(ElectricTravelUser user);

        Task<ElectricTravelUser> GetUserByUserName(string username);
    }
}
