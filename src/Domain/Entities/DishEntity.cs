using Domain.Interfaces;

namespace Domain.Entities;
public class DishEntity : IAggregateRoot
{
    public int Id { get; init; } 
    public string Name { get; init; }
    public string Description { get; init; }
    public double Price { get; init; }
    public string AttachmentName { get; private set; }

    public void SetAttachmentName (string fileName)
    {
        AttachmentName = fileName;
    }
}