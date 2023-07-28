using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftHelper.Models.BaseModel;

namespace CraftHelper.Models
{
    public class BaseModel
    {
        protected BaseModel() { }

        public class Recipe
        {
            public string Name { get; set; }
            public List<Recipe> SubRecipe { get; set; }
        }

        public class Item
        {
            public string ItemName { get; set; }
            public int ItemId { get; set; }
            public int ItemLevel { get; set; }
            public JobInfo ClassJob { get; set; }
            public string ItemIconUrl { get; set; }


            public bool HasRecipe { get; set; }
            public JobInfo ItemMaker { get; set; }
            public int RecipeId { get; set; }
            public int RecipeLevel { get; set; }
            public Recipe ItemRecipe { get; set; }
        }

        public class JobInfo
        {
            public static implicit operator string(JobInfo Job)
            {
                return Job.JobChName;
            }
            public int JobId;
            public List<string> JobAbbreviation { get; set; }
            public string JobChName { get; set; }
        }

        public readonly static Dictionary<int, JobInfo> AllJob = new Dictionary<int, JobInfo>() 
        {
            { 1, new JobInfo(){ JobId = 1, JobAbbreviation = new List < string > { "ACN", "ADV", "ALC", "ARC", "ARM", "AST", "BLM", "BLU", "BRD", "BSM", "BTN", "CNJ", "CRP", "CUL", "DNC", "DRG", "DRK", "FSH", "GLA", "GNB", "GSM", "ID", "LNC", "LTW", "MCH", "MIN", "MNK", "MRD", "NIN", "PGL", "PLD", "RDM", "ROG", "RPR", "SAM", "SCH", "SGE", "SMN", "THM", "WAR", "WHM", "WVR" }, JobChName = "所有职业" } },
            { 9, new JobInfo(){ JobId = 9, JobAbbreviation = new List < string > { "CRP" }, JobChName = "刻木匠" } },
            { 10, new JobInfo(){ JobId = 10, JobAbbreviation = new List < string > { "BSM" }, JobChName = "锻铁匠" } },
            { 11, new JobInfo(){ JobId = 11, JobAbbreviation = new List < string > { "ARM" }, JobChName = "铸甲匠" } },
            { 12, new JobInfo(){ JobId = 12, JobAbbreviation = new List < string > { "GSM" }, JobChName = "雕金匠" } },
            { 13, new JobInfo(){ JobId = 13, JobAbbreviation = new List < string > { "LTW" }, JobChName = "制革匠" } },
            { 14, new JobInfo(){ JobId = 14, JobAbbreviation = new List< string > { "WVR" }, JobChName = "裁衣匠" } },
            { 15, new JobInfo(){ JobId = 15, JobAbbreviation = new List < string > { "ALC" }, JobChName = "炼金术士" } },
            { 16, new JobInfo(){ JobId = 16, JobAbbreviation = new List < string > { "CUL" }, JobChName = "烹调师" } },
            { 17, new JobInfo(){ JobId = 17, JobAbbreviation = new List < string > { "MIN" }, JobChName = "采矿工" } },
            { 18, new JobInfo(){ JobId = 18, JobAbbreviation = new List < string > { "BTN" }, JobChName = "园艺工" } },
            { 19, new JobInfo(){ JobId = 19, JobAbbreviation = new List < string > { "FSH" }, JobChName = "捕鱼人" } },
            { 29, new JobInfo(){ JobId = 29, JobAbbreviation = new List < string > { "SCH" }, JobChName = "学者" } },
            { 30, new JobInfo(){ JobId = 30, JobAbbreviation = new List < string > { "ARC", "BRD", "DNC", "DRG", "DRK", "GLA", "GNB", "LNC", "MCH", "MNK", "MRD", "NIN", "PGL", "PLD", "ROG", "RPR", "SAM", "WAR" }, JobChName = "战斗精英" } },
            { 31, new JobInfo(){ JobId = 31, JobAbbreviation = new List < string > { "ACN", "AST", "BLM", "BLU", "CNJ", "RDM", "SCH", "SGE", "SMN", "THM", "WHM" }, JobChName = "魔法导师" } },
            { 32, new JobInfo(){ JobId = 32, JobAbbreviation = new List < string > { "BTN", "FSH", "MIN" }, JobChName = "大地使者" } },
            { 33, new JobInfo(){ JobId = 33, JobAbbreviation = new List < string > { "ALC", "ARM", "BSM", "CRP", "CUL", "GSM", "LTW", "WVR" }, JobChName = "能工巧匠" } },
            { 34, new JobInfo(){ JobId = 34, JobAbbreviation = new List < string > { "ACN", "ARC", "AST", "BLM", "BLU", "BRD", "CNJ", "DNC", "DRG", "DRK", "GLA", "GNB", "LNC", "MCH", "MNK", "MRD", "NIN", "PGL", "PLD", "RDM", "ROG", "RPR", "SAM", "SCH", "SGE", "SMN", "THM", "WAR", "WHM" }, JobChName = "战斗精英 魔法导师" } },
            { 38, new JobInfo(){ JobId = 38, JobAbbreviation = new List < string > { "GLA", "PLD" }, JobChName = "剑术师 骑士" } },
            { 41, new JobInfo(){ JobId = 41, JobAbbreviation = new List < string > { "MNK", "PGL" }, JobChName = "格斗家 武僧" } },
            { 44, new JobInfo(){ JobId = 44, JobAbbreviation = new List < string > { "MRD", "WAR" }, JobChName = "斧术师 战士" } },
            { 47, new JobInfo(){ JobId = 47, JobAbbreviation = new List < string > { "DRG", "LNC" }, JobChName = "枪术师 龙骑士" } },
            { 50, new JobInfo(){ JobId = 50, JobAbbreviation = new List < string > { "ARC", "BRD" }, JobChName = "弓箭手 吟游诗人" } },
            { 53, new JobInfo(){ JobId = 53, JobAbbreviation = new List < string > { "CNJ", "WHM" }, JobChName = "幻术师 白魔法师" } },
            { 55, new JobInfo(){ JobId = 55, JobAbbreviation = new List < string > { "BLM", "THM" }, JobChName = "咒术师 黑魔法师" } },
            { 56, new JobInfo(){ JobId = 56, JobAbbreviation = new List < string > { "BLM", "CNJ", "GLA", "PLD", "THM", "WHM" }, JobChName = "剑术师 幻术师 咒术师 骑士 白魔法师 黑魔法师" } },
            { 57, new JobInfo(){ JobId = 57, JobAbbreviation = new List < string > { "BLM", "GLA", "PLD", "THM" }, JobChName = "剑术师 咒术师 骑士 黑魔法师" } },
            { 58, new JobInfo(){ JobId = 58, JobAbbreviation = new List < string > { "CNJ", "GLA", "PLD", "WHM" }, JobChName = "剑术师 幻术师 骑士 白魔法师" } },
            { 59, new JobInfo(){ JobId = 59, JobAbbreviation = new List < string > { "DRK", "GLA", "GNB", "MRD", "PLD", "WAR" }, JobChName = "剑术师 斧术师 骑士 战士 暗黑骑士 绝枪战士" } },
            { 60, new JobInfo(){ JobId = 60, JobAbbreviation = new List < string > { "DRG", "DRK", "GLA", "GNB", "LNC", "MRD", "PLD", "RPR", "WAR" }, JobChName = "剑术师 斧术师 枪术师 骑士 战士 龙骑士 暗黑骑士 绝枪战士 钐镰客" } },
            { 63, new JobInfo(){ JobId = 63, JobAbbreviation = new List < string > { "ACN", "BLM", "BLU", "RDM", "SMN", "THM" }, JobChName = "咒术师 秘术师 黑魔法师 召唤师 赤魔法师 青魔法师" } },
            { 64, new JobInfo(){ JobId = 64, JobAbbreviation = new List < string > { "AST", "CNJ", "SCH", "SGE", "WHM" }, JobChName = "幻术师 白魔法师 学者 占星术士 贤者" } },
            { 65, new JobInfo(){ JobId = 65, JobAbbreviation = new List < string > { "MNK", "PGL", "SAM" }, JobChName = "格斗家 武僧 武士" } },
            { 66, new JobInfo(){ JobId = 66, JobAbbreviation = new List < string > { "ARC", "BRD", "DNC", "MCH" }, JobChName = "弓箭手 吟游诗人 机工士 舞者" } },
            { 68, new JobInfo(){ JobId = 68, JobAbbreviation = new List < string > { "ACN", "SCH", "SMN" }, JobChName = "秘术师 召唤师 学者" } },
            { 69, new JobInfo(){ JobId = 69, JobAbbreviation = new List < string > { "ACN", "SMN" }, JobChName = "秘术师 召唤师" } },
            { 76, new JobInfo(){ JobId = 76, JobAbbreviation = new List < string > { "DRG", "LNC", "RPR" }, JobChName = "枪术师 龙骑士 钐镰客" } },
            { 84, new JobInfo(){ JobId = 84, JobAbbreviation = new List < string > { "DRG", "LNC", "MNK", "PGL", "RPR", "SAM" }, JobChName = "格斗家 枪术师 武僧 龙骑士 武士 钐镰客" } },
            { 103, new JobInfo(){ JobId = 103, JobAbbreviation = new List < string > { "NIN", "ROG" }, JobChName = "双剑师  忍者" } },
            { 96, new JobInfo(){ JobId = 96, JobAbbreviation =  new List < string > { "MCH" }, JobChName = "机工士" } },
            { 98, new JobInfo(){ JobId = 98, JobAbbreviation = new List < string > { "DRK" }, JobChName = "暗黑骑士" } },
            { 99, new JobInfo(){ JobId = 99, JobAbbreviation = new List < string > { "AST" }, JobChName = "占星术士" } },
            { 102, new JobInfo(){ JobId = 102, JobAbbreviation = new List < string > { "MNK", "NIN", "PGL", "ROG", "SAM" }, JobChName = "格斗家 双剑师 武僧 忍者 武士" } },
            { 105, new JobInfo(){ JobId = 105, JobAbbreviation = new List < string > { "ARC", "BRD", "DNC", "MCH", "NIN", "ROG" }, JobChName = "弓箭手 双剑师 吟游诗人 忍者 机工士 舞者" } },
            { 111, new JobInfo(){ JobId = 111, JobAbbreviation = new List < string > { "SAM" }, JobChName = "武士" } },
            { 112, new JobInfo(){ JobId = 112, JobAbbreviation = new List < string > { "RDM" }, JobChName = "赤魔法师" } },
            { 149, new JobInfo(){ JobId = 149, JobAbbreviation = new List < string > { "GNB" }, JobChName = "绝枪战士" } },
            { 150, new JobInfo(){ JobId = 150, JobAbbreviation = new List < string > { "DNC" }, JobChName = "舞者" } },
            { 180, new JobInfo(){ JobId = 180, JobAbbreviation = new List < string > { "RPR" }, JobChName = "钐镰客" } },
            { 181, new JobInfo(){ JobId = 181, JobAbbreviation = new List < string > { "SGE" }, JobChName = "贤者" } },
        }; 

        public readonly static Dictionary<int, JobInfo> SpecialJob = new Dictionary<int, JobInfo>()
        {
            { 0, new JobInfo() { JobId = 0, JobAbbreviation = new List < string > {}, JobChName = "不限" } },
            { 9, new JobInfo(){ JobId = 9, JobAbbreviation = new List < string > { "CRP" }, JobChName = "刻木匠" } },
            { 10, new JobInfo(){ JobId = 10, JobAbbreviation = new List < string > { "BSM" }, JobChName = "锻铁匠" } },
            { 11, new JobInfo(){ JobId = 11, JobAbbreviation = new List < string > { "ARM" }, JobChName = "铸甲匠" } },
            { 12, new JobInfo(){ JobId = 12, JobAbbreviation = new List < string > { "GSM" }, JobChName = "雕金匠" } },
            { 13, new JobInfo(){ JobId = 13, JobAbbreviation = new List < string > { "LTW" }, JobChName = "制革匠" } },
            { 14, new JobInfo(){ JobId = 14, JobAbbreviation = new List < string > { "WVR" }, JobChName = "裁衣匠" } },
            { 15, new JobInfo(){ JobId = 15, JobAbbreviation = new List < string > { "ALC" }, JobChName = "炼金术士" } },
            { 16, new JobInfo(){ JobId = 16, JobAbbreviation = new List < string > { "CUL" }, JobChName = "烹调师" } },
            { 17, new JobInfo(){ JobId = 17, JobAbbreviation = new List < string > { "MIN" }, JobChName = "采矿工" } },
            { 18, new JobInfo(){ JobId = 18, JobAbbreviation = new List < string > { "BTN" }, JobChName = "园艺工" } },
            { 19, new JobInfo(){ JobId = 19, JobAbbreviation = new List < string > { "FSH" }, JobChName = "捕鱼人" } },
            { 44, new JobInfo(){ JobId = 44, JobAbbreviation = new List < string > { "WAR" }, JobChName = "战士" } },
            { 38, new JobInfo(){ JobId = 38, JobAbbreviation = new List < string > { "PLD" }, JobChName = "骑士" } },
            { 98, new JobInfo(){ JobId = 98, JobAbbreviation = new List < string > { "DRK" }, JobChName = "暗黑骑士" } },
            { 149, new JobInfo(){ JobId = 149, JobAbbreviation = new List < string > { "GNB" }, JobChName = "绝枪战士" } },
            { 41, new JobInfo(){ JobId = 41, JobAbbreviation = new List < string > { "MNK" }, JobChName = "武僧" } },
            { 47, new JobInfo(){ JobId = 47, JobAbbreviation = new List < string > { "DRG" }, JobChName = "龙骑士" } },
            { 103, new JobInfo(){ JobId = 103, JobAbbreviation = new List < string > { "NIN" }, JobChName = "忍者" } },
            { 111, new JobInfo(){ JobId = 111, JobAbbreviation = new List < string > { "SAM" }, JobChName = "武士" } },
            { 180, new JobInfo(){ JobId = 180, JobAbbreviation = new List < string > { "RPR" }, JobChName = "钐镰客" } },
            { 50, new JobInfo(){ JobId = 50, JobAbbreviation = new List < string > { "BRD" }, JobChName = "吟游诗人" } },
            { 96, new JobInfo(){ JobId = 96, JobAbbreviation = new List < string > { "MCH" }, JobChName = "机工士" } },
            { 150, new JobInfo(){ JobId = 150, JobAbbreviation = new List < string > { "DNC" }, JobChName = "舞者" } },
            { 55, new JobInfo(){ JobId = 55, JobAbbreviation = new List < string > { "BLM" }, JobChName = "黑魔法师" } },
            { 69, new JobInfo(){ JobId = 69, JobAbbreviation = new List < string > { "SMN" }, JobChName = "召唤师" } },
            { 112, new JobInfo(){ JobId = 112, JobAbbreviation = new List < string > { "RDM" }, JobChName = "赤魔法师" } },
            { 53, new JobInfo(){ JobId = 53, JobAbbreviation = new List < string > { "WHM" }, JobChName = "白魔法师" } },
            { 29, new JobInfo(){ JobId = 29, JobAbbreviation = new List < string > { "SCH" }, JobChName = "学者" } },
            { 99, new JobInfo(){ JobId = 99, JobAbbreviation = new List < string > { "AST" }, JobChName = "占星术士" } },
            { 181, new JobInfo(){ JobId = 181, JobAbbreviation = new List < string > { "SGE" }, JobChName = "贤者" } },
        };
    }
}
