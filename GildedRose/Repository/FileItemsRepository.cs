using GildedRose.Items;
using GildedRose.ItemsRepository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

            var fileName = "C:\\Users\\Amieva\\Desktop\\Enzo\\EPSI\\gildedRose\\GildedRose\\FileItem.json";
            itemsList = JsonConvert.DeserializeObject<List<Item>>(File.ReadAllText(fileName), new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
        }

        public void SaveInventory(List<Item> itemList)
        {
            itemsList = itemList.ToList();
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
