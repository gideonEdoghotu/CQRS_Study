using System.ComponentModel.DataAnnotations;

namespace CWKSOCIAL.API.Contracts.Posts.Requests
{
    public class CreatePostRequest
    {
        [Required]
        public string TextContent { get; set; }
    }
}
