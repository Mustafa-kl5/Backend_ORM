using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class PasswordPolicy
{
    public int Id { get; set; }

    public int? AccountId { get; set; }

    public int PasswordLength { get; set; }

    public bool Numericcharacter { get; set; }

    public bool Passwordalphabet { get; set; }

    public bool PasswordSpecial { get; set; }

    public bool PasswordDigitalSequence { get; set; }

    public bool PasswordalphaSequence { get; set; }

    public bool LockPassword { get; set; }

    public int PasswordRenewal { get; set; }

    public virtual GrcAccount? Account { get; set; }
}
