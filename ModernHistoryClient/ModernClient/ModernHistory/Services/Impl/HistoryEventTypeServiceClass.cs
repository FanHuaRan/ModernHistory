﻿using ModernHistory.Gloabl;
using Fhr.ModernHistory.Models;
using ModernHistory.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ModernHistory.Services.Impl
{
    /// <summary>
    /// HistoryEventType服务实现
    /// 2017/07/11 fhr
    /// </summary>
    public class HistoryEventTypeServiceClass:IHistoryEventTypeService
    {
        public static readonly string FIND_URL = WebApiConfig.WEBAPI_BASE_URL + "/HistoryEventType/Get";

        public async Task<ObservableCollection<HistoryEventType>> FindAllAsync()
        {
            return await HttpClientUtils.GetAsync<ObservableCollection<HistoryEventType>>(FIND_URL);
        }

        public async Task<HistoryEventType> FindByIdAsync(int id)
        {
            var address = string.Format("{0}/{1}", FIND_URL, id);
            return await HttpClientUtils.GetAsync<HistoryEventType>(address);
        }
    }
}
