namespace Library.Domain.DomainEvents;

public sealed class CreatedBookDomainEvent(Book book) : DomainEvent
{
    public Book Book { get; init; } = book;
};