using LegendsViewer.Controls.Query.Attributes;

namespace LegendsViewer.Legends
{
    public class Population
    {
        public bool IsMainRace
        {
            get
            {
                return World.MainRaces.ContainsKey(Race);
            }
        }

        public bool IsOutcasts
        {
            get
            {
                return Race.NamePlural.ContainsIgnoreCase("Outcasts");
            }
        }

        public bool IsPrisoners
        {
            get
            {
                return Race.NamePlural.ContainsIgnoreCase("Prisoners");
            }
        }

        public bool IsSlaves
        {
            get
            {
                return Race.NamePlural.ContainsIgnoreCase("Slaves");
            }
        }

        public bool IsVisitors
        {
            get
            {
                return Race.NamePlural.ContainsIgnoreCase("Visitors");
            }
        }

        public bool IsAnimalPeople
        {
            get
            {
                return Race.NamePlural.ContainsIgnoreCase(" Men") && !IsSlaves && !IsPrisoners && !IsOutcasts && !IsVisitors;
            }
        }

        [AllowAdvancedSearch]
        public CreatureInfo Race { get; set; }
        [AllowAdvancedSearch]
        public int Count { get; set; }

        public Population(CreatureInfo type, int count)
        {
            Race = type;
            Count = count;
        }
    }
}
