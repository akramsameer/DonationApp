using System.ComponentModel.DataAnnotations;

namespace ChairtyApplication.Models.ViewModels.Admin
{
    public class AdvertiseVm
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Image { get; set; }
    }
}