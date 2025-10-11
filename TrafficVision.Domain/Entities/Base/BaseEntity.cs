namespace TrafficVision.Domain.Entities.Base;

public class BaseEntity
{
    public long Id { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }

    public void SetChangedDate()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}