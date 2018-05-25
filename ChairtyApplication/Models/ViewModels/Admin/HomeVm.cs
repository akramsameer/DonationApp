using System.Collections.Generic;

namespace ChairtyApplication.Models.ViewModels.Admin
{
    public class HomeVm
    {
        public List<News> News { get; set; }
        public List<Video> Videos { get; set; }
        public List<Advertise> Advertises { get; set; }
    }
}