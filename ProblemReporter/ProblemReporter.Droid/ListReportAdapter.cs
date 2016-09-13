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
    public class ListReportAdapter : BaseAdapter<Report>
    {
        private List<Report> Reports { get; set; }
        private Activity Context { get; set; }

        public ListReportAdapter(Activity context, List<Report> reports) : base()
        {
            Context = context;
            Reports = reports;
        }

        public override Report this[int position]
        {
            get
            {
                return Reports[position];
            }
        }

        public override int Count
        {
            get
            {
                return Reports.Count;
            }
        }

        public override long GetItemId(int position)
        {
            //Controllore utilizzo
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var report = Reports[position];
            var view = convertView;
            if (view == null)
                view = Context.LayoutInflater.Inflate(Resource.Layout.report, null);
            view.FindViewById<TextView>(Resource.Id.report_title).Text = report.Title;
            view.FindViewById<TextView>(Resource.Id.report_description).Text = report.Description;
            var date = report.Date;
            string dateString = $"{date.Day}/{date.Month}/{date.Year} {date.Hour}:{date.Minute}";
            view.FindViewById<TextView>(Resource.Id.report_date).Text = dateString;

            return view;
        }
    }
}