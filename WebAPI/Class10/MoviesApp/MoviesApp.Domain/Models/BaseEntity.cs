using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Domain.Models
{
    public abstract class BaseEntity
    {
        // Без [Key] и [DatabaseGenerated] - EF ги заклучува по конвенција ("Id"),
        // а атрибути во Domain се забранети со барањата на оваа вежба.
        public int Id { get; set; }

        // Nullable и БЕЗ конструктор со UtcNow.
        // NotesApp има конструктор со DateTime.UtcNow и затоа во нивната SeedData
        // миграција се запекла конкретна временска марка. Ние го избегнуваме тоа.
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
