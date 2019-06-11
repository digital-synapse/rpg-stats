using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgStatSystem
{
    public enum ArmorType
    {
        HeavyArmor,
        LightArmor
    }
    public class Armor
    {
        public string Name { get; private set; }
        public float Rating { get; private set; }
        public float CleveResistance { get; private set; }
        public float BashResistance { get; private set; }
        public float PhysicalResistance { get; private set; }
        public float FireResistance { get; private set; }
        public float LightningResistance { get; private set; }
        public float PoisonResistance { get; private set; }
        public float MagicResistance { get; private set; }
        public float Durability { get; private set; }
        public float Weight { get; private set; }
        public ArmorType Type { get; private set; }
        public float TotalResistance => CleveResistance + BashResistance + PhysicalResistance + FireResistance + LightningResistance + PoisonResistance + MagicResistance;
        public float MaxCleveResistance => Rating * CleveResistance;
        public float MaxBashResistance => Rating * BashResistance;
        public float MaxPhysicalResistance => Rating * PhysicalResistance;
        public float MaxFireResistance => Rating * FireResistance;
        public float MaxPoisonResistance => Rating * PoisonResistance;
        public float MaxMagicResistance => Rating * MagicResistance;
        public float MaxLightningResistance => Rating * LightningResistance;
        public float MaxTotalResistance => MaxCleveResistance + MaxBashResistance + MaxPoisonResistance + MaxFireResistance + MaxPoisonResistance + MaxLightningResistance + MaxMagicResistance;
        public static Armor LightArmor()
        {
            var a = new Armor();
            a.Name = "Light Armor";
            a.Durability = 1;
            a.Rating = 1;
            a.CleveResistance = .5f;
            a.BashResistance = .5f;
            a.PhysicalResistance = 1;
            a.FireResistance = 0;
            a.LightningResistance = 0;
            a.PhysicalResistance = 0;
            a.MagicResistance = 0;
            a.Weight = 1;
            a.Type = ArmorType.LightArmor;
            return a;
        }

        public static Armor HeavyArmor()
        {
            var a = new Armor();
            a.Name = "Heavy Armor";
            a.Durability = 1;
            a.Rating = 1;
            a.CleveResistance = 1;
            a.BashResistance = 1;
            a.PhysicalResistance = 1;
            a.FireResistance = 0;
            a.LightningResistance = 0;
            a.PhysicalResistance = 0;
            a.MagicResistance = 0;
            a.Weight = 10;
            a.Type = ArmorType.HeavyArmor;
            return a;
        }
    }
}
