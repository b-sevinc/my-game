using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MyGame.Game;

namespace MyGame.Forms
{
    public partial class AdminForm : Form
    {
        private List<User> _userList = Engine.ReadUsersJson();
        public AdminForm()
        {
            InitializeComponent();
            RefreshForm();
            if (dataGridView1.Columns["Username"] is null) return;
            dataGridView1.Columns["Username"].ReadOnly = true;
        }

        private void RefreshForm()
        {
            _userList = Engine.ReadUsersJson();
            dataGridView1.DataSource = _userList;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (Engine.CurrentUser.UserType != (int)Enums.UserType.Admin) return;
            
            Engine.UpdateUserList();
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
            
            foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
            {
                var user = _userList[selectedRow.Index];
                if (_userList.All(x => x.Username != user.Username)) return;
                Engine.RemoveUser(user);
            }
            
            RefreshForm();
        }
    }
}