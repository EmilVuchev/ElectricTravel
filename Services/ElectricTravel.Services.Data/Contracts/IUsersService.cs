namespace ElectricTravel.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using ElectricTravel.Web.ViewModels.Images;

    public interface IUsersService
    {
        Task<ImageViewModel> GetUserPictureByAdvertId(string id);
    }
}
