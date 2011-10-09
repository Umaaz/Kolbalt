using System;

namespace Kolbalt.Client.Data.Items
{
    public class ComboBoxItem
    {
        public string Title { get; set; }
        public ComboBoxItem(String title)
        {
            Title = title;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
