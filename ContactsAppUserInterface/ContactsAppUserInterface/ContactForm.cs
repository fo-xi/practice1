﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUserInterface
{
    public partial class ContactForm : Form
    {
        public Contact Contact { set; get; }
        public ContactForm()
        {
            InitializeComponent();
        }
        private void AddEditContactOKButton_Click(object sender, EventArgs e)
        {
            try
            {
                var phoneNumber = new PhoneNumber(PhoneTextBox.Text);
                Contact = new Contact(SurnameTextBox.Text,
                            NameTextBox.Text, phoneNumber,
                            BirthdayDateTimePicker.Value, EmailTextBox.Text,
                            VkIDTextBox.Text);
                this.Close();
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddEditCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DisplayIinformation(object sender, EventArgs e)
        {
            if (Contact != null)
            {
                SurnameTextBox.Text = Contact.Surname;
                NameTextBox.Text = Contact.Name;
                BirthdayDateTimePicker.Value = Contact.DateBirth;
                PhoneTextBox.Text = Contact.Number.Number;
                EmailTextBox.Text = Contact.Email;
                VkIDTextBox.Text = Contact.VKID;
            }
        }
        private void AddEditContactSurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Validator.AssertStringInRange(SurnameTextBox.Text, 0, 50);
                SurnameTextBox.BackColor = Color.White;
            }
                SurnameTextBox.BackColor = Color.LightSalmon;
            }
        }
        private void AddEditContactNameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Validator.AssertStringInRange(NameTextBox.Text, 0, 50);
                NameTextBox.BackColor = Color.White;
            }
                NameTextBox.BackColor = Color.LightSalmon;
            }
        }
        private void AddEditContactEmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Validator.AssertStringInRange(EmailTextBox.Text, 0, 50);
                EmailTextBox.BackColor = Color.White;
            }
                EmailTextBox.BackColor = Color.LightSalmon;
            }
        }
        private void AddEditContactPhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Validator.AssertPhoneNumber(PhoneTextBox.Text);
                Validator.AssertStringInRange(PhoneTextBox.Text, 0, 11);
                PhoneTextBox.BackColor = Color.White;
            }
            catch
            {
                if (PhoneTextBox.Text.Length == 0)
                {
                    PhoneTextBox.BackColor = Color.White;
                }
                PhoneTextBox.BackColor = Color.LightSalmon;
            }
        }
        private void AddEditContactVkIDTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Validator.AssertStringInRange(VkIDTextBox.Text, 0, 15);
                VkIDTextBox.BackColor = Color.White;
            }
                VkIDTextBox.BackColor = Color.LightSalmon;
            }
        }
    }
}