using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MyGame.Game;

namespace MyGame.Forms
{
    public partial class AdminForm : Form
    {
        private List<User> _userList = SqliteDataAccess.LoadUsers();
        public AdminForm()
        {
            InitializeComponent();
            RefreshForm();
            if (dataGridView1.Columns["Username"] is null) return;
            if (dataGridView1.Columns["Password"] is null) return;
            if (dataGridView1.Columns["HighestScore"] is null) return;
            dataGridView1.Columns["Username"].ReadOnly = true;
            dataGridView1.Columns["Password"].ReadOnly = true;
            dataGridView1.Columns["HighestScore"].ReadOnly = true;
        }

        private void RefreshForm()
        {
            _userList = SqliteDataAccess.LoadUsers();
            dataGridView1.DataSource = _userList;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (Engine.CurrentUser.UserType != (int)Enums.UserType.Admin) return;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var user = _userList[row.Index];
                if (_userList.All(x => x.Username != user.Username)) return;
                SqliteDataAccess.UpdateUser(user);
            }
            
            RefreshForm();
            MessageBox.Show("Successfully edited user info.");
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select one user to delete.");
                return;
            }
            
            var result = MessageBox.Show("Are you sure to delete user(s)?", "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No) return;
            
            foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
            {
                var user = _userList[selectedRow.Index];
                if (user.Username == Engine.CurrentUser.Username)
                {
                    MessageBox.Show("You cannot delete your own account.");
                    return;
                }
                if (_userList.All(x => x.Username != user.Username)) return;
                SqliteDataAccess.RemoveUser(user);
            }
            
            RefreshForm();
        }
    }
}