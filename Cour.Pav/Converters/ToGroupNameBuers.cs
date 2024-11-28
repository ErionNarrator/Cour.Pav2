using Cour.Pav.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Cour.Pav.Converters
{
    internal class ToGroupNameBuers : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            AucitonContext db = new AucitonContext();
          
            return db.Buyers.FirstOrDefault(a => a.BuyerId == (int)value)!.BuyerName!;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
