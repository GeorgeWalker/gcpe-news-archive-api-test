// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Gov.News.Archive.Api.Models
{
    using MongoDB.Bson;
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Archive
    {
        /// <summary>
        /// Initializes a new instance of the Archive class.
        /// </summary>
        public Archive()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Archive class.
        /// </summary>
        public Archive(ObjectId id = default(ObjectId), ObjectId collectionId = default(ObjectId), Collection collection = default(Collection), string title = default(string), BsonDateTime dateReleased = default(BsonDateTime), string ministryText = default(string), string htmlContent = default(string), string textContent = default(string))
        {
            Id = id;
            CollectionId = collectionId;
            Collection = collection;
            Title = title;
            DateReleased = dateReleased;
            MinistryText = ministryText;
            HtmlContent = htmlContent;
            TextContent = textContent;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public ObjectId Id { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "collectionId")]
        public ObjectId CollectionId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "collection")]
        public Collection Collection { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dateReleased")]
        public BsonDateTime DateReleased { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ministryText")]
        public string MinistryText { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "htmlContent")]
        public string HtmlContent { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "textContent")]
        public string TextContent { get; set; }

    }
}