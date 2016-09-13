using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ProblemReporter.Droid
{
    [Activity(Label = "@string/app_name")]
    public class DetailReportActivity : Activity
    {
        EditText title;
        EditText description;
        CheckBox isFixed;
        Button createUpdateButton;
        int reportID;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.report_details);

            reportID = Intent.GetIntExtra("TaskID", -1);

            title = FindViewById<EditText>(Resource.Id.title_field_editview);
            description = FindViewById<EditText>(Resource.Id.description_field_editview);
            createUpdateButton = FindViewById<Button>(Resource.Id.create_report_button);
            if (reportID != -1)
            {
                var report = Client.GetReport(reportID);
                title.Text = report.Title;
                description.Text = report.Description;
                isFixed = FindViewById<CheckBox>(Resource.Id.fixed_field_checkbox);
                FindViewById<TextView>(Resource.Id.fixed_field_textview).Visibility = ViewStates.Visible;
                isFixed.Visibility = ViewStates.Visible;
                isFixed.Checked = report.IsFixed;
                createUpdateButton.Text = Resources.GetString(Resource.String.update_report_button);
                createUpdateButton.Click += UpdateReport;
            }
            else
                createUpdateButton.Click += CreateReport;            
        }

        private void CreateReport(object sender, EventArgs e)
        {
            Client.SubmitReport(title.Text, description.Text);
            Finish();
        }

        private void UpdateReport(object sernder, EventArgs e)
        {
            Client.UpdateReport(reportID, title.Text, description.Text, isFixed.Checked);
            Finish();
        }
    }
}