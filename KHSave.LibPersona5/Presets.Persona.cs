using KHSave.LibPersona5.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xe.BinaryMapper;

namespace KHSave.LibPersona5
{
    public static partial class Presets
    {
        public class Persona
        {
            [Data] public byte Unk00 { get; set; }
            [Data] public byte Unk01 { get; set; }
            [Data] public ArcanaType Arcana { get; set; }
            [Data] public byte Level { get; set; }
            [Data] public byte Strength { get; set; }
            [Data] public byte Magic { get; set; }
            [Data] public byte Endurance { get; set; }
            [Data] public byte Agility { get; set; }
            [Data] public byte Luck { get; set; }
            [Data] public byte Unk09 { get; set; }
            [Data] public byte Unk0a { get; set; }
            [Data] public byte Unk0b { get; set; }
            [Data] public byte Unk0c { get; set; }
            [Data] public byte Unk0d { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
            public List<ushort> Skills { get; set; }

            public override string ToString() =>
                $"{Unk00:X02} {Unk01:X02} {Level:D02} {Name}";
        }

        private class PersonaSkillset
        {
            [Data] public ushort Unk00 { get; set; }
            [Data] public ushort Unk02 { get; set; }
            [Data] public ushort Unk04 { get; set; }
            [Data(Count = 16)] public PersonaSkill[] Skills { get; set; }
        }

        private class PersonaSkill
        {
            [Data] public byte Level { get; set; }
            [Data] public byte Enabled { get; set; }
            [Data] public ushort SkillId { get; set; }
        }

        private static string GetResourceFileName(string fileName, bool isRoyal) => Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            $"Resources/Persona5/{(isRoyal ? "Royal" : "Vanilla")}_{fileName}");

        public static List<Persona> GetPersona(bool isRoyal)
        {
            var names = File.ReadAllLines(GetResourceFileName("Demon.txt", isRoyal));
            using (var stream = File.OpenRead(GetResourceFileName("Demon.bin", isRoyal)))
            {
                var length = stream.ReadInt32BE();
                var count = length / 14;

                var persona = Enumerable.Range(0, count)
                    .Select(_ => SavePersona5.Mapper.ReadObject<Persona>(stream))
                    .ToList();

                while ((stream.Position % 16) != 0)
                    stream.Position++;
                length = (stream.ReadByte() << 24) |
                    (stream.ReadByte() << 16) |
                    (stream.ReadByte() << 8) |
                    (stream.ReadByte() << 0);
                count = length / 70;
                var skillSets = Enumerable.Range(0, count)
                    .Select(_ => SavePersona5.Mapper.ReadObject<PersonaSkillset>(stream))
                    .ToList();

                count = Math.Min(count, persona.Count);
                for (var i = 0; i < count; i++)
                {
                    persona[i].Id = i;
                    persona[i].Name = i < names.Length ? names[i] : "Unused";
                    persona[i].Skills = skillSets[i].Skills
                        .Where(x => x.Enabled > 0)
                        .Select(x => x.SkillId)
                        .ToList();
                }

                return persona
                    .Where(x => (x.Unk01 & 8) != 8)
                    .ToList();
            }
        }
    }
}
