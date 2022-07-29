using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ReduxSample.Models
{
    /// <summary />
    public abstract class DispatcherBase<T>
    {
        private readonly Subject<T> _actionDispatchedSubject = new Subject<T>();

        /// <summary>
        /// Gets an observable sequence to subscribe to.
        /// </summary>
        public virtual IObservable<T> ActionsDispatched => _actionDispatchedSubject.AsObservable();

        /// <summary>
        /// Notifies all subscribed observers about the data changes.
        /// </summary>
        /// <param name="value"></param>
        protected virtual void DispatchChanges(T value)
        {
            _actionDispatchedSubject.OnNext(value);
        }
    }
}
