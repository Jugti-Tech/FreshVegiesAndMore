

namespace FreshVegiesAndMore.Models
{
    public partial class Address : IEmbeddedObject
    {
        [MapTo("street")]
        public string Street { get; set; }

        [MapTo("city")]
        public string City { get; set; }

        [MapTo("state")]
        public string State { get; set; }

        [MapTo("zip")]
        public string Zip { get; set; }

        [MapTo("country")]
        public string Country { get; set; }


    }
}
