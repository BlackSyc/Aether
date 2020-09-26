using Aether.Core.Settings;
using Syc.Combat;
using Syc.Core.Attributes;
using Syc.Movement;
using UnityEngine;

namespace Aether.Core.Attributes
{
	public class ScryerAttributes : MonoBehaviour, ICombatAttributes, IMovementAttributes
	{
		[SerializeField] private Attribute stamina;
		[SerializeField] private Attribute spellPower;
		[SerializeField] private Attribute haste;
		[SerializeField] private Attribute criticalStrikeRating;
		[SerializeField] private Attribute armor;
		[SerializeField] private Attribute movementSpeed;

		public Attribute Stamina => stamina;

		public Attribute SpellPower => spellPower;

		public Attribute Haste => haste;

		public Attribute CriticalStrikeRating => criticalStrikeRating;

		public Attribute Armor => armor;

		public Attribute MovementSpeed => movementSpeed;

		public Attribute JumpPower => movementSpeed;

		public Attribute RotationSpeed => GameSettings.Instance.MouseSensitivity;
	}
}
