using System.ComponentModel.DataAnnotations;

namespace CWKSOCIAL.API.Contracts.Posts.Requests
{
    public class PostCommentUdpateRequest
    {
        [Required]
        public string Text { get; set; }
    }
}
