using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'page_widgets' table
    public class PageWidget : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string PageId { get; set; }

        [StringLength(255)]
        public string Order { get; set; }

        [StringLength(255)]
        public string ProductCategoryTitle { get; set; }

        [StringLength(255)]
        public string ProductCategoryId { get; set; }

        [StringLength(255)]
        public string ProductCategoryType { get; set; }

        [StringLength(255)]
        public string ProductCategorySliderLoop { get; set; }

        [StringLength(255)]
        public string ProductCategorySliderAutoplay { get; set; }

        [StringLength(255)]
        public string ProductCategoryLimit { get; set; }

        [StringLength(255)]
        public string TabProductCollectionId { get; set; }

        [StringLength(255)]
        public string TabProductCollectionType { get; set; }

        [StringLength(255)]
        public string TabProductCollectionSliderLoop { get; set; }

        [StringLength(255)]
        public string TabProductCollectionSliderAutoplay { get; set; }

        [StringLength(255)]
        public string TabProductCollectionLimit { get; set; }

        [StringLength(255)]
        public string ProductCollectionTitle { get; set; }

        [StringLength(255)]
        public string ProductCollectionId { get; set; }

        [StringLength(255)]
        public string ProductCollectionType { get; set; }

        [StringLength(255)]
        public string ProductCollectionSliderLoop { get; set; }

        [StringLength(255)]
        public string ProductCollectionSliderAutoplay { get; set; }

        [StringLength(255)]
        public string ProductCollectionLimit { get; set; }

        [StringLength(255)]
        public string CategorySliderTitle { get; set; }

        [StringLength(255)]
        public string CategorySliderLoop { get; set; }

        [StringLength(255)]
        public string CategorySliderAutoplay { get; set; }

        [StringLength(255)]
        public string CategorySliderIds { get; set; }

        [StringLength(255)]
        public string BrandSliderTitle { get; set; }

        [StringLength(255)]
        public string BrandSliderLoop { get; set; }

        [StringLength(255)]
        public string BrandSliderAutoplay { get; set; }

        [StringLength(255)]
        public string BrandSliderIds { get; set; }

        [StringLength(255)]
        public string ThreeCBannerLink1 { get; set; }

        [StringLength(255)]
        public string ThreeCBannerImage1 { get; set; }

        [StringLength(255)]
        public string ThreeCBannerLink2 { get; set; }

        [StringLength(255)]
        public string ThreeCBannerImage2 { get; set; }

        [StringLength(255)]
        public string ThreeCBannerLink3 { get; set; }

        [StringLength(255)]
        public string ThreeCBannerImage3 { get; set; }

        [StringLength(255)]
        public string TwoCBannerLink1 { get; set; }

        [StringLength(255)]
        public string TwoCBannerImage1 { get; set; }

        [StringLength(255)]
        public string TwoCBannerLink2 { get; set; }

        [StringLength(255)]
        public string TwoCBannerImage2 { get; set; }

        [StringLength(255)]
        public string OneCBannerLink1 { get; set; }

        [StringLength(255)]
        public string OneCBannerImage1 { get; set; }

        [StringLength(255)]
        public string TextTitle { get; set; }

        public string TextContent { get; set; } // longtext maps to string

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
