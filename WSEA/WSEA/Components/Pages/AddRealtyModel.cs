namespace WSEA.Components.Pages
{
    public class AddRealtyModel
    {
        public enum AddingType
        {
            Flatroom,
            Lantplot,
            House,
            Commerce
        }

        public AddingType realtyType { get; set; }
    }
}
