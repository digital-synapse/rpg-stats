using System;
using System.Collections.Generic;
using System.Text;

namespace RpgStatSystem
{
    public class Stats
    {
        public string Name { get; protected set; }
        public string Class { get; protected set; }
        public int TypeId { get; protected set; }

        // Base Attributes
        public float Strength { get; protected set; }
        public float Vitality { get; protected set; }
        public float Fortitude { get; protected set; }
        public float Dexterity { get; protected set; }
        public float Intelligence { get; protected set; }
        public float Charisma { get; protected set; }
        public float Willpower { get; protected set; }
        public float Luck { get; protected set; }
        public float Experience { get; protected set; }

        // Base Stats
        public float Level { get; protected set; }
        public float HitPoints { get; protected set; }
        public float MagicPoints { get; protected set; }
        public float Encumberance { get; protected set; }
        public float Stamina { get; protected set; }

        // Skills
        public float BladeWeapons { get; protected set; }
        public float BluntWeapons { get; protected set; }
        public float HandToHand { get; protected set; }
        public float Armorer { get; protected set; }
        public float Block { get; protected set; }
        public float HeavyArmor { get; protected set; }
        public float Athletics { get; protected set; }
        public float Acrobatics { get; protected set; }
        public float LightArmor { get; protected set; }
        public float Security { get; protected set; }
        public float Sneak { get; protected set; }
        public float Marksman { get; protected set; }
        public float Merchantile { get; protected set; }
        public float Speechcraft { get; protected set; }
        public float Illusion { get; protected set; }
        public float Alchemy { get; protected set; }
        public float Conjuration { get; protected set; }
        public float Mysticism { get; protected set; }
        public float Alteration { get; protected set; }
        public float Destruction { get; protected set; }
        public float Restoration { get; protected set; }

        // Skill Experience
        public float BladeWeaponsXP { get; protected set; }
        public float BluntWeaponsXP { get; protected set; }
        public float HandToHandXP { get; protected set; }
        public float ArmorerXP { get; protected set; }
        public float BlockXP { get; protected set; }
        public float HeavyArmorXP { get; protected set; }
        public float AthleticsXP { get; protected set; }
        public float AcrobaticsXP { get; protected set; }
        public float LightArmorXP { get; protected set; }
        public float SecurityXP { get; protected set; }
        public float SneakXP { get; protected set; }
        public float MarksmanXP { get; protected set; }
        public float MerchantileXP { get; protected set; }
        public float SpeechcraftXP { get; protected set; }
        public float IllusionXP { get; protected set; }
        public float AlchemyXP { get; protected set; }
        public float ConjurationXP { get; protected set; }
        public float MysticismXP { get; protected set; }
        public float AlterationXP { get; protected set; }
        public float DestructionXP { get; protected set; }
        public float RestorationXP { get; protected set; }
    }
}
