using System.Collections.Generic;
using System.Threading.Tasks;
using Assingment1.Data.Models;

namespace Assingment1.Data.Services
{
    public interface IAdultService
    {
        public Task<IList<Adult>> GetAdults();
         public Task<Adult> AddAdult(Adult adult);
        public  Task RemoveAdult(Adult adult);
        public Adult GetByAdultId(int id);
        public Task EditAdult(Adult adult); 
        public void UpdateAdult(Adult adultToUpdate);
    }
}