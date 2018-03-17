using System.Collections.Generic;
using System.Linq;
using CrossPlatApp.Models;
using Newtonsoft.Json;

namespace CrossPlatApp
{
    static public class Data
    {
        public static List<Item>Items { get; set; }
        private static string FilePath = "items.json";
        public static void LoadData()
        {
            string json = System.IO.File.ReadAllText(FilePath);
            Items = JsonConvert.DeserializeObject<List<Item>>(json);
        }

        public static Item GetItemById(int id)
        {
            return Items.Where(m => m.Id == id).First();
        }
        
    }
}