﻿namespace Library.Core.Entities;

public class AggregateRoot
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    private readonly List<DomainEvent> _domainEvents = [];

    [NotMapped]
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(DomainEvent domainEvent)
        => _domainEvents.Add(domainEvent);
    
    public void RemoveDomainEvent(DomainEvent domainEvent)
        => _domainEvents.Remove(domainEvent);
    
    public void ClearDomainEvents()
        => _domainEvents.Clear();
}