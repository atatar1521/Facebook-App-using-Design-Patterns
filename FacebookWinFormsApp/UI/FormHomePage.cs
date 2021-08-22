using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using System.Threading;
using BasicFacebookFeatures.UI;
using BasicFacebookFeatures.Logic;

namespace BasicFacebookFeatures
{
    public partial class FormHomePage : Form
    {
        private User m_LoggedInUser;
        private LoginResult m_LoginResult;
        private FormMostAttractive m_FormMostAttractiveItems;
        private ProxyPosts m_ProxyPost;
        private FormBestFriend m_FormBestFriend;
        private FormEventComposer m_FormEvents;

        public FormHomePage(LoginResult i_LoggedInResult, User i_LoggedInUser = null)
        {
            m_LoggedInUser = i_LoggedInUser;
            m_LoginResult = i_LoggedInResult;
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            firstPart();
            secondPart();
            fetchAllPosts();
            new Thread(fetchUserInfo).Start();
            new Thread(fetchAllFriends).Start();
            new Thread(fetchAllAlbums).Start();
        }

        private void firstPart()
        {
            m_ProxyPost = new ProxyPosts(m_LoggedInUser);
            m_FormMostAttractiveItems = new FormMostAttractive(m_ProxyPost, m_LoggedInUser);
            m_FormEvents = new FormEventComposer(m_LoggedInUser);
        }

        private void secondPart()
        {
            m_FormBestFriend = new FormBestFriend(m_LoggedInUser);
        }

        private void fetchUserInfo()
        {
            pictureBoxProfile.LoadAsync(m_LoggedInUser.PictureNormalURL);
            labelProfileName.Invoke(new Action(() => labelProfileName.Text = $"{m_LoginResult.LoggedInUser.Name}"));
            labelBirthday.Invoke(new Action(() => labelBirthday.Text = $"Your Birthday : {m_LoginResult.LoggedInUser.Birthday}"));
            labelGender.Invoke(new Action(() => labelGender.Text = $"Gender : {m_LoginResult.LoggedInUser.Gender}"));
        }

        private void fetchAllFriends()
        {
            friendsListBox.Invoke(new Action(() => friendsListBox.Items.Clear()));
            friendsListBox.Invoke(new Action (() => friendsListBox.DisplayMember = "Name"));
            foreach (User friend in m_LoggedInUser.Friends)
            {
                friendsListBox.Invoke(new Action(() => friendsListBox.Items.Add(friend)));
            }

            if (friendsListBox.Items.Count == 0)
            {
                MessageBox.Show("No Friends to retrieve :(");
            }
        }

        private void fetchFriendsHaveBirthday()
        {
            try
            {
                DateTime today = DateTime.Now;
                listBoxBirthday.Items.Clear();
                if (m_LoggedInUser.Friends.Count > 0)
                {
                    foreach (User friend in m_LoggedInUser.Friends)
                    {
                        if (DateTime.Parse(friend.Birthday) == today)
                        {
                            listBoxBirthday.Items.Add(friend.Name);
                        }
                    }

                    if (listBoxBirthday.Items.Count == 0)
                    {
                        listBoxBirthday.Items.Add("None of your friends" + Environment.NewLine + "have a birthday today");
                    }
                }
                else
                {
                    listBoxBirthday.Items.Add("The friends list is empty");
                }
            }
            catch (Exception)
            {
                listBoxBirthday.Items.Add("Permission error !!!!");
            }
        }

        private void fetchAllAlbums()
        {
            listBoxAlbums.Invoke(new Action(() => listBoxAlbums.Items.Clear()));
            listBoxAlbums.Invoke(new Action(() => listBoxAlbums.DisplayMember = "Name"));
            foreach (Album album in m_LoggedInUser.Albums)
            {
                listBoxAlbums.Invoke(new Action(() => listBoxAlbums.Items.Add(album)));
            }

            if (listBoxAlbums.Items.Count == 0)
            {
                MessageBox.Show("No albums to retrieve :(");
            }
        }

        private void fetchAllPosts()
        {
            postBindingSource.DataSource = m_ProxyPost.AllPosts;
        }

        private void buttonMostAttractiveFeature_Click(object sender, EventArgs e)
        {
            if (m_FormMostAttractiveItems != null)
            {
                m_FormMostAttractiveItems.ShowDialog();
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            this.Close();
            m_LoginResult = null;
        }

        private void buttonBestFriend_Click(object sender, EventArgs e)
        {
            if (m_FormBestFriend != null)
            {
                m_FormBestFriend.ShowDialog();
            }
        }

        private void buttonPostStatus_Click(object sender, EventArgs e)
        {
            postStatus();
        }

        private void friendsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaySelectedFriend();
        }

        private void displaySelectedFriend()
        {
            if (friendsListBox.SelectedItems.Count == 1)
            {
                User selectedFriend = friendsListBox.SelectedItem as User;
                if (selectedFriend.PictureNormalURL != null)
                {
                    pictureBoxSelectedFriend.LoadAsync(selectedFriend.PictureNormalURL);
                }
                else
                {
                    pictureBoxSelectedFriend.Image = null;
                }
            }
        }

        private void postStatus()
        {
            try
            {
                this.m_LoggedInUser.PostStatus(textBoxPostStatus.Text);
                textBoxPostStatus.Text = string.Empty;
                MessageBox.Show("Status Posted!");
            }
            catch
            {
                MessageBox.Show("not Posted!");
            }
        }

        private void buttonEvents_Click(object sender, EventArgs e)
        {
            if (m_FormEvents != null)
            {
                m_FormEvents.ShowDialog();
            }
        }

        private void FormHomePage_Load(object sender, EventArgs e)
        {
        }

        private void linkLabelBirthday_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fetchFriendsHaveBirthday();
        }
    }
}
