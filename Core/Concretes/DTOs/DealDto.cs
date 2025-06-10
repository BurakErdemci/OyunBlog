namespace Core.Concretes.DTOs
{
    public class DealDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DiscountPercent { get; set; }
        public int OriginalPrice { get; set; }
        public int FinalPrice { get; set; }
        public string LargeCapsuleImage { get; set; }
        public string HeaderImage { get; set; }
        public string Platform { get; set; } // Steam, Epic, etc.
        public string GameUrl { get; set; } // For Epic Games direct link
    }
} 