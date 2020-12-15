using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldNotes.Core.Models
{
    public abstract class BaseEmptyClass
    {

        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } 
        
        public BaseEmptyClass()
        {

            this.Id = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Now;
        
        }
    }
}
