using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoginExample.Data.Models
{
    public interface IAdult
    {
        IList<Adult> Getadults();
        void AddAdult(Adult adult);
        void RemoveAdult(int id);
        Adult GetById(int id);
        void EditAdult(Adult adult);
        void UpdateAdult(Adult adult);
    }
}