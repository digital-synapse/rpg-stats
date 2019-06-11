using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgStatSystem
{
    public class Character : CharacterBase
    {
        public IBattleLog BattleLog { get; protected set; }

        protected override void Init()
        {
            base.Init();
            HP = HitPoints;
        }
        
        // state
        public float HP { get; protected set; }
        public float MP { get; protected set; }
        public bool Dead { get; private set; }

        // position
        public float X { get; protected set; }
        public float Y { get; protected set; }
        public float Z { get; protected set; }
        public float Rotation { get; protected set; }
        public float Velocity { get; protected set; }

        // equips
        public Weapon LeftHand { get; private set; }
        public Weapon RightHand { get; private set; }
        public Armor Chest { get; private set; }

        
        public virtual void Update(float frameTime, long frame, TimeSpan runTime)
        {
        }

        public void MoveTo(float x, float y, float z=0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float Distance(Character enemy)
        {
            return (float)Math.Sqrt(Math.Pow((X - enemy.X), 2) + Math.Pow((Y - enemy.Y), 2));
        }

        public void Attack (Character enemy)
        {
            var distance = Distance(enemy);

            if (distance > RightHand.Range)
            {
                enemy.Absorb(0); // missed!
                return;
            }

            // 5% chance to get a critical hit
            var crit= rnd.NextDouble() > 0.95 ? 2.0f : 1.0f;
                        
            // 10% chance to miss
            var miss = rnd.NextDouble() < 0.1 ? 0.0f : 1.0f;

            // damage calculated from attackers equipped weapon and base stats
            // resistance calculated from defenders armor rating a resistance
            var maxBladeDamage = RightHand.CleveDamage * BladeWeapons;
            var maxBladeResist = enemy.Chest.MaxCleveResistance;
            var maxBluntDamage = RightHand.BashDamage * BluntWeapons;
            var maxBluntResist = enemy.Chest.MaxBashResistance;
            var maxHandToHandDamage = RightHand.PhysicalDamage * HandToHand;
            var maxHandToHandResist = enemy.Chest.MaxPhysicalResistance;
            var maxMarksmanDamage = RightHand.PhysicalDamage * Marksman;
            var maxMarksmanResist = enemy.Chest.MaxPhysicalResistance;
            var maxLightningDamage = RightHand.LightningDamage * Destruction;
            var maxLightningResist = enemy.Chest.MaxLightningResistance;
            var maxFireDamage = RightHand.FireDamage * Destruction;
            var maxFireResist = enemy.Chest.MaxFireResistance;
            var maxPoisonDamage = RightHand.PoisonDamage * Destruction;
            var maxPoisonResist = enemy.Chest.MaxPoisonResistance;
            var maxMagicDamage = RightHand.MagicDamage * Destruction;
            var maxMagicResist = enemy.Chest.MaxMagicResistance;

            // damage reduced by enemy armor rating
            var bladeDamage = rnd.Range((RightHand.CleveDamage - enemy.Chest.CleveResistance).Clip(), (maxBladeDamage - maxBladeResist).Clip()) * crit * miss;
            var bluntDamage = rnd.Range((RightHand.BashDamage - enemy.Chest.BashResistance).Clip(), (maxBluntDamage - maxBluntResist).Clip()) * crit * miss;
            var handToHandDamage = rnd.Range((RightHand.PhysicalDamage - enemy.Chest.PhysicalResistance).Clip(), (maxHandToHandDamage - maxHandToHandResist).Clip()) * crit * miss;
            var marksmanDamage = rnd.Range((RightHand.PhysicalDamage - enemy.Chest.PhysicalResistance).Clip(), (maxMarksmanDamage - maxMarksmanResist).Clip()) * crit * miss;
            var lightningDamage = rnd.Range((RightHand.LightningDamage - enemy.Chest.LightningResistance).Clip(), (maxLightningDamage - maxLightningResist).Clip()) * crit * miss;
            var fireDamage = rnd.Range((RightHand.FireDamage - enemy.Chest.FireResistance).Clip(), (maxFireDamage - maxFireResist).Clip()) * crit * miss;
            var poisonDamage = rnd.Range((RightHand.PoisonDamage - enemy.Chest.PoisonResistance).Clip(), (maxPoisonDamage - maxPoisonResist).Clip()) * crit * miss;
            var magicDamage= rnd.Range( (RightHand.MagicDamage - enemy.Chest.MagicResistance).Clip(), (maxMagicDamage - maxMagicResist).Clip()) * crit * miss;            

            // skill experience based on damage multiplied by challenge
            var bladeWeaponsXP = bladeDamage * (maxBladeResist+1);
            var bluntWeaponsXP = bluntDamage * (maxBluntResist+1);
            var handToHandXP = handToHandDamage * (maxHandToHandResist+1);
            var marksmanXP = marksmanDamage * (maxMarksmanResist+1);
            var destructionXP = magicDamage * (maxMarksmanResist+1);
            var totalXP = ((bladeWeaponsXP + bluntWeaponsXP + handToHandXP + marksmanXP + destructionXP) / Level)*5;

            Experience += totalXP;
            BladeWeaponsXP += bladeWeaponsXP;
            BluntWeaponsXP += bluntWeaponsXP;
            HandToHandXP += handToHandXP;
            MarksmanXP += marksmanXP;
            DestructionXP += destructionXP;

            if (BattleLog != null)
            {
                if (crit > 1 && miss > 0)
                    BattleLog.WriteLine($"{Name} made a critical hit! ");
                else if (miss < 1)
                    BattleLog.WriteLine($"{Name} attacked but missed! ");
                else
                    BattleLog.WriteLine($"{Name} attacks with {RightHand.Name}. ");
            }

            enemy.Absorb( bladeDamage , bluntDamage , handToHandDamage , marksmanDamage , lightningDamage , fireDamage , poisonDamage , magicDamage);
        }

        public void Absorb (float bladeDamage=0, float bluntDamage = 0, float handToHandDamage = 0, float marksmanDamage = 0, float lightningDamage = 0, float fireDamage = 0, float poisonDamage = 0, float magicDamage = 0)
        {
            var dmg = bladeDamage + bluntDamage + handToHandDamage + marksmanDamage + lightningDamage + fireDamage + poisonDamage + magicDamage;

            // skill experience based on damage multiplied by challenge
            var armorXP = Chest.TotalResistance * dmg;
            if (Chest.Type == ArmorType.HeavyArmor)
                HeavyArmorXP += armorXP;
            else if (Chest.Type == ArmorType.LightArmor)
                LightArmorXP += armorXP;
            Experience += (armorXP / Level) * 5;

            if (dmg > 0 && BattleLog != null) BattleLog.WriteLine($"{Name} took {dmg} damage.");

            HP -= dmg;
            if (HP < 0)
            {
                HP = 0;
                BattleLog?.WriteLine($"{Name} is dead!");
                Dead = true;
            }
        }

        /// <summary>
        /// Checks experience to see if the CLVL needs to raise
        /// </summary>
        /// <returns>true if character level increased</returns>
        public bool LevelUp()
        {
            bool isLevelUp = false;
            var req = Math.Pow((Level + 1.0f), 1.2f);
            //var req = Level * 15;
            if (Experience > req)
            {
                isLevelUp = true;
                Level += 1;
                AttributeLevelStrategy(10 * (1+ Level * 0.333f));
                SkillExperienceStrategy(10 * (1 + Level * 0.1f));
                StatsLevelStrategy(Level);
                BattleLog?.WriteLine($"{Name} leveled up to level {Level}!");
                HP = HitPoints;
                StatsHistory.Add((Stats)MemberwiseClone());
            }
            return isLevelUp;
        }


        public void Equip (Weapon weapon)
        {
            if (RightHand == null) RightHand = weapon;
            else LeftHand = weapon;
        }
        public void Equip (Armor armor)
        {
            if (Chest == null) Chest = armor;
        }
    }
}
