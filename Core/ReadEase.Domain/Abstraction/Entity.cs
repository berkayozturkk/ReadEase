namespace ReadEase.Domain.Abstraction;

public class Entity
{
    public string Id { get; set; }

    public Entity()
    {
        Id = default;
    }

    public Entity(string id)
    {
        Id = id;
    }
}
