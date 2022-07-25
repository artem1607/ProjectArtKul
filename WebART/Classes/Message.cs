
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebART.Classes
{
    public class Message
    {
        private string message = "";
        private string user = "";
        private string date = "";
        public void setDate()
        {
            date = System.DateTime.Now.Hour.ToString() + " часов " + System.DateTime.Now.Minute.ToString() + " минут";
        }
        public void setUser(string name)
        {
            user = name;
        }
        public void setMessage(string msg)
        {
            message = msg;
        }

        public string getMessage()
        {
            return user + ": " + message;
        }
        public string getDate()
        {
            return date;
        }
    }
}