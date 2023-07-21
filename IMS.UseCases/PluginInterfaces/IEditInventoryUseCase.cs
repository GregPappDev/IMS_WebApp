using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IEditInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}