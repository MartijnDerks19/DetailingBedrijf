
namespace DomeinLaag.Models
{
    public class DetailerModel
    {
        private int _detailerID;
        private string _naam;
        private List<AfspraakModel> _afspraken = new();

        public int DetailerID { get; set; }
        public string Naam { get ; set; }
        public List<AfspraakModel> AfsprakenDetailer { get { return _afspraken;} set { _afspraken = value; } }
    }
}
