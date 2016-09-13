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
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class ReportListActivity : Activity
    {
        private ListView reportListView;
        private ListReportAdapter reportListAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.report_list);
            reportListView = FindViewById<ListView>(Resource.Id.listReportView);
            var createReportButton = FindViewById<Button>(Resource.Id.addNewReport);
            createReportButton.Click += CreateReportButton_Click;
            reportListView.ItemClick += ReportListView_ItemClick;
        }

        private void ReportListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(DetailReportActivity));
            intent.PutExtra("TaskID", reportListAdapter[e.Position].ID);
            StartActivity(intent);
        }

        private void CreateReportButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(DetailReportActivity));
        }

        protected override void OnResume()
        {
            base.OnResume();
            reportListAdapter = new ListReportAdapter(this, Client.GetAllReports() as List<Report>);
            reportListView.Adapter = reportListAdapter;
        }
    }
}