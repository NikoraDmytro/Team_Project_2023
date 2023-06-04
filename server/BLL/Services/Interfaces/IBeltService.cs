using BLL.Models.Belt;

namespace BLL.Services.Interfaces;

public interface IBeltService
{
    Task<IEnumerable<BeltModel>> GetAllBeltsAsync();
}