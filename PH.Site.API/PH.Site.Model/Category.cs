using PH.Site.Model.BaseModel;
using System;

namespace PH.Site.Model
{
    public class Category : AggregateRoot
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
