using System;
using System.Collections.Generic;

namespace SD_725_Final.Models
{
    public enum Race
    {
        Human,
        Elf,
        Dwarf,
        Halfling,
        Dragonborn,
        Gnome,
        HalfElf,
        HalfOrc,
        Tiefling
    }
    public enum Class
    {
        Barbarian,
        Bard,
        Cleric,
        Druid,
        Fighter,
        Monk,
        Paladin,
        Ranger,
        Rogue,
        Sorcerer,
        Warlock,
        Wizard
    }
    public class Character
    {
        public string Name { get; set; }
        public Race SelectedRace { get; set; }
        public Class SelectedClass { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public int HitPoints { get; set; }
        private static readonly Dictionary<Race, int[]> RaceAbilityBonuses = new()
{
{ Race.Human, new[] { 1, 1, 1, 1, 1, 1 } },
{ Race.Elf, new[] { 0, 2, 0, 0, 0, 1 } },
{ Race.Dwarf, new[] { 0, 0, 2, 0, 0, 0 } },
{ Race.Halfling, new[] { 0, 2, 0, 0, 0, 0 } },
{ Race.Dragonborn, new[] { 2, 0, 0, 0, 0, 0 } },
{ Race.Gnome, new[] { 0, 0, 0, 2, 0, 1 } },
{ Race.HalfElf, new[] { 0, 0, 0, 0, 1, 2 } },
{ Race.HalfOrc, new[] { 2, 0, 1, 0, 0, 0 } },
{ Race.Tiefling, new[] { 0, 0, 0, 0, 1, 2 } },
};
        public void RollAbilities()
        {
            Strength = RollDice() + GetRaceBonus(0);
            Dexterity = RollDice() + GetRaceBonus(1);
            Constitution = RollDice() + GetRaceBonus(2);
            Intelligence = RollDice() + GetRaceBonus(3);
            Wisdom = RollDice() + GetRaceBonus(4);
            Charisma = RollDice() + GetRaceBonus(5);
            HitPoints = RollDice();
        }

        private int GetRaceBonus(int index)
        {
            return RaceAbilityBonuses.TryGetValue(SelectedRace, out var bonuses) ? bonuses[index] : 0;
    }
    private int RollDice()
    {
        Random rand = new Random();
        int[] rolls = new int[4];
        for (int i = 0; i < 4; i++)
        {
            rolls[i] = rand.Next(1, 7);
        }
        Array.Sort(rolls);
        return rolls[1] + rolls[2] + rolls[3]; // Sum the highest 3 rolls
    }
}
}