using System;
using System.Linq;
using System.Windows.Forms;
using MediaApp.Data;
using MediaApp.Domain;
using MediaApp.Domain.Model;
using NHibernate;
using NHibernate.Linq;
using ListViewItem = MediaApp.Data.AlarmListViewItem;

namespace MediaApp
{
    public partial class ClkSettings : Form
    {
        private static readonly ISession _nhSession = NhContext.GetSession();
        public ClkSettings()
        {
            InitializeComponent();
            updateView();
        }

        private void updateView()
        {
            var alarms = _nhSession.Query<Alarms>().ToList();
            foreach (var alarmse in alarms)
            {
                var newAlarm = new ListViewItem(alarmse.Id, alarmse.Hours, alarmse.Mins);
                lv_Alarms.Items.Add(newAlarm.ToString());
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            using(var tx = _nhSession.BeginTransaction())
            {
                _nhSession.Save( new Alarms() { Hours = (int)NSel_Hours.Value, Mins = (int)NSel_Minutes.Value });
                tx.Commit();
            }
            updateView();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            using(var tx = _nhSession.BeginTransaction())
            {
                var selected = lv_Alarms.SelectedItems;
                _nhSession.Delete(selected);
            }
            updateView();
        }
    }
}
