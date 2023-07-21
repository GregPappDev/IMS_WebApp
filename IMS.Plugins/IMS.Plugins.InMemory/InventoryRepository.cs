﻿using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;

        public InventoryRepository()
        {
            _inventories = new List<Inventory>() 
            {
                new Inventory() {
                    InventoryId = 1, 
                    InventoryName="Bike seat",
                    Quantity = 10,
                    Price = 2,
                },
                new Inventory() {
                    InventoryId = 1,
                    InventoryName="Bike body",
                    Quantity = 10,
                    Price = 15,
                },
                new Inventory() {
                    InventoryId = 1,
                    InventoryName="Bike wheels",
                    Quantity = 20,
                    Price = 8,
                },
                new Inventory() {
                    InventoryId = 1,
                    InventoryName="Bike pedals",
                    Quantity = 20,
                    Price = 1,
                },
            };
        }

        public Task AddInventoryAsync(Inventory inventory)
        {
            if(_inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase))) { return Task.CompletedTask; }
              

            var maxId = _inventories.Max(x => x.InventoryId);
            inventory.InventoryId = maxId + 1;

            _inventories.Add(inventory);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);

            return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public Task UpdateInventoryAsync(Inventory inventory)
        {
            throw new NotImplementedException();
        }
    }
}