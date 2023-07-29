using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CraftHelper.Models;
using CraftHelper.Views;
using CraftHelper.ViewModels.Base;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Security.Policy;
using System.Threading;
using System.Windows.Documents;

namespace CraftHelper.ViewModels
{
    public class SearchUsrCtrlViewModel : ViewModelBase
    {
        private readonly UserControl _this;

        private string _api = SettingModel.xmlDoc["Config"]["Api"]["ChXiv"].InnerText;
        static readonly HttpClient client = new HttpClient();
        private readonly string IconPath = Path.Combine(SettingModel.xmlDoc["Config"]["Base"]["CacheLocation"].InnerText, "images");
        private CancellationTokenSource cancellationTokenSource;
        private string _SearchBtnContent = "搜索";
        private string _ProgressContextValue = "0";
        private string _ProgressContextTotal = "0";

        private string _ProgressBarMax = "100";
        private string _ProgressBarValue = "0";
        private string _ProgressBarVisibility = "Visible";

        private bool _isInput = false;
        private string _TextBoxContent = "请输入物品要搜索的内容";
        private string _TextBoxColor = "Gray";

        private BaseModel.JobInfo _selectedJob = BaseModel.SpecialJob.Values.FirstOrDefault();

        private bool _IsChApiSelected = true;
        private bool _IsEnApiSelected = false;
        private int _ItemLevelLow = 0;
        private int _ItemLevelHigh = 0;
        private bool _IsChecked = false;

        public ICommandBase SearchListBoxDoubleClickCommand { get; set; }
        public ICommandBase AdditionListBoxDoubleClickCommand { get; set; }
        public ICommandBase TextBoxGotFocusCommand { get; set; }
        public ICommandBase SearchBtnClickCommand { get; set; }
        public ICommandBase UnloadedSearchUsrCtrlCommand { get; set; }

        public SearchUsrCtrlViewModel(UserControl main)
        {
            _this = main;
            SearchListBoxDoubleClickCommand = new ICommandBase((object param) => SearchListBoxDoubleClick(param as ListBox));
            AdditionListBoxDoubleClickCommand = new ICommandBase((object param) => AdditionListBoxDoubleClick(param as ListBox));
            TextBoxGotFocusCommand = new ICommandBase(TextBoxGotFocus);
            SearchBtnClickCommand = new ICommandBase(SearchBtnClick);
            UnloadedSearchUsrCtrlCommand = new ICommandBase(UnloadedSearchUsrCtrl);

            SearchAdditionTable.Clear();
        }

        private void SearchListBoxDoubleClick(ListBox obj) 
        {
            if (!SearchAdditionTable.Contains(SearchResultTable[obj.SelectedIndex]))
            {
                SearchAdditionTable.Add(SearchResultTable[obj.SelectedIndex]);
            }
            ((ListBox)_this.FindName("AdditionListBox")).Items.Refresh();
        }

        public void AdditionListBoxDoubleClick(ListBox obj)
        {
            SearchAdditionTable.RemoveAt(obj.SelectedIndex);
            ((ListBox)_this.FindName("AdditionListBox")).Items.Refresh();
        }

        private void TextBoxGotFocus()
        {
            if(!_isInput)
            {
                _isInput = true;
                TextBoxContent = "";
                TextBoxColor = "Black";
            }
        }

        private void UnloadedSearchUsrCtrl()
        {
            
        }

        public async void SearchBtnClick()
        {
            try 
            { 
                if ( SearchBtnContent == "搜索" )
                {
                    (var check, var msg) = CheckParamsValidity();
                    if (!check)
                    {
                        SearchError(msg);
                        return;
                    }

                    StateText = "搜索中...";
                    StateColor = "Aqua";
                    SearchBtnContent = "取消";

                    if (!Directory.Exists(IconPath)) { RefreshIconFolder(); }

                    SearchResultTable.Clear();
                    ((ListBox)_this.FindName("SearchResultListBox")).Items.Refresh();

                    cancellationTokenSource = new CancellationTokenSource();

                    await SearchItemInChApi(TextBoxContent, GenerateSearchUrl(), cancellationTokenSource.Token);

                    SearchBtnContent = "搜索";
                    StateText = "搜索完成";
                    StateColor = "Green";
                }
                else if (SearchBtnContent == "取消")
                {
                    StopSearch();
                    // 必须重新加载一次SearchResultTable，不然可能出现数据绑定不匹配
                    ((ListBox)_this.FindName("SearchResultListBox")).Items.Refresh();
                    SearchBtnContent = "搜索";
                }
            }
            catch (OperationCanceledException)
            {
                StateText = "搜索终止";
                StateColor = "Orange";
            }
        }

        private void StopSearch()
        {
            cancellationTokenSource?.Cancel();
        }

        private void SearchError(string msg)
        {
            StateText = "搜索失败";
            StateColor = "Red";
            MessageBox.Show(msg, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private string GenerateSearchUrl()
        {
            ChangeApi();

            //filters=LevelItem>630,LevelItem<=640
            string _url = "&filters=";
            if(_ItemLevelLow != 0)
            {
                _url += $"LevelItem>={_ItemLevelLow},";
            }
            if (_ItemLevelHigh != 0)
            {
                _url += $"LevelItem<={_ItemLevelHigh},";
            }
            if (SelectedJob.JobChName != "不限")
            {
                _url += $"ClassJobCategory.{SelectedJob.JobAbbreviation[0]}=1,";
            }

            if (_url == "&filters=")
            {
                return "";
            }

            if (_url.EndsWith(","))
            {
                _url = _url.Substring(0, _url.Length - 1);
            }
            return _url;
        }

        private void ChangeApi()
        {
            if (IsChApiSelected)
            {
                _api = SettingModel.xmlDoc["Config"]["Api"]["ChXiv"].InnerText;
            }
            else
            {
                _api = SettingModel.xmlDoc["Config"]["Api"]["EnXiv"].InnerText;
            }
        }

        private void JudgeIsCancel(CancellationToken _cancellationToken)
        {
            if (_cancellationToken.IsCancellationRequested)
            {
                _cancellationToken.ThrowIfCancellationRequested();
            }
        }

        private async Task<string> GetStringAsyncWithCancellation(string requestUri, CancellationToken _cancellationToken)
        {
            using (var response = await client.GetAsync(requestUri, _cancellationToken))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        private async Task SearchItemInChApi(string Content, string filter, CancellationToken _cancellationToken)
        {
            string responseString = await GetStringAsyncWithCancellation(_api + "search?indexes=Item&string=" + Content + filter, _cancellationToken);
            JObject data = JsonConvert.DeserializeObject<JObject>(responseString);
            
            ProgressContextTotal = ProgressBarMax = data["Pagination"]["ResultsTotal"].ToString();
            ProgressContextValue = ProgressBarValue = "0";
            
            if (data["Pagination"]["ResultsTotal"].ToString() == "0") { return; }

            JArray results;
            Uri _uri;
            HttpResponseMessage response;
            int cnt = 0;
            for (int i = 2; i <= 10; ++i) 
            {
                results = data["Results"].ToObject<JArray>();
                foreach (var result in results)
                {
                    _uri = new Uri(_api + result["Icon"].ToString());
                    SearchResultTable.Add(new SearchModel.SearchInfo { ItemName = result["Name"].ToString(), ItemId = int.Parse(result["ID"].ToString()), ItemIconPath = Path.Combine(IconPath, _uri.Segments[_uri.Segments.Length - 1]) });
                    ((ListBox)_this.FindName("SearchResultListBox")).Items.Refresh();

                    if (IsChecked || File.Exists(Path.Combine(IconPath, _uri.Segments[_uri.Segments.Length - 1])))
                    {
                        ProgressContextValue = ProgressBarValue = (++cnt).ToString();
                        continue; 
                    }
                    response = await client.GetAsync(_api + result["Icon"].ToString(), _cancellationToken);
                    JudgeIsCancel(_cancellationToken);

                    using (Stream contentStream = await response.Content.ReadAsStreamAsync())
                    using (FileStream fileStream = new FileStream(Path.Combine(IconPath, _uri.Segments[_uri.Segments.Length - 1]), FileMode.Create, FileAccess.Write))
                    {
                        await contentStream.CopyToAsync(fileStream);
                    }

                    ProgressContextValue = ProgressBarValue = (++cnt).ToString();
                }
                ((ListBox)_this.FindName("SearchResultListBox")).Items.Refresh();

                if (data["Pagination"]["PageNext"].ToString() == "") { break; }

                responseString = await GetStringAsyncWithCancellation(_api + "search?indexes=Item&string=" + Content + filter + $"&Page={i}", _cancellationToken);
                JudgeIsCancel(_cancellationToken);
                data = JsonConvert.DeserializeObject<JObject>(responseString);
            }
            SearchResultTable = SearchResultTable.Distinct().OrderBy(info => info.ItemName).ToList();
            ((ListBox)_this.FindName("SearchResultListBox")).Items.Refresh();
        }

        private (bool, string) CheckParamsValidity()
        {
            if (string.IsNullOrWhiteSpace(TextBoxContent) || TextBoxContent == "请输入物品要搜索的内容")
            {
                Console.WriteLine(TextBoxContent);
                return (false, "搜索框为空！");
            }
            if (_ItemLevelLow > _ItemLevelHigh)
            {
                return (false, "等级范围区间不合理，最小值比最大值大！");
            }
            return (true, null);
        }

        public static bool IsEnglish(string input)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");
            return regex.IsMatch(input);
        }

        public static bool IsChinese(string input)
        {
            Regex regex = new Regex("^[\u4e00-\u9fa5]+$");
            return regex.IsMatch(input);
        }

        private void RefreshIconFolder()
        {
            if (!Directory.Exists(SettingModel.xmlDoc["Config"]["Base"]["CacheLocation"].InnerText))
            {
                Directory.CreateDirectory(SettingModel.xmlDoc["Config"]["Base"]["CacheLocation"].InnerText);
            }
            Directory.CreateDirectory(IconPath);
        }

        public List<SearchModel.SearchInfo> SearchResultTable
        {
            get { return SearchModel.SearchResult; }
            set { SearchModel.SearchResult = value; OnPropertyChanged(); }
        }

        public List<SearchModel.SearchInfo> SearchAdditionTable
        {
            get { return SearchModel.SearchAddition; }
            set { SearchModel.SearchAddition = value; OnPropertyChanged(); }
        }

        public string TextBoxContent
        {
            get { return _TextBoxContent; }
            set { _TextBoxContent = value; OnPropertyChanged(); }
        }

        public string TextBoxColor
        {
            get { return _TextBoxColor; }
            set { _TextBoxColor = value; OnPropertyChanged(); }
        }

        public string ProgressBarMax
        {
            get { return _ProgressBarMax; }
            set { _ProgressBarMax = value; OnPropertyChanged(); }
        }

        public string ProgressBarValue
        {
            get { return _ProgressBarValue; }
            set { _ProgressBarValue = value; OnPropertyChanged(); }
        }

        public string ProgressBarVisibility
        {
            get { return _ProgressBarVisibility; }
            set { _ProgressBarVisibility = value; OnPropertyChanged(); }
        }

        public string SearchBtnContent
        {
            get { return _SearchBtnContent; }
            set { _SearchBtnContent = value; OnPropertyChanged(); }
        }

        public string ProgressContextValue
        {
            get { return _ProgressContextValue; }
            set { _ProgressContextValue = value; OnPropertyChanged(); }
        }

        public string ProgressContextTotal
        {
            get { return _ProgressContextTotal; }
            set { _ProgressContextTotal = value; OnPropertyChanged(); }
        }

        public BaseModel.JobInfo SelectedJob
        {
            get { return _selectedJob; }
            set { _selectedJob = value; OnPropertyChanged(); }
        }

        public bool IsChApiSelected
        {
            get { return _IsChApiSelected; }
            set { _IsChApiSelected = value; OnPropertyChanged(); }
        }

        public bool IsEnApiSelected
        {
            get { return  _IsEnApiSelected; }
            set { _IsEnApiSelected = value; OnPropertyChanged(); }
        }

        public string ItemLevelLow
        {
            get { return _ItemLevelLow.ToString(); }
            set { 
                if (int.TryParse(value, out int tmp))
                {
                    _ItemLevelLow = tmp;
                }
                OnPropertyChanged(); 
            }
        }

        public string ItemLevelHigh
        {
            get { return _ItemLevelHigh.ToString(); }
            set {
                if (int.TryParse(value, out int tmp))
                {
                    _ItemLevelHigh = tmp;
                }
                OnPropertyChanged(); 
            }
        }

        public bool IsChecked
        {
            get { return _IsChecked; }
            set { _IsChecked = value; OnPropertyChanged(); }
        }
    }
}
