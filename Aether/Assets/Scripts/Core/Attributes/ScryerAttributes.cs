using System.Collections.Generic;
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
		
		private readonly Dictionary<string, Attribute> _attributeMap = new Dictionary<string, Attribute>();

		private void Start()
		{
			_attributeMap.Add(nameof(Stamina).ToLower(), Stamina);
			_attributeMap.Add(nameof(SpellPower).ToLower(), SpellPower);
			_attributeMap.Add(nameof(Haste).ToLower(), Haste);
			_attributeMap.Add(nameof(CriticalStrikeRating).ToLower(), CriticalStrikeRating);
			_attributeMap.Add(nameof(Armor).ToLower(), Armor);
			_attributeMap.Add(nameof(MovementSpeed).ToLower(), MovementSpeed);
			_attributeMap.Add(nameof(JumpPower).ToLower(), JumpPower);
			_attributeMap.Add(nameof(RotationSpeed).ToLower(), RotationSpeed);
		}

		public Attribute Get(string attributeName)
		{
			return _attributeMap[attributeName.ToLower()];
		}
	}
}
