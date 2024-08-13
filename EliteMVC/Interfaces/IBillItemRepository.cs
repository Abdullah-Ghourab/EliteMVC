namespace EliteMVC.Interfaces
{
    using EliteMVC.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBillItemRepository
    {
        Task<IEnumerable<BillItem>> GetAllBillItemsAsync();
        Task<BillItem?> GetBillItemByIdAsync(int id);
        Task AddBillItemAsync(BillItem billItem);
        Task UpdateBillItemAsync(BillItem billItem);
        Task DeleteBillItemAsync(int id);
        Task SaveBillItemsAsync(IEnumerable<BillItem> billItems);
    }
}