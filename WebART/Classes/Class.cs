using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebART.Classes
{
    public enum Vids
    {
        doc, person, reflect, masterskaya, participation
    }

    public abstract class KeyValueBD
    {
        public Vids vid;
        public int id = Int32.MinValue;
        public string stringID;
        public string name;
        public object GetKey()
        {
            if (stringID != null)
            {
                return stringID;
            }
            return id;
        }
        public abstract string GetName();
    }
    public class Person : KeyValueBD
    {
        public string birth;
        public string city;
        public string school;
        public int masterskaya;
        public override string GetName()
        {
            return name;
        }
    }
    public class Reflect : KeyValueBD
    {
        public int toPerson;
        public int toDoc;
        public override string GetName()
        {
            return null;
        }
    }
    public class Pasrticipation : KeyValueBD
    {
        public int member;
        public int inOrg;
        public override string GetName()
        {
            return null;
        }
    }
    public class Mastersk : KeyValueBD
    {
        public string year;
        public string description;
        public override string GetName()
        {
            return name;
        }
    }
    public class Doc : KeyValueBD
    {
        public string description;
        public string date;
        public string contentType;
        public string uri;
        public override string GetName()
        {
            if (name == null)
            {
                return "DOCUMENT";
            }
            return name;
        }
    }


}
