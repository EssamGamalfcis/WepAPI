using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Services
{
    public class InventoryServices : IInventoryServices
    {

        

        private readonly Dictionary<string, InventoryItems> _inventoryItems;

        private InventoryContext context = new InventoryContext();

        /* return list with the result*/
        public List<InventoryItems> GetInventoryItems()
        {
            return context.InventoryItem.ToList();
        }

     
        public void AddInventoryItems(InventoryItems item)
        {
                context.Add(item);
                context.SaveChanges();
        }



        public InventoryItems UpdateInventoryItem(InventoryItems item)
        {
            var InventoryItem = context.InventoryItem.FirstOrDefault(s => s.Id == item.Id);
            try
            {
                InventoryItem.Id = item.Id;
                InventoryItem.ItemName = item.ItemName;
                InventoryItem.Price = item.Price;
                return InventoryItem;

            }
            catch
            {

                return null;
            }
        }

        public string DeleteInventoryItem(int id)
        {
            var item=_inventoryItems.FirstOrDefault(s =>s.Value.Id == id);
            try
            {
                _inventoryItems.Remove(item.Key);
                return "Deleted Successd";
            }
            catch
            {
                return "Faild to Delete";
            }
            
        }

       
       

        
    }
}
