using ProductStockApi.Data.Model;

namespace ProductStockApi.Repository
{
    public interface IStockRepository
    {
        Stock AddStock(int id,int count);
        Stock RemoveStock(int id,int count);
        Stock GetStock(int id);
    }
}
