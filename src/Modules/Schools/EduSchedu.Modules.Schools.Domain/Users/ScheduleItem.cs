﻿using EduSchedu.Shared.Abstractions.Kernel.Primitives;
using EduSchedu.Shared.Abstractions.Kernel.ValueObjects;

namespace EduSchedu.Modules.Schools.Domain.Users;

public class ScheduleItem : Entity<Guid>
{
    public ScheduleItemType Type { get; private set; }
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }
    public Description Description { get; private set; }

    private ScheduleItem()
    {
    }

    private ScheduleItem(Guid id, ScheduleItemType type, DateTime start, DateTime end, string description)
        : base(id)
    {
        Type = type;
        Start = start;
        End = end;
        Description = description;
    }

    public static ScheduleItem Create(ScheduleItemType type, DateTime start, DateTime end, string description)
        => new ScheduleItem(Guid.NewGuid(), type, start, end, description);
}