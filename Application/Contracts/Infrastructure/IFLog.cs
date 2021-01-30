using System;

namespace Application.Contracts.Infrastructure
{
    public interface IFLog<T>
    {
        void WriteError(Exception ex, string msg);
        void WriteInformation(string msg);

    }
}
