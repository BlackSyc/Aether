using Aether.Core.Attributes;
using Syc.Combat;
using UnityEngine;

namespace Aether.Combat
{
	public class BasicCombatSystem : CombatMonoSystem
	{
		[SerializeField] protected ScryerAttributes scryerAttributes;

		[SerializeField] protected bool canBeTargeted;
		public override object Allegiance => gameObject.layer;
		public override ICombatAttributes AttributeSystem => scryerAttributes;
		public override Transform Origin => transform;

		public override bool CanBeTargeted
		{
			get => canBeTargeted;
			set => canBeTargeted = value;
		}
	}
}