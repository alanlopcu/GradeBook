using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    //public delegate void NameChangeDelegate(string existingName, string newName);
    public delegate void NameChangedDelegate(object sender, NameChangedEventArgs newName);
}
