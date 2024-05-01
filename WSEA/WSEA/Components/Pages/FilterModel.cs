namespace WSEA.Components.Pages
{
    public class FilterModel
    {
        public string City { get; set; } = "";
        public string District { get; set; } = "";
        public string Street { get; set; } = "";
        public bool Rent { get; set; }
        public bool NewBuild { get; set; }
        public bool SecondBuild { get; set; }
        public int? RoomCount { get; set; }
        public int? FlootMinimum { get; set; }
        public int? FlootMaximum { get; set; }
        public decimal? CostMinimum { get; set; }
        public decimal? CostMaximum { get; set; }
        public float? SquareObjectMinimum { get; set; }
        public float? SquareObjectMaximum { get; set; }
        public float? LivingSquareMinumum { get; set; }
        public float? LivingSquareMaximum { get; set; }
        public float? KitchenSquareMinimum { get; set; }
        public float? KitchenSquareMaximum { get; set; }
        public int MaterialId { get; set; }
        public int HeatingId { get; set; }
        public int SanitaryId { get; set; }
        public bool Elevator { get; set; }
        public bool Balcony { get; set; }
        public bool Loggia { get; set; }
    }
}
