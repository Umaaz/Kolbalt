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

        public virtual String ToolTipText()
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

    public class GenreListBoxItem : ListBoxItem
    {
        public GenreListBoxItem(Guid id, String genre) : base(id,genre)
        {
            
        }

        public override string ToolTipText()
        {
            return "Genre: " + base.ToolTipText();
        }
    }

    public class PersonListBoxItem : ListBoxItem
    {
        public String Imdbid { get; set; }

        public PersonListBoxItem(Guid id, String imdbid, String name) : base(id,name)
        {
            Imdbid = imdbid;
        }

        public override string ToolTipText()
        {
            return "Name: " + base.ToolTipText() + "\nIMDB ID: " + Imdbid;
        }
    }

    public class RoleListBoxItem : PersonListBoxItem
    {
        public String CharName { get; set; }

        public RoleListBoxItem(Guid id, String imdbid, String actorName, String charName) : base(id,imdbid,actorName)
        {
            CharName = charName;
        }

        public override string ToolTipText()
        {
            return "Character Name: " + CharName +"\n"+ base.ToolTipText();
        }
    }

}