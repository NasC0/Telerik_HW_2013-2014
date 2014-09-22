using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class ExtendedInteractionManager : InteractionManager
    {
        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(commandWords[2], actor);
                    break;
                case "craft":
                    HandleCraftInteraction(commandWords, actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            switch (commandWords[2])
            {
                case "armor":
                    HandleArmorCrafting(commandWords[3], actor);
                    break;
                case "weapon":
                    HandleWeaponCrafting(commandWords[3], actor);
                    break;
                default:
                    break;
            }
        }

        private void HandleArmorCrafting(string armorName, Person actor)
        {
            bool actorHasIron = false;

            foreach (Item inventoryItem in actor.ListInventory())
            {
                if (inventoryItem.ItemType == ItemType.Iron)
                {
                    actorHasIron = true;
                    break;
                }
            }

            if (actorHasIron)
            {
                base.AddToPerson(actor, new Armor(armorName, null));
            }
        }

        private void HandleWeaponCrafting(string weaponName, Person actor)
        {
            bool actorHasIron = false;
            bool actorHasWood = false;

            foreach (Item inventoryItem in actor.ListInventory())
            {
                if (inventoryItem.ItemType == ItemType.Iron)
                {
                    actorHasIron = true;

                    if (actorHasIron && actorHasWood)
                    {
                        break;
                    }
                }

                if (inventoryItem.ItemType == ItemType.Wood)
                {
                    actorHasWood = true;

                    if (actorHasIron && actorHasWood)
                    {
                        break;
                    }
                }
            }

            if (actorHasIron && actorHasWood)
            {
                base.AddToPerson(actor, new Weapon(weaponName, null));
            }
        }

        private void HandleGatherInteraction(string itemName, Person actor)
        {
            if (actor.Location is IGatheringLocation)
            {
                bool hasRequiredItem = false;

                foreach (Item inventoryItem in actor.ListInventory())
                {
                    if (inventoryItem.ItemType == (actor.Location as IGatheringLocation).RequiredItem)
                    {
                        hasRequiredItem = true;
                        break;
                    }
                }

                if (hasRequiredItem)
                {
                    base.AddToPerson(actor, (actor.Location as IGatheringLocation).ProduceItem(itemName));
                }
            }
        }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }

            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "forest":
                    location = new Forest(locationName);
                    break;
                case "mine":
                    location = new Mine(locationName);
                    break;
                default:
                    location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }

            return location;
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }

            return person;
        }
    }
}
