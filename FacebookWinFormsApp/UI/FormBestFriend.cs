using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System.Threading;

namespace BasicFacebookFeatures
{
    public partial class FormBestFriend : Form
    {
        private User m_LoggedInUser;

        private BestFriendLogic m_BestFriend;

        public FormBestFriend(User i_LoggedInUser = null)
        {
            m_LoggedInUser = i_LoggedInUser;
            m_BestFriend = new BestFriendLogic(m_LoggedInUser);
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            new Thread(fetchTheFriendCommentedTheMostOnPosts).Start();
            new Thread(fetchTheFriendLikedTheMostOnPosts).Start();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            textBoxFriendLikeYouTheMost.Text = string.Empty;
            textBoxFriendCommentYouTheMost.Text = string.Empty;
        }

        private void fetchTheFriendCommentedTheMostOnPosts()
        {
            try
            {
                if (m_BestFriend.FetchTheFriendCommentedTheMostOnPosts() != null)
                {
                    textBoxFriendCommentYouTheMost.Invoke(new Action(() =>
                    textBoxFriendCommentYouTheMost.Text = m_BestFriend.FetchTheFriendCommentedTheMostOnPosts()));
                }
            }
            catch (Exception)
            {
                textBoxFriendCommentYouTheMost.Invoke(new Action(() =>
                textBoxFriendCommentYouTheMost.Text = "There are no permissions to see the amount of comments your friends have done"));
            }
        }

        private void fetchTheFriendLikedTheMostOnPosts()
        {
            try
            {
                if (m_BestFriend.FetchTheFriendLikedTheMostOnPosts() != null)
                {
                    textBoxFriendLikeYouTheMost.Invoke(new Action(() =>
                    textBoxFriendLikeYouTheMost.Text = m_BestFriend.FetchTheFriendLikedTheMostOnPosts()));
                }
            }
            catch (Exception)
            {
                textBoxFriendLikeYouTheMost.Invoke(new Action(() =>
                textBoxFriendLikeYouTheMost.Text = "There are no permissions to see the amount of likes your friends have done"));
            }
        }

        private void buttonFriendCommetYouTheMost_Click(object sender, EventArgs e)
        {
        }

        private void buttonFriendLikesYouTheMost_Click(object sender, EventArgs e)
        {
        }
    }
}
