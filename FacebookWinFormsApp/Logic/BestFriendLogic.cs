using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class BestFriendLogic
    {
        private User m_LoggedInUser;

        public BestFriendLogic(User i_LoggedInUser)
        {
            m_LoggedInUser = i_LoggedInUser;
        }

        public string FetchTheFriendCommentedTheMostOnPosts()
        {
            User mostCommentedFriend = null;
            Dictionary<string, FacebookUserWrapper> friendsComments = new Dictionary<string, FacebookUserWrapper>();
            if (m_LoggedInUser.Friends.Count > 0)
                {
                    foreach (User fbFriend in m_LoggedInUser.Friends)
                    {
                        friendsComments.Add(fbFriend.Id, new FacebookUserWrapper(fbFriend));
                    }

                    updateFriendsCommentsCounter(friendsComments);
                    mostCommentedFriend = getMaximumCounter(friendsComments);
                }

            return updateMostCommentedFriend(mostCommentedFriend);
        }

        public string FetchTheFriendLikedTheMostOnPosts()
        {
            User mostLikelyFreind = null;
            Dictionary<string, FacebookUserWrapper> friendsLikes = new Dictionary<string, FacebookUserWrapper>();
            if (m_LoggedInUser.Friends.Count > 0)
                {
                    foreach (User fbFriend in m_LoggedInUser.Friends)
                    {
                        friendsLikes.Add(fbFriend.Id, new FacebookUserWrapper(fbFriend));
                    }

                    updateFriendsLikesCounter(friendsLikes);
                    mostLikelyFreind = getMaximumCounter(friendsLikes);
                }

            return updateMostLikelyFriend(mostLikelyFreind);
        }

        private string updateMostCommentedFriend(User i_FriendMaxCommented)
        {
            if (i_FriendMaxCommented != null)
            {
                return i_FriendMaxCommented.UserName;
            }
            else
            {
                return "There are no friends that Commented your post";
            }
        }

        private void updateFriendsCommentsCounter(Dictionary<string, FacebookUserWrapper> i_FbFriendsCollection)
        {
            foreach (Post post in m_LoggedInUser.Posts)
            {
                foreach (Comment comment in post.Comments)
                {
                    if (i_FbFriendsCollection.ContainsKey(comment.From.Id))
                    {
                        i_FbFriendsCollection[comment.From.Id].m_Counter++;
                    }
                }
            }
        }

        private User getMaximumCounter(Dictionary<string, FacebookUserWrapper> i_FbFriendsCollection)
        {
            int maxCounter = 0;
            User friendToReturn = null;

            foreach (KeyValuePair<string, FacebookUserWrapper> friend in i_FbFriendsCollection)
            {
                if (friend.Value.m_Counter > maxCounter)
                {
                    friendToReturn = friend.Value.m_UserWrapper;
                    maxCounter = friend.Value.m_Counter;
                }
            }

            return friendToReturn;
        }

        private string updateMostLikelyFriend(User i_FriendMaxCommented)
        {
            if (i_FriendMaxCommented != null)
            {
                return i_FriendMaxCommented.UserName;
            }
            else
            {
                return "There are no friends that Liked your post";
            }
        }

        private void updateFriendsLikesCounter(Dictionary<string, FacebookUserWrapper> i_FbFriendsCollection)
        {
            foreach (Post post in m_LoggedInUser.Posts)
            {
                foreach (User fbFriend in post.LikedBy)
                {
                    if (i_FbFriendsCollection.ContainsKey(fbFriend.Id))
                    {
                        i_FbFriendsCollection[fbFriend.Id].m_Counter++;
                    }
                }
            }
        }
    }
}