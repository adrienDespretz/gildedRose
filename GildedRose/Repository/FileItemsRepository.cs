using GildedRose.Items;
using GildedRose.ItemsRepository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GildedRose.ItemsRepository
{
    public class FileItemsRepository : ItemRepository
    {
        List<Item> itemsList = new List<Item>();
        public FileItemsRepository()
        {

            var fileName = "C:\\Users\\enzoa\\Desktop\\Projets\\gildedRose\\GildedRose\\FileItem.json";
            string jsonString = File.ReadAllText(fileName);
            var sitemsList = JsonConvert.DeserializeObject(jsonString);
            dynamic convertObj = JObject.Parse(jsonString);
        }

        public void SaveInventory(List<Item> itemList)
        {
            foreach (Item item in itemList)
            {
                itemsList.Add(item);
            }
        }

        public List<Item> GetInventory()
        {
            return itemsList.ToList();
        }

        public Item FindItem(string type, int quality)
        {
            var itemsFind = itemsList.ToList().Where(x => x.quality == quality && x.name == type).FirstOrDefault();
            if(itemsFind != null)
            {
                return itemsFind;
            }
            else
            {
                return null;
            }
               
        }
    }
}
