using System.Collections.Generic;
using System.Threading.Tasks;
using EliteMVC.Data;
using EliteMVC.Interfaces;
using EliteMVC.Models;
using Microsoft.EntityFrameworkCore;


public class BillItemRepository : IBillItemRepository
{
    private readonly ApplicationDbContext _context;

    public BillItemRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BillItem>> GetAllBillItemsAsync()
    {
        return await _context.BillItems.ToListAsync();
    }

    public async Task<BillItem?> GetBillItemByIdAsync(int id)
    {
        return await _context.BillItems.FindAsync(id);
    }
    public async Task AddBillItemAsync(BillItem billItem)
    {
        await _context.BillItems.AddAsync(billItem);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateBillItemAsync(BillItem billItem)
    {
        _context.Entry(billItem).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBillItemAsync(int id)
    {
        var billItem = await _context.BillItems.FindAsync(id);
        if (billItem != null)
        {
            _context.BillItems.Remove(billItem);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SaveBillItemsAsync(IEnumerable<BillItem> billItems)
    {
        foreach (var item in billItems)
        {
            if (item.Id == 0)
            {
                await _context.BillItems.AddAsync(item);
            }
            else
            {
                _context.Entry(item).State = EntityState.Modified;
            }
        }
        await _context.SaveChangesAsync();
    }
}