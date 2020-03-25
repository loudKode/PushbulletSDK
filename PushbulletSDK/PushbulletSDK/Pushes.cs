using System.ComponentModel;

namespace PushbulletSDK
{
    public class Pushes
    {
        public _Note note_push { get; set; }
        public _Link link_push { get; set; }
        public _File file_push { get; set; }

      public   class _Note
        {
            [Browsable(false)][Bindable(false)][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][EditorBrowsable(EditorBrowsableState.Never)]public Utilitiez.PushTypesEnum type { get; set; }
            public string title { get; set; }
            public string body { get; set; }
        }
        public class _Link
        {
            [Browsable(false)][Bindable(false)][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][EditorBrowsable(EditorBrowsableState.Never)]public Utilitiez.PushTypesEnum type { get; set; }
            public string title { get; set; }
            public string body { get; set; }
            public string url { get; set; }
        }
        public class _File
        {
            [Browsable(false)][Bindable(false)][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][EditorBrowsable(EditorBrowsableState.Never)]public Utilitiez.PushTypesEnum type { get; set; }
            public string body { get; set; }
            public string file_name { get; set; }
            [Browsable(false)][Bindable(false)][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][EditorBrowsable(EditorBrowsableState.Never)]public string file_type { get; set; }
            public string file_url { get; set; }
        }
    }
}
