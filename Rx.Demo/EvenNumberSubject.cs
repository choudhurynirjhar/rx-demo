using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;

namespace Rx.Demo
{
    class EvenNumberSubject : IDisposable
    {
        private readonly AsyncSubject<int> subject = new ();
        public readonly List<IDisposable> disposables = new ();

        public void Dispose()
        {
            subject?.Dispose();
            foreach (var item in disposables)
            {
                item?.Dispose();
            }
        }

        public void Run()
        {
            Enumerable.Range(1, 100).Where(x => x % 2 == 0).ToList().ForEach(x => {
                subject.OnNext(x);
                if (x == 100) subject.OnCompleted();
            });
        }

        public void Subscribe(Action<int> action)
        {
            disposables.Add(subject.Subscribe(action));
        }
    }
}