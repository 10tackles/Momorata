namespace Momorata.Core.ViewModels
{
    public class BasketSummaryViewModel
    {
        public int BasketCount { get; set; }
        public decimal BasketTotal { get; set; }

        public BasketSummaryViewModel()
        {

        }

        public BasketSummaryViewModel(int basketCount, decimal basketTotal)
        {
            this.BasketCount = basketCount;
            this.BasketTotal = basketTotal;
        }
    }
}
