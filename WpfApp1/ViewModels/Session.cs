using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    class Session
    {
        private static readonly Session instance = new Session();
        private Dictionary<string, object> Hash;
        private Session()
        {
            Hash = new Dictionary<string, object>();
        }

        public static Session Instance
        {
            get
            {
                return instance;
            }
        }
        public bool Add(string key, object value)
        {
            if (Hash.ContainsKey(key))
                return false;
            Hash.Add(key, value);
            return true;
        }
        public object Remove(string key)
        {
            if (!Hash.ContainsKey(key))
                return false;
            return Hash.Remove(key);
        }
        public object GetValue(string key)
        {
            if (!Hash.ContainsKey(key))
                return (object)null;
            return Hash[key];
        }
    }
}
