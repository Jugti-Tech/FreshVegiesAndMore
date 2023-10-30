

namespace FreshVegiesAndMore.Models
{
    public partial class Vegetable : IRealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = new ObjectId();

        [MapTo("vegetableName")]
        public string VegetableName { get; set; }

        [MapTo("vegetablePrice")]
        public double VegetablePrice { get; set; }

        [MapTo("vegetableImage")]
        public string VegetableImage { get; set; }

        [MapTo("vegetableDescription")]
        public string VegetableDescription { get; set; }



    }
}
