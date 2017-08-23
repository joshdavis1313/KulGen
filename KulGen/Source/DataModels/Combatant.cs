using System;

namespace Smash.Source.DataModels
{
	public class Combatant
	{
		public string Name { get; set; }
		public string PlayerName { get; set; }
		public int Health { get; set; }
		public int MaxHealth { get; set; }
		public int Initiative { get; set; }
		public int ArmorClass { get; set; }
		public int PassivePerception { get; set; }

		public Combatant()
		{
			Name = "";
			MaxHealth = 0;
			Health = 0;
			Initiative = 0;
			ArmorClass = 0;
			PassivePerception = 0;
		}
	}
}
