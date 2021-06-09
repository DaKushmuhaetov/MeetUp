using System;
using System.Collections.Generic;

namespace MeetUp.Shared.CQRS
{
    public interface IQueryHandlerRegistry
    {
        IEnumerable<Type> Queries { get; }

        Type GetQueryHandler(Type type);
    }
}