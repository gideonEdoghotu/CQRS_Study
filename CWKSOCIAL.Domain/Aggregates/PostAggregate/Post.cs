using CWKSOCIAL.Domain.Aggregates.UserProfileAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWKSOCIAL.Domain.Aggregates.PostAggregate
{
    public class Post
    {
        
        private Post()
        {
        }

        // factories
        public static Post CreateUserProfile(Guid userProfileId, string text)
        {
            // TODO: Add validation, error handling strategies, error notification strategies

            return new Post()
            {
                UserProfileId = userProfileId,
                Text = text,
                CreatedDate = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
            };
        }

        //public methods
        public void UpdatePost(string newPost)
        {
            Text = newPost;
            LastModified = DateTime.UtcNow;
        }

        public void AddPostComment(PostComment newComment)
        {
            _comments.Add(newComment);
        }

        public void RemovePostComment(PostComment toRemove)
        {
            _comments.Remove(toRemove);
        }

        public void AddInteraction(PostInteraction newInteraction)
        {
            _interactions.Add(newInteraction);
        }

        public void RemoveInteraction(PostInteraction toRemove)
        {
            _interactions.Remove(toRemove);
        }



        public Guid Id { get; private set; }
        public Guid UserProfileId { get; private set; }
        public UserProfile UserProfile { get; private set; }
        public string Text { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime LastModified {  get; private set; }
        public IEnumerable<PostComment> Comments { get { return _comments; } }
        public IEnumerable<PostInteraction> Interactions { get { return _interactions; } }
        private readonly List<PostComment> _comments = new List<PostComment>();
        private readonly List<PostInteraction> _interactions = new List<PostInteraction>();
    }
}
