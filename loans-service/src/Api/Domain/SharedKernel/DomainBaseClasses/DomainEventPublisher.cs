namespace Gbm.Api.Scopes.Domain.SeedWork
{
    using System;
    using System.Reactive.Subjects;

    public static class DomainEventPublisher
    {
        private static Subject<IDomainEvent> domainEventSubject = new Subject<IDomainEvent>();

        public static IObservable<IDomainEvent> DomainEvent => Subject;

        private static Subject<IDomainEvent> Subject
        {
            get
            {
                if (domainEventSubject.IsDisposed)
                {
                    domainEventSubject = new Subject<IDomainEvent>();
                }

                return domainEventSubject;
            }
        }

        public static void PublishEvent(IDomainEvent eventToPublish)
        {
            Subject.OnNext(eventToPublish);
        }

        public static void CloseEventSequence()
        {
            Subject.Dispose();
        }
    }
}
