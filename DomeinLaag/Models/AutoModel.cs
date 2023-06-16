namespace DomeinLaag.Models
{
    public class AutoModel
    {
        public int AutoID { get; set; }
        public string Merk { get; set; }
        public string Type { get; set; }
        public int Bouwjaar { get; set; }
        public int EigenaarID { get; set; }
    }
}
