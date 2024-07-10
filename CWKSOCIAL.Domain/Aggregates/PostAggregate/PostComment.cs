using CWKSOCIAL.Domain.Aggregates.UserProfileAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWKSOCIAL.Domain.Aggregates.PostAggregate
{
    public class PostComment
    {
        private PostComment()
        {
        }

        public static PostComment CreatePostComment(Guid id, string text, Guid userProfileId)
        {
            // TODO: Add validation, error handling strategies, error notification strategies

            return new PostComment()
            {
                Id = id,
                Text = text,
                UserProfileId = userProfileId,
                DateCreated = DateTime.UtcNow,
                LastModified = DateTime.UtcNow
            };
        }

        public void UpdateComment(string newText)
        {
            Text = newText;
            LastModified = DateTime.UtcNow;
        }




        public Guid Id { get; private set; }
        public Guid PostId { get; private set; }
        public string Text { get; private set; }
        public Guid UserProfileId { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime LastModified { get; private set; }
    }
}
