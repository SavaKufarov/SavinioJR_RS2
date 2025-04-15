using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; } = new List<User>();

        private District()
        {

        }
        public District(string name)
        {
            Name = name;
        }
    }
}
