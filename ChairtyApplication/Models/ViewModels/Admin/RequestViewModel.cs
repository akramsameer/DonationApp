using System;

namespace ChairtyApplication.Models.ViewModels.Admin
{
    public class RequestViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string NationalId { get; set; }

        public string BloodType { get; set; }

        public string ProblemStatement { get; set; }
        public double? RequiredMoney { get; set; }
        public string AssignUserName { get; set; }
        public string AssignId { get; set; }
    }
}