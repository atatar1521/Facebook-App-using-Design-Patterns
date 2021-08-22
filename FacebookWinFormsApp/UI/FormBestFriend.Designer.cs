namespace BasicFacebookFeatures
{
    partial class FormBestFriend
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFriendLikesYouTheMost = new System.Windows.Forms.Button();
            this.textBoxFriendLikeYouTheMost = new System.Windows.Forms.TextBox();
            this.textBoxFriendCommentYouTheMost = new System.Windows.Forms.TextBox();
            this.buttonFriendCommetYouTheMost = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Font = new System.Drawing.Font("Rockwell", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Who Is Your Best Friend?";
            // 
            // buttonFriendLikesYouTheMost
            // 
            this.buttonFriendLikesYouTheMost.BackColor = System.Drawing.Color.LightGray;
            this.buttonFriendLikesYouTheMost.Enabled = false;
            this.buttonFriendLikesYouTheMost.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFriendLikesYouTheMost.Location = new System.Drawing.Point(12, 78);
            this.buttonFriendLikesYouTheMost.Name = "buttonFriendLikesYouTheMost";
            this.buttonFriendLikesYouTheMost.Size = new System.Drawing.Size(222, 76);
            this.buttonFriendLikesYouTheMost.TabIndex = 1;
            this.buttonFriendLikesYouTheMost.Text = " Friend Who Likes You The Most";
            this.buttonFriendLikesYouTheMost.UseVisualStyleBackColor = false;
            this.buttonFriendLikesYouTheMost.Click += new System.EventHandler(this.buttonFriendLikesYouTheMost_Click);
            // 
            // textBoxFriendLikeYouTheMost
            // 
            this.textBoxFriendLikeYouTheMost.Location = new System.Drawing.Point(12, 160);
            this.textBoxFriendLikeYouTheMost.Multiline = true;
            this.textBoxFriendLikeYouTheMost.Name = "textBoxFriendLikeYouTheMost";
            this.textBoxFriendLikeYouTheMost.Size = new System.Drawing.Size(222, 54);
            this.textBoxFriendLikeYouTheMost.TabIndex = 2;
            // 
            // textBoxFriendCommentYouTheMost
            // 
            this.textBoxFriendCommentYouTheMost.Location = new System.Drawing.Point(251, 160);
            this.textBoxFriendCommentYouTheMost.Multiline = true;
            this.textBoxFriendCommentYouTheMost.Name = "textBoxFriendCommentYouTheMost";
            this.textBoxFriendCommentYouTheMost.Size = new System.Drawing.Size(222, 54);
            this.textBoxFriendCommentYouTheMost.TabIndex = 4;
            // 
            // buttonFriendCommetYouTheMost
            // 
            this.buttonFriendCommetYouTheMost.BackColor = System.Drawing.Color.LightGray;
            this.buttonFriendCommetYouTheMost.Enabled = false;
            this.buttonFriendCommetYouTheMost.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFriendCommetYouTheMost.Location = new System.Drawing.Point(251, 78);
            this.buttonFriendCommetYouTheMost.Name = "buttonFriendCommetYouTheMost";
            this.buttonFriendCommetYouTheMost.Size = new System.Drawing.Size(222, 76);
            this.buttonFriendCommetYouTheMost.TabIndex = 3;
            this.buttonFriendCommetYouTheMost.Text = " Friend Who Comments You The Most";
            this.buttonFriendCommetYouTheMost.UseVisualStyleBackColor = false;
            this.buttonFriendCommetYouTheMost.Click += new System.EventHandler(this.buttonFriendCommetYouTheMost_Click);
            // 
            // FormBestFriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BasicFacebookFeatures.Properties.Resources.question_mark_background_1909040_960_720;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(507, 256);
            this.Controls.Add(this.textBoxFriendCommentYouTheMost);
            this.Controls.Add(this.buttonFriendCommetYouTheMost);
            this.Controls.Add(this.textBoxFriendLikeYouTheMost);
            this.Controls.Add(this.buttonFriendLikesYouTheMost);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "FormBestFriend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormBestFriend";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFriendLikesYouTheMost;
        private System.Windows.Forms.TextBox textBoxFriendLikeYouTheMost;
        private System.Windows.Forms.TextBox textBoxFriendCommentYouTheMost;
        private System.Windows.Forms.Button buttonFriendCommetYouTheMost;
    }
}