using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class SomeViewModel : INameModel, IValueModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        public int? Value { get; set; }
    }
    public class SomeCreateModel : INameModel, IValueModel
    {
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        public int? Value { get; set; }
    }
    public class SomeEditModel : INameModel, IValueModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        public int? Value { get; set; }
    }
}