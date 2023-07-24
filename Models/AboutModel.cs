using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CraftHelper.Models
{
    public class AboutModel : BaseModel
    {
        private AboutModel() { }

        public readonly static Dictionary<string, string> BuildInfo = new Dictionary<string, string>() 
        { 
            ["Build Date"] = "2023-7-24",
            ["Build Machine"] = "x64-based computer",
            ["Build CPU"] = "11th Gen Intel(R) Core(TM) i9-11900H @ 2.50GHz",
            ["Build OS"] = "Windows 11 Professional Edition (OS Build 22621.1992)",
            ["Build Runtime"] = ".NET Framework 4.8.9167.0",
        };

        public readonly static string PageIcon = "https://www.iconfont.cn/collections/detail?cid=45375";

        public readonly static string SideBar = "https://github.com/CSharpDesignPro/Navigation-Drawer-Sidebar-Menu-in-WPF";

        public readonly static string MIT_license =
            "Copyright (C) 2023 nyilun\n\n" +
            "Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:\n\nThe above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.\n\n" +
            "THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.";

        public static void ConsolePrintBuildInfo()
        {
            foreach(KeyValuePair<string, string> kvp in BuildInfo) { Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value); ; }
            Console.WriteLine(MIT_license);
        }
    }
}
