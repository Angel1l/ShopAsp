namespace Project.Data.Models
{
    public class Guns
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortDesc { get; set; }
        public string longDesc { get; set; }
        public string img { get; set; }
        public ushort price { get; set; }
        public bool isFavorite { get; set; }
        public int acailable { get; set; }
        public int categoryid { get; set; }
        public virtual Category category { get; set; }
    }
}
