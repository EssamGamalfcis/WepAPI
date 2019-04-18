using InventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Services
{

    public interface IInventoryServices
    {
        List<InventoryItems> GetInventoryItems();
        void AddInventoryItems(InventoryItems items);
        
        InventoryItems UpdateInventoryItem(InventoryItems item);
        string DeleteInventoryItem(int id);
    }
    
}
