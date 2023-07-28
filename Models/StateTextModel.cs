using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CraftHelper.Models
{
    public class StateTextModel : BaseModel
    {
        private StateTextModel() { }
        public static string _StateText { get; set; }
        public static string _Color { get; set; }
    }
}
