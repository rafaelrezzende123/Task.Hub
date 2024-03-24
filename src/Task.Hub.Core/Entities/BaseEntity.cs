using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Task.Hub.Core.Entities.Interface;


namespace Task.Hub.Core.Entities;

[Index(nameof(Uid), IsUnique = true)]
[Index(nameof(Id), IsUnique = true)]
public class BaseEntity() : IAuditEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private set; }
    public bool Active { get; private set; } = true;
    public Guid Uid { get; private set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? ModifiedAt { get; private set; }


    public void SetModifiedAt(DateTime modifiedAt)
    {
        ModifiedAt = modifiedAt;
    }

    public void Disable()
    {
        Active = false;
    }

}
