using CWKSOCIAL.Domain.Aggregates.UserProfileAggregate;
using CWKSOCIAL.Domain.Exceptions;
using CWKSOCIAL.Domain.Validators.PostValidators;
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
        /// <summary>
        /// Creates a new post instance
        /// </summary>
        /// <param name="userProfileId">User profile ID</param>
        /// <param name="text">Post content</param>
        /// <returns><see cref="Post"/></returns>
        /// <exception cref="PostNotValidException"></exception>
        public static Post CreatePost(Guid userProfileId, string text)
        {
            var validator = new PostValidator();
            var objectToValidate = new Post
            {
                UserProfileId = userProfileId,
                Text = text,
                CreatedDate = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
            };

            var validationResult = validator.Validate(objectToValidate);

            if (validationResult.IsValid) return objectToValidate;

            var exception = new PostNotValidException("Post is not valid");
            validationResult.Errors.ForEach(vr => exception.ValidationErrors.Add(vr.ErrorMessage));
            throw exception;
        }

        //public methods
        /// <summary>
        /// Updates the post text
        /// </summary>
        /// <param name="newText">The updated post text</param>
        /// <exception cref="PostNotValidException"></exception>
        public void UpdatePostText(string newText)
        {
            if (string.IsNullOrWhiteSpace(newText))
            {
                var exception = new PostNotValidException("Cannot update post." +
                                                          "Post text is not valid");
                exception.ValidationErrors.Add("The provided text is either null or contains only white space");
                throw exception;
            }
            Text = newText;
            LastModified = DateTime.UtcNow;
        }

        public void AddPostComment(PostComment newComment)
        {
            _comments.Add(newComment);
        }

        public void UpdatePostComment(Guid postCommentId, string updatedComment)
        {
            var comment = _comments.FirstOrDefault(c => c.Id == postCommentId);
            if (comment != null && !string.IsNullOrWhiteSpace(updatedComment))
                comment.UpdateCommentText(updatedComment);
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
