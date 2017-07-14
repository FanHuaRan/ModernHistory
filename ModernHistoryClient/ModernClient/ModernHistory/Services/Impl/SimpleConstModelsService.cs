using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernHistory.Models;
using System.Collections.ObjectModel;

namespace ModernHistory.Services.Impl
{
    /// <summary>
    /// 简单常量数据服务实现
    /// </summary>
    public class SimpleConstModelsService : IConstModelsService
    {

        public ObservableCollection<FamousPersonType> FamousPersonTypes
        {
            get
            {
                return new ObservableCollection<FamousPersonType>()
                {
                        new FamousPersonType(){ FamousPersonTypeId=1,FamousPersonTypeName =" 政治家"},
                        new FamousPersonType(){ FamousPersonTypeId=2,FamousPersonTypeName = "思想家"},
                        new FamousPersonType(){ FamousPersonTypeId=3,FamousPersonTypeName = "军事家"},
                        new FamousPersonType(){ FamousPersonTypeId=4,FamousPersonTypeName = "文学家"},
                        new FamousPersonType(){ FamousPersonTypeId=5,FamousPersonTypeName = "商人"},
                        new FamousPersonType(){ FamousPersonTypeId=6,FamousPersonTypeName = "明星"},
                        new FamousPersonType(){ FamousPersonTypeId=7,FamousPersonTypeName = "其它"}
                };
            }
        }

        public ObservableCollection<HistoryEventType> HistoryEventTypes
        {
            get
            {
                return new ObservableCollection<HistoryEventType>()
                {
                        new HistoryEventType(){HistoryEventTypeId=1,HistoryEventTypeName="政治"},
                        new HistoryEventType(){ HistoryEventTypeId=2,HistoryEventTypeName="军事"},
                        new HistoryEventType(){ HistoryEventTypeId=3,HistoryEventTypeName="经济"},
                        new HistoryEventType(){ HistoryEventTypeId=4,HistoryEventTypeName="文学"},
                        new HistoryEventType(){ HistoryEventTypeId=5,HistoryEventTypeName="军事"},
                };
            }
        }

        public ObservableCollection<string> Provinces
        {
            get {
                return new ObservableCollection<string>()
                {
                    "四川","湖南","贵州","江苏"
                };
            }
        }

        public ObservableCollection<string> Nations
        {
            get
            {
                return new ObservableCollection<string>()
                {
                    "汉族","蒙古族","回族","壮族"
                };
            }
        }
    }
}
