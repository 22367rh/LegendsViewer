﻿using System;
using System.Collections.Generic;
using System.Linq;
using LegendsViewer.Legends.Parser;
using LegendsViewer.Legends.WorldObjects;

namespace LegendsViewer.Legends.Events
{
    public class Gamble : WorldEvent
    {
        public int StructureId { get; set; }
        public Structure Structure { get; set; }
        public Site Site { get; set; }
        public WorldRegion Region { get; set; }
        public UndergroundRegion UndergroundRegion { get; set; }
        public HistoricalFigure Gambler { get; set; }
        public int OldAccount { get; set; }
        public int NewAccount { get; set; }

        public Gamble(List<Property> properties, World world) : base(properties, world)
        {
            foreach (Property property in properties)
            {
                switch (property.Name)
                {
                    case "site_id": Site = world.GetSite(Convert.ToInt32(property.Value)); break;
                    case "subregion_id": Region = world.GetRegion(Convert.ToInt32(property.Value)); break;
                    case "feature_layer_id": UndergroundRegion = world.GetUndergroundRegion(Convert.ToInt32(property.Value)); break;
                    case "old_account": OldAccount = Convert.ToInt32(property.Value); break;
                    case "new_account": NewAccount = Convert.ToInt32(property.Value); break;
                    case "gambler_hfid": Gambler = world.GetHistoricalFigure(Convert.ToInt32(property.Value)); break;
                    case "structure_id": StructureId = Convert.ToInt32(property.Value); break;
                }
            }

            if (Site != null)
            {
                Structure = Site.Structures.Find(structure => structure.Id == StructureId);
            }

            Site.AddEvent(this);
            Region.AddEvent(this);
            UndergroundRegion.AddEvent(this);
            Gambler.AddEvent(this);
            Structure.AddEvent(this);
        }

        public override string Print(bool link = true, DwarfObject pov = null)
        {
            string eventString = GetYearTime();
            eventString += Gambler.ToLink(link, pov, this);
            // same ranges like in "trade" event
            var balance = NewAccount - OldAccount;
            if (balance >= 5000)
            {
                eventString += " made a fortune";
            }
            else if (balance >= 1000)
            {
                eventString += " did well";
            }
            else if (balance <= -1000)
            {
                eventString += " did poorly";
            }
            else if (balance <= -5000)
            {
                eventString += " lost a fortune";
            }
            else
            {
                eventString += " broke even";
            }
            eventString += " gambling";
            if (Site != null)
            {
                eventString += " in ";
                eventString += Site.ToLink(link, pov, this);
            }
            else if (Region != null)
            {
                eventString += " in ";
                eventString += Region.ToLink(link, pov, this);
            }
            else if (UndergroundRegion != null)
            {
                eventString += " in ";
                eventString += UndergroundRegion.ToLink(link, pov, this);
            }
            if (Structure != null)
            {
                eventString += " at ";
                eventString += Structure.ToLink(link, pov, this);
            }

            eventString += PrintParentCollection(link, pov);
            eventString += ".";
            return eventString;
        }
    }
}
