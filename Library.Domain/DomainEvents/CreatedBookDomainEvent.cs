namespace Library.Domain.DomainEvents;

public sealed class CreatedBookDomainEvent(Book book, LibraryUnit library) : DomainEvent
{
    public Book Book { get; init; } = book;
    public LibraryUnit Library { get; init; } = library;
};