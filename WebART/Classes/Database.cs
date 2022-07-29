using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace WebART.Classes
{
    public class Database
    {


        private static int nextID = 0;
       
        public static List<Classes.KeyValueBD> dataListFirst = new List<KeyValueBD>() {  new Classes.Mastersk() {id=SetNextID(),name="Отличаем Натали Портман от Киры Найтли", year="2022",description="Здесь учат робота отличать лица",vid=Vids.masterskaya},
            new Classes.Mastersk() {id=SetNextID(),name="Поколение Логики", year="2022",description="Здесь изучают С",vid=Vids.masterskaya},
            new Classes.Mastersk() {id=SetNextID(),name="Много бит тому назад", year="2022",description="Здесь изучают историю компов",vid=Vids.masterskaya},
            new Classes.Mastersk() {id=SetNextID(),name="Сгенерируй их всех!", year="2022",description="Здесь занимаются покемонами",vid=Vids.masterskaya},
            new Classes.Mastersk() {id=SetNextID(),name="Вставайте, граф, вас ждут великие дела!", year="2022",description="Здесь изучают Lisp",vid=Vids.masterskaya},
            new Classes.Mastersk() {id=SetNextID(),name="Черепашка и программирование", year="2022",description="Здесь изучают Logo",vid=Vids.masterskaya},
            new Classes.Mastersk() {id=SetNextID(),name="ЛШЮП Информбюро", year="2022",description="Здесь изучают Web-программирование",vid=Vids.masterskaya},
            new Classes.Mastersk() {id=SetNextID(),name="Обработка естественных языков на ДНК и белках", year="2022",description="Здесь также изучают биологию",vid=Vids.masterskaya},
            new Classes.Person(){name="Лихотворик Никита",id=SetNextID(),birth="2005-03-08",city="Бердск", masterskaya=7, school="6 лицей", vid=Vids.person },
            new Classes.Person(){name="Кулишкин Артём",id=SetNextID(),birth="когда-то",city="Новосибирск", masterskaya=7, school="НГУ", vid=Vids.person  },
            new Classes.Person(){name="Мельников Андрей",id=SetNextID(),birth="когда-то",city="Новосибирск", masterskaya=7, school="НГУ", vid=Vids.person  },
            new Classes.Person(){name="Ноговицин Михаил",id=SetNextID(),birth="когда-то",city="Бердск", masterskaya=7, school="6 лицей", vid=Vids.person  },
            new Classes.Person(){name="Маликов Павел",id=SetNextID(),birth="когда-то",city="Новосибирск", masterskaya=7, school="Кадетский Корпус", vid=Vids.person  },
            new Classes.Doc(){id=SetNextID(), name="Портрет", uri="/0002",  vid=Vids.doc},};
        static private void AddDefult()
        {
            nextID = 0;
            dataListFirst = new List<KeyValueBD>()
            {
            new Classes.Mastersk() {id=SetNextID(),name="Отличаем Натали Портман от Киры Найтли", year="2022",description="Здесь учат робота отличать лица",vid=Vids.masterskaya},
            new Classes.Mastersk() {id=SetNextID(),name="Поколение Логики", year="2022",description="Здесь изучают С",vid=Vids.masterskaya},
            new Classes.Mastersk() {id=SetNextID(),name="Много бит тому назад", year="2022",description="Здесь изучают историю компов",vid=Vids.masterskaya},
            new Classes.Mastersk() {id=SetNextID(),name="Сгенерируй их всех!", year="2022",description="Здесь занимаются покемонами",vid=Vids.masterskaya},
            new Classes.Mastersk() {id=SetNextID(),name="Вставайте, граф, вас ждут великие дела!", year="2022",description="Здесь изучают Lisp",vid=Vids.masterskaya},
            new Classes.Mastersk() {id=SetNextID(),name="Черепашка и программирование", year="2022",description="Здесь изучают Logo",vid=Vids.masterskaya},
            new Classes.Mastersk() {id=SetNextID(),name="ЛШЮП Информбюро", year="2022",description="Здесь изучают Web-программирование",vid=Vids.masterskaya},
            new Classes.Mastersk() {id=SetNextID(),name="Обработка естественных языков на ДНК и белках", year="2022",description="Здесь также изучают биологию",vid=Vids.masterskaya},
            new Classes.Person(){name="Лихотворик Никита",id=SetNextID(),birth="2005-03-08",city="Бердск", masterskaya=7, school="6 лицей", vid=Vids.person },
            new Classes.Person(){name="Кулишкин Артём",id=SetNextID(),birth="когда-то",city="Новосибирск", masterskaya=7, school="НГУ", vid=Vids.person  },
            new Classes.Person(){name="Мельников Андрей",id=SetNextID(),birth="когда-то",city="Новосибирск", masterskaya=7, school="НГУ", vid=Vids.person  },
            new Classes.Person(){name="Ноговицин Михаил",id=SetNextID(),birth="когда-то",city="Бердск", masterskaya=7, school="6 лицей", vid=Vids.person  },
            new Classes.Person(){name="Маликов Павел",id=SetNextID(),birth="когда-то",city="Новосибирск", masterskaya=7, school="Кадетский Корпус", vid=Vids.person  },
            new Classes.Doc(){id=SetNextID(), name="Портрет", uri="/0002",  vid=Vids.doc},
        };
        }

        //public static List<Classes.Person> persons = new List<Person>();




        public static int SetNextID()
        {

            nextID++;
            return nextID;
        }

        public static IEnumerable<Classes.Person> MasterFilter(int number)
        {
            IEnumerable<Classes.Person> FilterMasterskaya = dataListFirst
                .Where(x => x.vid == Vids.person)
                .Cast<Classes.Person>()
                .Where(x => x.masterskaya == number);
            return FilterMasterskaya;



        }
        public static KeyValueBD GetFromBD(int id)
        {
            KeyValueBD obj = dataListFirst
                .Where(x => x.id == id)
                .FirstOrDefault();
            return obj;
        }
        public static IEnumerable<KeyValueBD> GetFromBDString(string name)
        {
            name = name.ToLower();
            IEnumerable<KeyValueBD> obj = dataListFirst
                .Where(x => x.GetName() != null)
                .Where(x => x.GetName().ToLower().Contains(name));
            return obj;
        }
        public static IEnumerable<KeyValueBD> GetFromBDString(string name, IEnumerable<KeyValueBD> bd)
        {
            name = name.ToLower();
            IEnumerable<KeyValueBD> obj = bd
                .Where(x => x.GetName() != null)
                .Where(x => x.GetName().ToLower().Contains(name));
            return obj;
        }
        public static IEnumerable<Classes.Person> GetPeoplesOld(int idMastersOld)
        {
            List<Classes.Person> pers = new List<Person>();
            pers = dataListFirst
                .Where(x => x.vid == Vids.person)
                .Cast<Classes.Person>()
                .Where(x => x.masterskaya == idMastersOld).ToList();
            return pers.ToArray();
        }
        public static IEnumerable<KeyValueBD> Sorting(Vids vid)
        {
            return dataListFirst.Where(x => x.vid == vid);
        }
        public static Classes.Doc GetDoc(int id)
        {
            return dataListFirst.Where(x => x.vid == Vids.doc).Cast<Classes.Doc>().Where(x => x.id == id).FirstOrDefault();
        }
        public static IEnumerable<Classes.Person> GetPersonsDoc(int idDoc)
        {
            IEnumerable<Classes.Reflect> refl = dataListFirst
                .Where(x => x.vid == Vids.reflect)
                .Cast<Classes.Reflect>()
                .Where(x => x.toDoc == idDoc);
            List<Classes.Person> pers = new List<Person>();
            foreach (Classes.Reflect r in refl)
            {
                pers.Add(dataListFirst
                    .Where(x => x.vid == Vids.person)
                    .Cast<Classes.Person>()
                    .Where(x => x.id == r.toPerson)
                    .FirstOrDefault());
            }
            return pers.ToArray();

        }

        public static IEnumerable<Classes.Mastersk> getMast(int idPerson)
        {
            IEnumerable<Classes.Pasrticipation> part = dataListFirst
                .Where(x => x.vid == Vids.participation)
                .Cast<Classes.Pasrticipation>()
                .Where(x => x.member == idPerson);

            List<Classes.Mastersk> res = new List<Mastersk>();
            foreach (Classes.Pasrticipation partI in part)
            {
                res.Add(dataListFirst
               .Where(x => x.vid == Vids.masterskaya)
               .Cast<Classes.Mastersk>()
               .Where(x => x.id == partI.inOrg).FirstOrDefault());
            }
            return res.ToArray();
        }
        public static IEnumerable<Classes.Person> GetPeople(int idMast)
        {
            IEnumerable<Classes.Pasrticipation> partIn = dataListFirst
                .Where(x => x.vid == Vids.participation)
                .Cast<Classes.Pasrticipation>()
                .Where(x => x.inOrg == idMast);
            List<Classes.Person> pers = new List<Person>();
            foreach (Classes.Pasrticipation partI in partIn)
            {
                pers.Add(dataListFirst
                    .Where(x => x.vid == Vids.person)
                    .Cast<Classes.Person>()
                    .Where(x => x.id == partI.member)
                    .FirstOrDefault());
            }
            return pers;

        }
        public static int GetIDFromStringMastersk(string name)
        {
            name = name.ToLower();
            Classes.Mastersk mast = dataListFirst
                .Where(x => x.vid == Vids.masterskaya)
                 .Cast<Classes.Mastersk>()
                 .Where(x => x.name.ToLower() == name)
                 .FirstOrDefault();
            if (mast == null)
            {
                return -99;
            }
            return mast.id;
        }
        public static IEnumerable<Classes.Reflect> getReflects(int id)
        {
            IEnumerable<Classes.Reflect> refl = dataListFirst
                .Where(x => x.vid == Vids.reflect)
                .Cast<Classes.Reflect>()
                .Where(x => x.toPerson == id);
            return refl;
        }
        public static void GetFromFile()
        {
            var xDB = XElement.Load("Database/SypCassete_current.fog");
            dataListFirst.Clear();
            AddDefult();
            foreach (XElement xElement in xDB.Elements())
            {
                if (xElement.Name.LocalName == "person")
                {
                    string idFromBD = xElement.Attribute("{http://www.w3.org/1999/02/22-rdf-syntax-ns#}about").Value;
                    string name = xElement.Element("name").Value;
                    dataListFirst.Add(new Classes.Person() { stringID = idFromBD, name = name, vid = Vids.person, id = idFromBD.GetHashCode() });
                }
                if (xElement.Name.LocalName == "org-sys")
                {
                    string idFromBD = xElement.Attribute("{http://www.w3.org/1999/02/22-rdf-syntax-ns#}about").Value;
                    string name = xElement.Element("name").Value;
                    Classes.Mastersk mast = new Classes.Mastersk() { stringID = idFromBD, name = name, vid = Vids.masterskaya, id = idFromBD.GetHashCode() };
                    string fromDate = xElement.Element("from-date")?.Value;
                    if (fromDate != null)
                    {
                        mast.year = fromDate;
                    }
                    dataListFirst.Add(mast);
                }
                if (xElement.Name.LocalName == "photo-doc")
                {
                    string idFromBD = xElement.Attribute("{http://www.w3.org/1999/02/22-rdf-syntax-ns#}about").Value;
                    XElement xStore = xElement.Element("iisstore");
                    Classes.Doc doc = new Classes.Doc() { stringID = idFromBD, vid = Vids.doc, id = idFromBD.GetHashCode() };
                    if (xStore != null)
                    {
                        string uri = xStore.Attribute("uri").Value;
                        string dosumentType = xStore.Attribute("documenttype").Value;
                        doc.uri = uri;
                        doc.contentType = dosumentType;
                    }

                    string fromDate = xElement.Element("from-date")?.Value;
                    if (fromDate != null)
                    {
                        doc.date = fromDate;
                    }
                    string name = xElement.Element("name")?.Value;
                    if (name != null)
                    {
                        doc.name = name;

                    }
                    dataListFirst.Add(doc);
                }
                if (xElement.Name.LocalName == "reflection")
                {
                    string idFromBD = xElement.Attribute("{http://www.w3.org/1999/02/22-rdf-syntax-ns#}about").Value;
                    int toDoc = xElement.Element("in-doc").Attribute("{http://www.w3.org/1999/02/22-rdf-syntax-ns#}resource").Value.GetHashCode();
                    int toPerson = xElement.Element("reflected").Attribute("{http://www.w3.org/1999/02/22-rdf-syntax-ns#}resource").Value.GetHashCode();
                    dataListFirst.Add(new Classes.Reflect() { stringID = idFromBD, id = idFromBD.GetHashCode(), toDoc = toDoc, toPerson = toPerson, vid = Vids.reflect, });
                }
                if (xElement.Name.LocalName == "participation")
                {
                    string idFromBD = xElement.Attribute("{http://www.w3.org/1999/02/22-rdf-syntax-ns#}about").Value;
                    int member = xElement.Element("participant").Attribute("{http://www.w3.org/1999/02/22-rdf-syntax-ns#}resource").Value.GetHashCode();
                    int inOrg = xElement.Element("in-org").Attribute("{http://www.w3.org/1999/02/22-rdf-syntax-ns#}resource").Value.GetHashCode();
                    dataListFirst.Add(new Classes.Pasrticipation() { stringID = idFromBD, id = idFromBD.GetHashCode(), member = member, inOrg = inOrg, vid = Vids.participation, });
                }
            }


        }

        public static void SaveBD()
        {
            FileStream fileStream = new FileStream("Data/Database.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter writer = new BinaryWriter(fileStream);
            writer.Write((long)dataListFirst.Count());
            foreach (object o in dataListFirst)
            {
                if (o is Person)
                {

                    Person p = (Person)o;
                    writer.Write(((byte)p.vid));
                    Console.WriteLine(((byte)p.vid) + "For Person");
                    writer.Write(p.id);
                    writer.Write(p.name);
                    writer.Write(p.masterskaya);
                    writer.Write(p.birth);
                    writer.Write(p.city);
                    writer.Write(p.school);
                }
                else if (o is Mastersk)
                {

                    Mastersk p = (Mastersk)o;
                    writer.Write(((byte)p.vid));
                    Console.WriteLine(((byte)p.vid) + "For Mast");
                    writer.Write(p.id);
                    writer.Write(p.year);
                    writer.Write(p.name);
                    writer.Write(p.description);
                }
                else if (o is Doc)
                {
                    Doc p = (Doc)o;
                    writer.Write(((byte)p.vid));
                    Console.WriteLine(((byte)p.vid) + "For DOCUMENT");
                    writer.Write(p.id);
                    writer.Write(p.name);
                    writer.Write(p.description);
                }
                else if (o is Reflect)
                {
                    Reflect p = (Reflect)o;
                    writer.Write(((byte)p.vid));
                    Console.WriteLine(((byte)p.vid) + "For Reflect");
                    writer.Write(p.id);
                    writer.Write(p.toPerson);
                    writer.Write(p.toDoc);
                }
            }
            writer.Flush();
            fileStream.Close();
        }


        public static void ReloadDB()
        {
            try
            {
                FileStream file = new FileStream("Data/Database.bin", FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(file);
                long max = reader.ReadInt64();
                dataListFirst.Clear();
                for (int i = 0; i < max; i++)
                {
                    byte BDID = reader.ReadByte();
                    if (BDID == ((byte)Vids.person))
                    {
                        int id = reader.ReadInt32();
                        string name = reader.ReadString();
                        int masters = reader.ReadInt32();
                        string birth = reader.ReadString();
                        string city = reader.ReadString();
                        string school = reader.ReadString();
                        dataListFirst.Add(new Person() { id = id, name = name, masterskaya = masters, birth = birth, city = city, school = school, vid = Vids.person });
                    }
                    else if (BDID == ((byte)Vids.masterskaya))
                    {
                        int id = reader.ReadInt32();
                        string year = reader.ReadString();
                        string name = reader.ReadString();
                        string desc = reader.ReadString();

                        dataListFirst.Add(new Mastersk() { id = id, name = name, description = desc, year = year, vid = Vids.masterskaya });
                    }
                    else if (BDID == ((byte)Vids.doc))
                    {
                        int id = reader.ReadInt32();
                        string name = reader.ReadString();
                        string desc = reader.ReadString();

                        dataListFirst.Add(new Doc() { id = id, name = name, description = desc, vid = Vids.doc });
                    }
                    else if (BDID == ((byte)Vids.reflect))
                    {
                        int id = reader.ReadInt32();
                        int idP = reader.ReadInt32();
                        int idD = reader.ReadInt32();

                        dataListFirst.Add(new Reflect() { id = id, toDoc = idD, toPerson = idP, vid = Vids.reflect });
                    }
                }

                file.Close();
            }
            catch (FileNotFoundException)
            {
                return;
            }
        }
    }

}
