using CWKSOCIAL.Domain.Aggregates.UserProfileAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWKSOCIAL.Domain.Aggregates.PostAggregate
{
    public class PostInteraction
    {
        private PostInteraction()
        {
        }

        public static PostInteraction CreatePostInteraction(Guid id, InteractionType type)
        {
            // TODO: Add validation, error handling strategies, error notification strategies

            return new PostInteraction()
            {
                Id = id,
                InteractionType = type
            };
        }



        public Guid Id { get; private set; }
        public Guid PostId { get; private set; }
        public InteractionType InteractionType { get; private set; }
    }
}
