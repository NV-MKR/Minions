using System.Net;
using System.Text;
using System.Web.Http;

namespace Minions.Models
{
    public class Minion
    {
        private int id;
        private string name;

        public int ID 
        {
            get
            { 
                return id; 
            }

            set
            { 
                id = value; 
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (value.Length > 3)
                    { 
                    name = value; 
                }
            }
                          
        }

        public Minion()
        {

        }
    }
}
