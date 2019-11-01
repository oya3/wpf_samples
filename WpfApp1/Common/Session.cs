using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Common
{
    class Session
    {
        private static readonly Session instance = new Session();
        private Dictionary<string, object> Hash;
        private Session()
        {
            this.Hash = new Dictionary<string, object>();
        }

        public static Session Instance
        {
            get
            {
                return instance;
            }
        }
        public void Set(string key, object value)
        {
            this.Hash[key] = value;
        }
        public object Remove(string key)
        {
            if (!this.Hash.ContainsKey(key))
                return false;
            return this.Hash.Remove(key);
        }
        public object GetValue(string key)
        {
            if (!this.Hash.ContainsKey(key))
                return (object)null;
            return this.Hash[key];
        }
    }
}
