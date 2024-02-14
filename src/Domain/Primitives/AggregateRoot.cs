using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Primitives
{
    public abstract class AggregateRoot
    {
        //listado de eventos de dominio
        private readonly List<DomainEvent> _domainEvents = new();
        public ICollection<DomainEvent> GetDomainEvents()=>_domainEvents;
        protected void Raise(DomainEvent domainEvent){
            _domainEvents.Add(domainEvent);
        }
    }
}