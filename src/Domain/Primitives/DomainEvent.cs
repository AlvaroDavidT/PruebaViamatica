using MediatR;

namespace Domain.Primitives
{

    //eventos de dominios

    public record DomainEvent(Guid Id) : INotification;
}