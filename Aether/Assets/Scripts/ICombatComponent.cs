using Aether.TargetSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombatComponent
{
    ICombatSystem CombatSystem { get; set; }
}
