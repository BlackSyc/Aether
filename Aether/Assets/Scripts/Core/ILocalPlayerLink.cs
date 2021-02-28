namespace Aether.Core
{
	public interface ILocalPlayerLink
	{
		void OnLocalPlayerLinked(Player player);

		void OnLocalPlayerUnlinked(Player player);
	}
}