using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class CSVLine:System.Dynamic.DynamicObject
    {
        public string[] LineContent { get; set; }
        public static List<string> HeaderContent { get; set; }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            int index = HeaderContent.IndexOf(binder.Name);
            if (index != -1)
            {
                result = LineContent[index];
                return true;
            }
            return false;
        }

    }
}
