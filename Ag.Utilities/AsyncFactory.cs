using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AG.Utilities
{
    public sealed class AsyncFactory<T>
    {
        private readonly Func<Task<T>> func;

        public AsyncFactory(Func<T> factory) => func = () => Task.Run(factory);
        public AsyncFactory(Func<Task<T>> factory) => func = factory;
            
        public TaskAwaiter<T> GetAwaiter() => func().GetAwaiter();
    }
}
