using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using LoginExample.Data.Models;

namespace LoginExample.Data.Impl
{
    public class AdultJSONData : IAdult
    {
        private IList<Adult> adults = new List<Adult>();
        private string adultFile =
            "C:/Users/Solaiman/Desktop/DNPExamples-master/DNPExamples-master/Blazor/LoginExample/bin/Debug/net5.0/adults.json";

        public AdultJSONData()
        {
            if (!File.Exists(adultFile))
            {
                Seed();
                WriteAdultToFile();
            }
            else
            {
                string content = File.ReadAllText(adultFile);
                adults = JsonSerializer.Deserialize<List<Adult>>(content);
            }
        }


        public IList<Adult> Getadults()
        {
            return adults;
        }

        public void AddAdult(Adult adult)
        {
            int max = adults.Max(t => adult.Id);
            adult.Id = (++max);
            adults.Add(adult);
            WriteAdultToFile();
        }

        public void RemoveAdult(int id)
        {
            
            Adult toRemove = adults.First(t => t.Id == id);
           adults.Remove(toRemove);
            WriteAdultToFile();
        }

        public Adult GetById(int id)
        {
            foreach (var item in adults)
            {
                if (item.Id == id)
                {
                    Adult adult = item;
                    return adult;
                }
            }

            return null;
        }

        public void EditAdult(Adult adult)
        {
            adult.Update(adult);
        }
        

        public void UpdateAdult(Adult adultToUpdate)
        {
            foreach (var item in adults)
            {
                if (item.Id == adultToUpdate.Id)
                {
                    item.Update(adultToUpdate);
                }
                
            }
        }

        
        
        
        
        private void Seed()
        {
            Adult[] ts =
            {
                new Adult()
                {
                    FirstName = "Anders",
                    Age = 22,
                    EyeColor = "black",
                    HairColor = "red",
                    Height = 179,
                    Id = 1,
                    LastName = "jensen",
                    Sex = "Female",
                    Weight = 56,
                    job = new Job(){JobTitle = "salesman",Salary = 30000}
                },
            };
            adults = ts.ToList();
        }
        

        private void WriteAdultToFile()
        {
            string todosAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(adultFile, todosAsJson);
        }
    }
}

