using FieldNotes.Core.Models;
using System.Linq;

namespace FieldNotes.Core.Contracts

{
    public interface IRepository<T> where T : BaseEmptyClass
    {
        IQueryable<T> Collection();
        void Comit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T t);
        void Update(T t);
    }
}