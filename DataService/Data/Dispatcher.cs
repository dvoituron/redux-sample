namespace BlazorDataService.Data
{
    using System;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;

    public class Dispatcher<T>
    {
        private readonly Subject<T> _actionDispatchedSubject = new Subject<T>();

        public virtual IObservable<T> ActionsDispatched => _actionDispatchedSubject.AsObservable();

        public virtual void DispatchChanges(T value)
        {
            _actionDispatchedSubject.OnNext(value);
        }
    }

}
