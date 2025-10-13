namespace CurrentService.WEBUI.Models
{
    public class SatFatBaslikDto
    {
        public int IND { get; set; }
        public string? FIRMAADI { get; set; }
        public string? BELGENO { get; set; }
        public DateTime? TARIH { get; set; }
        public bool? KDV { get; set; }
        public DateTime? ODEMETARIHI { get; set; }
        public bool? IADE { get; set; }
        public bool? IPTAL { get; set; }
        public decimal? TAHSILATTUTARI { get; set; }
        public string? PARABIRIMI { get; set; }
        public decimal? ARATOPLAM { get; set; }
    }
}
