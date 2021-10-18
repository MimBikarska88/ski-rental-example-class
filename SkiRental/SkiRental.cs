using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{

    public class SkiRental 
    {
        public List<Ski> data;
        public int Capacity { get; set; }
        public string Name { get; set; }

        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            data = new List<Ski>();
        }
        public void Add(Ski ski)
        {
            if (data.Count < Capacity)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var findSki = data.FindIndex(ski => ski.Manufacturer.Equals(manufacturer) && ski.Model.Equals(model));
            if (findSki > -1)
            {
                data.RemoveAt(findSki);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Ski GetNewestSki() =>  data.OrderByDescending(ski => ski.Year).FirstOrDefault();

        public Ski GetSki(string manufacturer, string model) =>
            data.FirstOrDefault(ski => ski.Manufacturer == manufacturer && ski.Model == model);

        public int Count
        {
            get => data.Count;
        }

        public string GetStatistics()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"The skis stored in {Name}:");
            foreach (var ski in data)
            {
                stringBuilder.AppendLine(ski.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}