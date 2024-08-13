using EliteMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EliteMVC.Interfaces;

namespace EliteMVC.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IBillItemRepository _repository;

        public InvoiceController(IBillItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _repository.GetAllBillItemsAsync();
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> SaveBill([FromBody] List<BillItem> billItems)
        {
            if (ModelState.IsValid)
            {
                await    _repository.SaveBillItemsAsync(billItems);
                return Json(new { success = true, message = "Bill saved successfully" });
            }
            return Json(new { success = false, message = "Error saving bill" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSelectedRows( List<int> ids)
        {
            foreach (var id in ids)
            {
              await  _repository.DeleteBillItemAsync(id);
            }
            return Json(new { success = true, message = "Selected rows deleted successfully" });
        }
    }
}