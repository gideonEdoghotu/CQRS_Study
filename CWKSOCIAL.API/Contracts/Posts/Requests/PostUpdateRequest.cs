using System.ComponentModel.DataAnnotations;

namespace CWKSOCIAL.API.Contracts.Posts.Requests
{
    public class PostUpdateRequest
    {
        [Required]
        public string Text { get; set; }
    }
}
