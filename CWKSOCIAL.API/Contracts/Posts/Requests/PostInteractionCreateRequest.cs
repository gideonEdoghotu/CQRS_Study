using CWKSOCIAL.Domain.Aggregates.PostAggregate;
using System.ComponentModel.DataAnnotations;

namespace CWKSOCIAL.API.Contracts.Posts.Requests
{
    public class PostInteractionCreateRequest
    {
        [Required]
        public InteractionType Type { get; set; }
    }
}
