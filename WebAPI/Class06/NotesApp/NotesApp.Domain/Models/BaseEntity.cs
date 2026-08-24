using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesApp.Domain.Models;

public abstract class BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//+1 da se dvizi
    //da se napira so pimary key i se zgolemuva za 1
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    protected BaseEntity()
    {
        CreatedDate = DateTime.UtcNow;
        UpdatedDate = DateTime.UtcNow;
    }
}
