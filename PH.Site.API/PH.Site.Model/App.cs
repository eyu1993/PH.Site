using PH.Site.Model.BaseModel;
using System;

namespace PH.Site.Model
{
    public class App : AggregateRoot
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string CodeUrl { get; set; }
        public string Description { get; set; }
    }
}
