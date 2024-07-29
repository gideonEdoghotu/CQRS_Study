using System.ComponentModel.DataAnnotations;

namespace CWKSOCIAL.API.Contracts.Posts.Requests
{
    public class PostCommentCreateRequest
    {
        [Required]
        public string Text { get; set; }
    }
}
