using Cour.Pav.Model;
using Cour.Pav.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cour.Pav.ModelView
{
    class NumberPurchasesPageViewModel : BaseClass
    {
        AucitonContext db = new AucitonContext();

        private DateTime? _selectedStartDate;
        public DateTime? SelectedStartDate
        {
            get => _selectedStartDate;
            set
            {
                _selectedStartDate = value;
                OnPropertyChanged(nameof(SelectedStartDate));
            }
        }

        private DateTime? _selectedEndDate;
        public DateTime? SelectedEndDate
        {
            get => _selectedEndDate;
            set
            {
                _selectedEndDate = value;
                OnPropertyChanged(nameof(SelectedEndDate));
            }
        }

        private ObservableCollection<dynamic> buyerPurchases;
        public ObservableCollection<dynamic> BuyerPurchases
        {
            get => buyerPurchases;
            set
            {
                buyerPurchases = value;
                OnPropertyChanged(nameof(BuyerPurchases));
            }
        }

        private RelayCommand? _filterCommand;
        public RelayCommand FilterCommand
        {
            get
            {
                return _filterCommand ??
                    (_filterCommand = new RelayCommand(obj =>
                    {
                        if (SelectedStartDate == null || SelectedEndDate == null)
                        {
                            return;
                        }

                        // Фильтрация данных по диапазону дат и группировка по покупателям
                        var buyerPurchases = db.Items
                            .Where(i => i.BuyerId.HasValue && i.Auction.Date >= SelectedStartDate.Value && i.Auction.Date <= SelectedEndDate.Value)
                            .GroupBy(i => new
                            {
                                i.Buyer.BuyerName // Группируем по имени покупателя
                            })
                            .Select(g => new
                            {
                                BuyerName = g.Key.BuyerName, // Имя покупателя
                                ItemCount = g.Count()         // Количество купленных товаров
                            })
                            .ToList();

                        // Преобразуем список в ObservableCollection с анонимными типами
                        BuyerPurchases = new ObservableCollection<dynamic>(buyerPurchases);
                    }));
            }
        }
    }
}
