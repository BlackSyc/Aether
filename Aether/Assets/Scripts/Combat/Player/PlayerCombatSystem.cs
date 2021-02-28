using Aether.Core;
using Aether.Core.Attributes;
using Aether.Input;
using Syc.Combat;
using Syc.Combat.Auras;
using Syc.Combat.HealthSystem;
using Syc.Combat.SpellSystem;
using UnityEngine;

namespace Aether.Combat.Player
{
	public class PlayerCombatSystem : CombatMonoSystem, ILocalPlayerLink
	{
		[SerializeField] private PlayerInput playerInput;
		public override object Allegiance => gameObject.layer;
		public override ICombatAttributes AttributeSystem => defaultAttributesSystem;
		public override Transform Origin => transform;

		public override bool CanBeTargeted { get; set; } = true;

		[SerializeField] private PlayerTargetSystem localPlayerTargetSystem;
		
		[SerializeField] private SpellRack spellSystem;

		[SerializeField] private HealthSystem healthSystem;

		[SerializeField] private AuraSystem auraSystem;

		[SerializeField] private ScryerAttributes defaultAttributesSystem;

		private void Awake()
		{
			AddSubsystem(localPlayerTargetSystem);
			AddSubsystem(spellSystem);
			AddSubsystem(healthSystem);
			AddSubsystem(auraSystem);

			playerInput.OnCastSpell += spellSystem.CastSpell;
			playerInput.OnMove += _ => spellSystem.MovementIntterupt();
			
			Core.Player.LinkToLocalPlayer(this);
		}

		private void OnDestroy()
		{
			playerInput.OnCastSpell -= spellSystem.CastSpell;
			Core.Player.UnlinkFromLocalPlayer(this);
		}

		public void OnLocalPlayerLinked(Core.Player player)
		{
			localPlayerTargetSystem.SetPlayerCamera(player.CameraTransform);
		}

		public void OnLocalPlayerUnlinked(Core.Player player)
		{
			localPlayerTargetSystem.SetPlayerCamera(null);
		}
	}
}