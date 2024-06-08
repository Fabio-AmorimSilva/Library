namespace Library.Application.DomainEventHandlers;

public class CreatedBookDomainEventHandler : INotificationHandler<CreatedBookDomainEvent>
{
    public Task Handle(CreatedBookDomainEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($@"
        -------------//-----------------------
            Title  : {notification.Book.Title}
            Author : {notification.Book.Author}
            Genre  : {notification.Book.Genre}
            Year   : {notification.Book.Year}
            Pages  : {notification.Book.Pages}
            Library: {notification.Book.Library.Name}
        _____________//________________________
        ");
        
        return Task.CompletedTask;
    }
}