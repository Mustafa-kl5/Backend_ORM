using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class SystemParameter
{
    public int MinimumPasswordLength { get; set; }

    public string PasswordComplexity { get; set; } = null!;

    public int PasswordMinAge { get; set; }

    public int PasswordMaxAge { get; set; }

    public int LockAfterAttempt { get; set; }

    public int LockTime { get; set; }

    public bool EnableAwayLockScreen { get; set; }

    public bool EnableTerminateSession { get; set; }

    public int TerminateSessionAfter { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;
}
