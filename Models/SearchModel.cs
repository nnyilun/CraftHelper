using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftHelper.Models
{
    public class SearchModel : BaseModel
    {
        private SearchModel() { }

        public static List<SearchInfo> SearchResult = new List<SearchInfo>() 
        { 
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
            new SearchInfo() { ItemName = "Unknown", ItemId = -1},
        };

        public static List<SearchInfo> SearchAddition = new List<SearchInfo>();



        public class SearchInfo
        {
            public static implicit operator string(SearchInfo SI)
            {
                return SI.ItemName;
            }
            public string ItemName { get; set; }
            public int ItemId { get; set; }
        }
    }
}
