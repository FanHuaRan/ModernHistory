﻿using ModernHistory.Models;
using ModernHistory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ModernHistory.Converters
{
    /// <summary>
    /// FamousPersonType和ID转换器
    /// 2017/07/14 fhr
    /// </summary>
    [ValueConversion(typeof(int), typeof(FamousPersonTypeConverter))]
    public class FamousPersonTypeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var typeId = (int)value;
            return CommonConstViewModel.Instance.FamousPersonTypes.Where(p => p.FamousPersonTypeId == typeId).FirstOrDefault();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var famouseType=value as FamousPersonType;
            if (famouseType != null)
            {
                return famouseType.FamousPersonTypeId;
            }
            else
            {
                return -1;
            }
        }
    }
}