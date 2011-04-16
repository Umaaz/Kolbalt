using System;

namespace MediaApp.Data.Items
{
    public class ListBoxItem
    {
        public ListBoxItem(Guid id, string text)
        {
            Id = id;
            Text = text;
        }

        public Guid Id { get; private set; }
        public string Text { get; private set; }

        public override string ToString()
        {
            return Text;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var a = obj as ListBoxItem;
            if (a == null) return false;
            return a.Id == Id;
        }
    }
}