using System;

namespace Application.Contracts.Infrastructure
{
    public interface IFLog<T>
    {
        void Write(Exception ex, string msg);
    }
}
