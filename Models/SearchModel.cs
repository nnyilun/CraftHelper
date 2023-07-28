using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;
using static CraftHelper.Models.BaseModel;

namespace CraftHelper.Models
{
    public class SearchModel : BaseModel
    {
        private SearchModel() { }

        public static List<SearchInfo> SearchResult = new List<SearchInfo>();
        public static List<SearchInfo> SearchAddition = new List<SearchInfo>();

        public static int SearchPageMax = 10;

        public class SearchInfo
        {
            public static implicit operator string(SearchInfo SI)
            {
                return SI.ItemName;
            }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                SearchInfo other = (SearchInfo)obj;
                return ItemId == other.ItemId;
            }

            public override int GetHashCode()
            {
                return ItemId.GetHashCode() ^ ItemName.GetHashCode() ^ ItemIconPath.GetHashCode();
            }

            public string ItemName { get; set; }
            public int ItemId { get; set; }
            public string ItemIconPath { get; set; }
        }
    }
}
