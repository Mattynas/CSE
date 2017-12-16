using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using shopGuru_android.controller;

namespace shopGuru_android

{
    public class OnSignUpEventArgs : EventArgs
    {
        public OnSignUpEventArgs(string name, string email, string password, string confirmPassword)
        {
            Name = name;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class SignUpFragment : DialogFragment
    {
        private EditText _txtName;
        private EditText _txtEmail;
        private EditText _txtPassword;
        private EditText _txtConfirmPassword;
        private EditText _txtPhoneNumber;
        private Button _btnSignUp;

        public event EventHandler<OnSignUpEventArgs> OnSignUpComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
           
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.fragment_signUp, container, false);

            _txtName = view.FindViewById<EditText>(Resource.Id.txtName);
            _txtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            _txtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            _txtConfirmPassword = view.FindViewById<EditText>(Resource.Id.txtConfirmPassword);
            _txtPhoneNumber = view.FindViewById<EditText>(Resource.Id.txtPhone);
            _btnSignUp = view.FindViewById<Button>(Resource.Id.btnSignUp);

            _btnSignUp.Click += BtnSignUp_Click;
            
            return view;
        }

        void BtnSignUp_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.Activity.GetSystemService(Context.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.Activity.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);

            if (DataController.RegisterDataSubmition(_txtName.Text, _txtPassword.Text, _txtEmail.Text, _txtPhoneNumber.Text))
            {
                this.Activity.RunOnUiThread(() => Toast.MakeText(this.Activity.ApplicationContext, "Registration successful!", ToastLength.Long).Show());
                this.Dismiss();
            }
            else
            {
                this.Activity.RunOnUiThread(() =>Toast.MakeText(this.Activity.ApplicationContext, "Invalid registration input", ToastLength.Long).Show());
            }
        }
    }
}