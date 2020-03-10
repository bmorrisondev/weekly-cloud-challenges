namespace BrianmmAzureApi.Models
{
    public class LineItem
    {
        public string ItemName { get; set; }
        public double? Amount { get; set; }
        public int Quantity { get; set; }
        public double Total { 
            get
            {
                if(Amount != null)
                {
                    return (double)Amount * Quantity;
                }
                return 0.00;
            } 
        }
    }
}