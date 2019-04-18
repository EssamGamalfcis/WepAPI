using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.Models;
using InventoryService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [Route("api/")]
    [ApiController]
    public class InventoryController : Controller
    {
        private readonly IInventoryServices _services;
        private InventoryItems InventoryItems = new InventoryItems();

        
        public InventoryController(IInventoryServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("GetInventoryItems")]
        public IActionResult GetInventoryItems()
        {
            var inventoryItems = _services.GetInventoryItems();
            return inventoryItems.Count > 0 ? Json(new { inventoryItems }) : Json("Not Data Found");
            
        }
     

        [HttpPost]
        [Route("AddInventoryItems")]
        public ActionResult<InventoryItems> AddInventoryItems(InventoryItems item)
        {
            if (item.Id == 0 && item.ItemName == null && item.Price == 0)
            {
                return NotFound();
            }
            else
            {
                 _services.AddInventoryItems(item);
                return RedirectToAction("GetInventoryItems");
            }
        }

       

        [HttpPut]
        [Route("UpdateInventoryItem")]
        public void UpdateInventoryItem(InventoryItems item)
        {
            _services.UpdateInventoryItem(item);
        }

        [HttpDelete]
        [Route("DeleteInventoryItem/{id}")]
        public void DeleteInventoryItem(int id)
        {
            if (id != null)
            {
                _services.DeleteInventoryItem(id);
            }        
        }

    }
}