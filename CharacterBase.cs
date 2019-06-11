using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgStatSystem
{
    public class CharacterBase : Stats
    {
        // override this for additional initialization. called after factory methods.
        protected virtual void Init() { }

        public Action<float> AttributeLevelStrategy { get; protected set; }
        public Action<float> SkillLevelStrategy { get; protected set; }

        // Factories - roll new characters from character "class"
        public static T Fighter<T>(string name = null, float clvl = 1.0f) where T : Character, new()
        {
            var c = new T();
            c.TypeId = 1;

            if (name == null) c.Name = "Fighter";
            else c.Name = name;
            c.Class = "Fighter";
           
            c.AttributeLevelStrategy = (pointPool) => {
                float pts = pointPool;
                while (pts > 0)
                {
                    c.Strength += rnd.Distribution(0.4f, pointPool, ref pts);
                    c.Vitality += rnd.Distribution(0.3f, pointPool, ref pts);
                    c.Fortitude += rnd.Distribution(0.2f, pointPool, ref pts);
                    c.Dexterity += rnd.Distribution(0.1f, pointPool, ref pts);
                    c.Luck += rnd.Distribution(0.01f, pointPool, ref pts);
                    c.Intelligence += rnd.Distribution(0.01f, pointPool, ref pts);
                    c.Charisma += rnd.Distribution(0.01f, pointPool, ref pts);
                    c.Willpower += rnd.Distribution(0.01f, pointPool, ref pts);
                }
            };
            c.AttributeLevelStrategy(NEW_CHARACTER_MAX_ATTRIBUTE_POINTS);
            c.StatsLevelStrategy(clvl);

            c.SkillLevelStrategy = (pointPool) =>
            {
                float points = pointPool;
                while (points > 0)
                {
                    c.BladeWeapons += rnd.Distribution(0.2f, pointPool, ref points);
                    c.BluntWeapons += rnd.Distribution(0.2f, pointPool, ref points);
                    c.Block += rnd.Distribution(0.3f, pointPool, ref points);
                    c.HeavyArmor += rnd.Distribution(0.2f, pointPool, ref points);
                    c.LightArmor += rnd.Distribution(0.1f, pointPool, ref points);
                    c.HandToHand += rnd.Distribution(0.01f, pointPool, ref points);
                    c.Athletics += rnd.Distribution(0.01f, pointPool, ref points);
                    c.Armorer += rnd.Distribution(0.01f, pointPool, ref points);
                    c.Acrobatics += rnd.Distribution(0.01f, pointPool, ref points);
                    c.Security += rnd.Distribution(0.01f, pointPool, ref points);
                    c.Sneak += rnd.Distribution(0.01f, pointPool, ref points);
                    c.Marksman += rnd.Distribution(0.01f, pointPool, ref points);
                    c.Merchantile += rnd.Distribution(0.01f, pointPool, ref points);
                    c.Speechcraft += rnd.Distribution(0.01f, pointPool, ref points);
                    c.Illusion += rnd.Distribution(0.01f, pointPool, ref points);
                    c.Alchemy += rnd.Distribution(0.01f, pointPool, ref points);
                    c.Conjuration += rnd.Distribution(0.01f, pointPool, ref points);
                    c.Mysticism += rnd.Distribution(0.01f, pointPool, ref points);
                    c.Alteration += rnd.Distribution(0.01f, pointPool, ref points);
                    c.Destruction += rnd.Distribution(0.01f, pointPool, ref points);
                    c.Restoration += rnd.Distribution(0.01f, pointPool, ref points);
                }
            };
            c.SkillLevelStrategy(NEW_CHARACTER_MAX_SKILL_POINTS);

            c.Init();
            return c;
        }

        public static T Mage<T>(string name = null, float clvl = 1.0f) where T : Character, new()
        {
            var c = new T();
            c.TypeId = 2;
            if (name == null) c.Name = "Mage";
            else c.Name = name;
            c.Class = "Mage";
            c.AttributeLevelStrategy = (pointsPool) =>
            {
                float points = pointsPool;
                while (points > 0)
                {
                    c.Intelligence += rnd.Distribution(0.4f, pointsPool, ref points);
                    c.Vitality += rnd.Distribution(0.3f, pointsPool, ref points);
                    c.Willpower += rnd.Distribution(0.1f, pointsPool, ref points);
                    c.Fortitude += rnd.Distribution(0.1f, pointsPool, ref points);
                    c.Dexterity += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Luck += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Strength += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Charisma += rnd.Distribution(0.01f, pointsPool, ref points);
                }
            };
            c.AttributeLevelStrategy(NEW_CHARACTER_MAX_ATTRIBUTE_POINTS);
            c.StatsLevelStrategy(clvl);

            c.SkillLevelStrategy = (pointsPool) =>
            {
                float points = pointsPool;
                while (points > 0)
                {
                    c.Destruction += rnd.Distribution(0.4f, pointsPool, ref points);
                    c.Restoration += rnd.Distribution(0.2f, pointsPool, ref points);
                    c.Block += rnd.Distribution(0.1f, pointsPool, ref points);
                    c.LightArmor += rnd.Distribution(0.1f, pointsPool, ref points);
                    c.Illusion += rnd.Distribution(0.05f, pointsPool, ref points);
                    c.Alchemy += rnd.Distribution(0.05f, pointsPool, ref points);
                    c.Conjuration += rnd.Distribution(0.05f, pointsPool, ref points);
                    c.Mysticism += rnd.Distribution(0.05f, pointsPool, ref points);
                    c.Alteration += rnd.Distribution(0.05f, pointsPool, ref points);
                    c.HandToHand += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Athletics += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Armorer += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Acrobatics += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Security += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Sneak += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Marksman += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Merchantile += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Speechcraft += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.BladeWeapons += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.BluntWeapons += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.HeavyArmor += rnd.Distribution(0.01f, pointsPool, ref points);
                }
            };
            c.SkillLevelStrategy(NEW_CHARACTER_MAX_SKILL_POINTS);

            c.Init();
            return c;
        }

        public static T Ranger<T>(string name = null, float clvl = 1.0f) where T : Character, new()
        {
            var c = new T();
            c.TypeId = 3;
            if (name == null) c.Name = "Ranger";
            else c.Name = name;
            c.Class = "Ranger";
            c.AttributeLevelStrategy = (pointsPool) =>
            {
                float points = pointsPool;
                while (points > 0)
                {
                    c.Dexterity += rnd.Distribution(0.3f, pointsPool, ref points);
                    c.Vitality += rnd.Distribution(0.2f, pointsPool, ref points);
                    c.Willpower += rnd.Distribution(0.1f, pointsPool, ref points);
                    c.Fortitude += rnd.Distribution(0.2f, pointsPool, ref points);
                    c.Intelligence += rnd.Distribution(0.1f, pointsPool, ref points);
                    c.Luck += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Strength += rnd.Distribution(0.1f, pointsPool, ref points);
                    c.Charisma += rnd.Distribution(0.01f, pointsPool, ref points);
                }
            };
            c.AttributeLevelStrategy(NEW_CHARACTER_MAX_ATTRIBUTE_POINTS);
            c.StatsLevelStrategy(clvl);

            c.SkillLevelStrategy = (pointsPool) =>
            {
                float points = pointsPool;
                while (points > 0)
                {
                    c.Marksman += rnd.Distribution(0.4f, pointsPool, ref points);
                    c.LightArmor += rnd.Distribution(0.3f, pointsPool, ref points);
                    c.Block += rnd.Distribution(0.1f, pointsPool, ref points);
                    c.Athletics += rnd.Distribution(0.1f, pointsPool, ref points);
                    c.Illusion += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Alchemy += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Conjuration += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Mysticism += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Alteration += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.HandToHand += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Armorer += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Acrobatics += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Security += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Sneak += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Merchantile += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Speechcraft += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.BladeWeapons += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.BluntWeapons += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.HeavyArmor += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Destruction += rnd.Distribution(0.01f, pointsPool, ref points);
                    c.Restoration += rnd.Distribution(0.01f, pointsPool, ref points);
                }
            };
            c.SkillLevelStrategy(NEW_CHARACTER_MAX_SKILL_POINTS);

            c.Init();
            return c;
        }

        protected static Random rnd = new Random();
        private const float NEW_CHARACTER_MAX_ATTRIBUTE_POINTS = 10;
        private const float NEW_CHARACTER_MAX_SKILL_POINTS = 10;

        protected void StatsLevelStrategy(float clvl)
        {
            var c = this;
            c.Level = clvl;
            c.HitPoints = ((c.Strength*.05f + 1) * 0.1f) * (c.Vitality*.08f + 1) + 10;
            c.MagicPoints = ((c.Willpower*.05f + 1) * 0.1f) * (c.Intelligence*.08f + 1);
            c.Encumberance = ((c.Fortitude*.1f + 1) * 0.05f) * ((c.Strength*.1f + 1) +1);
            c.Stamina = ((c.Vitality*.1f + 1) * 0.1f) * (c.Strength *.1f + 1);
        }

        protected void SkillExperienceStrategy(float pointsPool)
        {
            var c = this;
            float points = pointsPool;

            var avg = Experience / 21;
            
            while (points > 0)
            {
                c.Marksman += rnd.Distribution(((MarksmanXP / avg) - 1).Clip(0, 1), pointsPool, ref points);
                c.LightArmor += rnd.Distribution(((LightArmorXP / avg) - 1).Clip(0, 1), pointsPool, ref points);
                c.Block += rnd.Distribution(((BlockXP / avg) - 1).Clip(0, 1), pointsPool, ref points);
                c.Athletics += rnd.Distribution(((AthleticsXP / avg) - 1).Clip(0, 1), pointsPool, ref points);
                c.Illusion += rnd.Distribution(((IllusionXP / avg) - 1).Clip(0, 1), pointsPool, ref points);
                c.Alchemy += rnd.Distribution(((AlchemyXP / avg) - 1).Clip(0, 1), pointsPool, ref points);
                c.Conjuration += rnd.Distribution(((ConjurationXP / avg) - 1).Clip(0, 1), pointsPool, ref points);
                c.Mysticism += rnd.Distribution(((MysticismXP / avg) - 1).Clip(0, 1), pointsPool, ref points);
                c.Alteration += rnd.Distribution(((AlterationXP / avg) - 1).Clip(0, 1), pointsPool, ref points);
                c.HandToHand += rnd.Distribution(((HandToHandXP / avg) - 1).Clip(0, 1), pointsPool, ref points);
                c.Armorer += rnd.Distribution(((ArmorerXP / avg) - 1).Clip(0, 1), pointsPool, ref points);
                c.Acrobatics += rnd.Distribution(((AcrobaticsXP / avg) - 1).Clip(0, 1), pointsPool, ref points);
                c.Security += rnd.Distribution(((SecurityXP / avg) - 1).Clip(0, 1), pointsPool, ref points);
                c.Sneak += rnd.Distribution(((SneakXP / avg) - 1).Clip(0, 1), pointsPool, ref points);
                c.Merchantile += rnd.Distribution(((MerchantileXP / avg) - 1).Clip(0, 1), pointsPool, ref points);
                c.Speechcraft += rnd.Distribution(((SpeechcraftXP / avg) - 1).Clip(0, 1), pointsPool, ref points);
                c.BladeWeapons += rnd.Distribution(((BladeWeaponsXP / avg) - 1).Clip(0, 1), pointsPool, ref points);
                c.BluntWeapons += rnd.Distribution(((BluntWeaponsXP / avg) - 1).Clip(0, 1), pointsPool, ref points);
                c.HeavyArmor += rnd.Distribution(((HeavyArmorXP / avg) - 1).Clip(0, 1), pointsPool, ref points);
                c.Destruction += rnd.Distribution(((DestructionXP / avg) - 1).Clip(0, 1), pointsPool, ref points);
                c.Restoration += rnd.Distribution(((RestorationXP / avg) - 1).Clip(0, 1), pointsPool, ref points);
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
        public string GetCharacterSheet()
        {
            return $@"-------------------------------------------
Name: {Name,18}
Class: {Class,14}
-------------------------------------------
Level: {Level,12}    BladeWeapons: {BladeWeapons,5:F1}
HitPoints: {HitPoints,8:F1}    BluntWeapons: {BluntWeapons,5:F1}
MagicPoints: {MagicPoints,6:F1}    HandToHand: {HandToHand,7:F1}
Encumberance: {Encumberance,5:F1}    Armorer: {Armorer,10:F1}
Stamina: {Stamina,10:F1}    Block: {Block,12:F1}
Experience: {Experience,7:F1}    HeavyArmor: {HeavyArmor,7:F1}
                       Athletics: {Athletics,8:F1}
Strength: {Strength,9:F1}    Acrobatics: {Acrobatics,7:F1}
Vitality: {Vitality,9:F1}    LightArmor: {LightArmor,7:F1}
Fortitude: {Fortitude,8:F1}    Security: {Security,9:F1}
Dexterity: {Dexterity,8:F1}    Sneak: {Sneak,12:F1}
Intelligence: {Intelligence,5:F1}    Marksman: {Marksman,9:F1}
Charisma: {Charisma,9:F1}    Merchantile: {Merchantile,6:F1}
Willpower: {Willpower,8:F1}    Speechcraft: {Speechcraft,6:F1}
Luck: {Luck,13:F1}    Illusion: {Illusion,9:F1}
                       Alchemy: {Alchemy,10:F1}
                       Conjuration: {Conjuration,6:F1}
                       Mysticism: {Mysticism,8:F1}
                       Alteration: {Alteration,7:F1}
                       Destrution: {Destruction,7:F1}
                       Restoration: {Restoration,6:F1}
";
        }

        public List<Stats> StatsHistory { get; protected set; } = new List<Stats>();
    }
}
