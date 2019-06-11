using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgStatSystem
{
    public class Weapon
    {
        public string Name { get; private set; }
        public float Range { get; private set; }
        public float CleveDamage { get; private set; }
        public float BashDamage { get; private set; }
        public float PhysicalDamage { get; private set; }
        public float FireDamage { get; private set; }
        public float LightningDamage { get; private set; }
        public float PoisonDamage { get; private set; }
        public float MagicDamage { get; private set; }
        public float AttacksPerSecond { get; private set; }
        public float Durability { get; private set; }
        public float Weight { get; private set; }

        public static Weapon Bow()
        {
            var w = new Weapon();
            w.Name = "Bow";
            w.Range = 10;
            w.CleveDamage = 0;
            w.BashDamage = 0;
            w.PhysicalDamage = 1;
            w.FireDamage = 0;
            w.LightningDamage = 0;
            w.PoisonDamage = 0;
            w.MagicDamage = 0;
            w.AttacksPerSecond = 2;
            w.Durability = 1;
            w.Weight = 1;
            return w;
        }

        public static Weapon MagicWand()
        {
            var w = new Weapon();
            w.Name = "Magic Wand";
            w.Range = 10;
            w.CleveDamage = 0;
            w.BashDamage = 0;
            w.PhysicalDamage = 0;
            w.FireDamage = 0;
            w.LightningDamage = 0;
            w.PoisonDamage = 0;
            w.MagicDamage = 1;
            w.AttacksPerSecond = 2;
            w.Durability = 1;
            w.Weight = 1;
            return w;
        }

        public static Weapon ShortSword()
        {
            var w = new Weapon();
            w.Name = "Short Sword";
            w.Range = 1;
            w.CleveDamage = 1;
            w.BashDamage = 0;
            w.PhysicalDamage = 0;
            w.FireDamage = 0;
            w.LightningDamage = 0;
            w.PoisonDamage = 0;
            w.MagicDamage = 0;
            w.AttacksPerSecond = 2;
            w.Durability = 1;
            w.Weight = 7;
            return w;
        }
    }

}
