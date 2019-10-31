using System;
using System.Collections.Generic;
using System.Text;

namespace CoreConsole.Data
{
    public class Person
    {
        public GeschlechtEnum Geschlecht { get; set; }

        public string Vorname { get; set; }

        public string Nachname { get; set; }

        public int Alter { get; set; }

        public override string ToString()
        {
            return $"{Nachname} {Vorname} ({Alter}J. /{Geschlecht})";
        }

        public string ToDateiString()
        {
            return $"{Vorname};{Nachname};{Alter};{Geschlecht}";
        }

        public static Person Parse(string str)
        {
            string[] values = str.Split(';');
            Person ret = new Person();
            ret.Vorname = values[0];
            ret.Nachname = values[1];
            ret.Alter = int.Parse(values[2]);
            ret.Geschlecht = (GeschlechtEnum)Enum.Parse(typeof(GeschlechtEnum), values[3]);
            return ret;
        }
    }

    public enum GeschlechtEnum
    {
        Maennlich, Weiblich
    }
}
