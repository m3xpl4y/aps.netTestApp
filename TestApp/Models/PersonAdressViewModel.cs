using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp.Models
{
    public class PersonAdressViewModel
    {
        public IEnumerable<Person> Person { get; set; }
        public IEnumerable<Adress> Adress { get; set; }
    }
}