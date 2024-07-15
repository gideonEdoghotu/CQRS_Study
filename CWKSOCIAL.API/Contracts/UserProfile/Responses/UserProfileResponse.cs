﻿namespace CWKSOCIAL.API.Contracts.UserProfile.Responses
{
    public record UserProfileResponse()
    {
        public Guid UserProfileId { get; set; }
        public BasicInformationResponse? BasicInfo { get; set; }
        public DateTime DateCreated { get; private set; }
        public DateTime LastModified { get; private set; }
        //public List<FriendRequest> FriendRequests { get; set; } = new();
        //public List<Friend> Friends { get; set; } = new();

        //public static UserProfileResponse FromUserProfileDto(UserProfileDto profile)
        //{
        //    var profileResponse = new UserProfileResponse { UserProfileId = profile.UserProfileId };
        //    profileResponse.BasicInfo = BasicInformation.FromUserInfoDto(profile.UserInfo);
        //    profile.FriendRequests.ForEach(fr
        //        => profileResponse.FriendRequests.Add(FriendRequest.FromFriendRequestDto(fr)));
        //    profile.Friends.ForEach(f
        //        => profileResponse.Friends.Add(Friend.FromFriendDto(f)));
        //    return profileResponse;
        //}
    }
}
