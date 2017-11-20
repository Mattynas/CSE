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
using Android.Widget;
using shopGuru_android.authenticator;
using System.Xml;
using System.Web.Services;
using shopGuru_android.mano;

namespace shopGuru_android

{
    public class OnSignUpEventArgs : EventArgs
    {
        private string name;
        private string email;
        private string password;
        private string confirmPassword;

        public OnSignUpEventArgs(string name, string email, string password, string confirmPassword)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.confirmPassword = confirmPassword;
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
        private Button _btnSignUp;

        public event EventHandler<OnSignUpEventArgs> onSignUpComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
           
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.fragment_signUp, container, false);

            _txtName = view.FindViewById<EditText>(Resource.Id.txtName);
            _txtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            _txtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            _txtConfirmPassword = view.FindViewById<EditText>(Resource.Id.txtConfirmPassword);
            _btnSignUp = view.FindViewById<Button>(Resource.Id.btnSignUpLog);

            _btnSignUp.Click += btnSignUp_Click;
            
            return view;
        }

        void btnSignUp_Click(object sender, EventArgs e)
        {
            //User clicked the button
            UserDataValidation.RegisterValidation(_txtName.Text, _txtEmail.Text, _txtPassword.Text, _txtConfirmPassword.Text);
            onSignUpComplete.Invoke(this, new OnSignUpEventArgs(_txtName.Text,_txtEmail.Text, _txtPassword.Text, _txtConfirmPassword.Text));

            var client = new shopGuru_webService();
            client.Register(_txtName.Text, _txtPassword.Text);
            this.Dismiss();
        }
    }
}