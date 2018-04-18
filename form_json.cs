using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormTypeForm
{
    public class Theme
    {
        public string href { get; set; }
    }

    public class Workspace
    {
        public string href { get; set; }
    }

    public class Image
    {
        public string href { get; set; }
    }

    public class Meta
    {
        public bool allow_indexing { get; set; }
        public Image image { get; set; }
    }

    public class Settings
    {
        public bool is_public { get; set; }
        public bool is_trial { get; set; }
        public string language { get; set; }
        public string progress_bar { get; set; }
        public bool show_progress_bar { get; set; }
        public bool show_typeform_branding { get; set; }
        public Meta meta { get; set; }
    }

    public class Properties
    {
        public bool show_button { get; set; }
        public string description { get; set; }
        public string button_text { get; set; }
    }

    public class Attachment
    {
        public string type { get; set; }
        public string href { get; set; }
    }

    public class WelcomeScreen
    {
        public string @ref { get; set; }
        public string title { get; set; }
        public Properties properties { get; set; }
        public Attachment attachment { get; set; }
    }

    public class Properties2
    {
        public bool show_button { get; set; }
        public bool share_icons { get; set; }
        public string button_mode { get; set; }
        public string button_text { get; set; }
        public string redirect_url { get; set; }
    }

    public class Attachment2
    {
        public string type { get; set; }
        public string href { get; set; }
    }

    public class ThankyouScreen
    {
        public string @ref { get; set; }
        public string title { get; set; }
        public Properties2 properties { get; set; }
        public Attachment2 attachment { get; set; }
    }

    public class Validations
    {
        public bool required { get; set; }
        public int max_length { get; set; }
    }

    public class Attachment3
    {
        public string type { get; set; }
        public string href { get; set; }
    }

    public class Choice
    {
        public string id { get; set; }
        public string @ref { get; set; }
        public string label { get; set; }
        public Attachment3 attachment { get; set; }
    }

    public class Labels
    {
        public string left { get; set; }
        public string right { get; set; }
    }

    public class Properties4
    {
        public string description { get; set; }
        public bool? randomize { get; set; }
        public bool? allow_multiple_selection { get; set; }
        public bool? allow_other_choice { get; set; }
        public bool? vertical_alignment { get; set; }
        public List<Choice> choices { get; set; }
        public bool? supersized { get; set; }
        public bool? show_labels { get; set; }
        public bool? hide_marks { get; set; }
        public string button_text { get; set; }
        public string structure { get; set; }
        public string separator { get; set; }
        public int? steps { get; set; }
        public bool? start_at_one { get; set; }
        public Labels labels { get; set; }
        public string shape { get; set; }
    }

    public class Attachment4
    {
        public string type { get; set; }
        public string href { get; set; }
    }

    public class Field2
    {
        public string id { get; set; }
        public string title { get; set; }
        public string @ref { get; set; }
        public Validations validations { get; set; }
        public string type { get; set; }
        public Properties4 properties { get; set; }
        public Attachment4 attachment { get; set; }
    }

    public class Choice2
    {
        public string id { get; set; }
        public string @ref { get; set; }
        public string label { get; set; }
    }

    public class Properties3
    {
        public bool show_button { get; set; }
        public string button_text { get; set; }
        public List<Field2> fields { get; set; }
        public bool? hide_marks { get; set; }
        public bool? randomize { get; set; }
        public bool? allow_multiple_selection { get; set; }
        public bool? allow_other_choice { get; set; }
        public bool? vertical_alignment { get; set; }
        public List<Choice2> choices { get; set; }
        public string structure { get; set; }
        public string separator { get; set; }
    }

    public class Attachment5
    {
        public string type { get; set; }
        public string href { get; set; }
    }

    public class Validations2
    {
        public bool required { get; set; }
    }

    public class Field
    {
        public string id { get; set; }
        public string title { get; set; }
        public string @ref { get; set; }
        public Properties3 properties { get; set; }
        public Attachment5 attachment { get; set; }
        public string type { get; set; }
        public Validations2 validations { get; set; }
    }

    public class To
    {
        public string type { get; set; }
        public string value { get; set; }
    }

    public class Details
    {
        public To to { get; set; }
    }

    public class Condition
    {
        public string op { get; set; }
        public List<object> vars { get; set; }
    }

    public class Action
    {
        public string action { get; set; }
        public Details details { get; set; }
        public Condition condition { get; set; }
    }

    public class Logic
    {
        public string type { get; set; }
        public string @ref { get; set; }
        public List<Action> actions { get; set; }
    }

    public class Links
    {
        public string display { get; set; }
    }

    public class RootObject
    {
        public string id { get; set; }
        public string title { get; set; }
        public Theme theme { get; set; }
        public Workspace workspace { get; set; }
        public Settings settings { get; set; }
        public List<WelcomeScreen> welcome_screens { get; set; }
        public List<ThankyouScreen> thankyou_screens { get; set; }
        public List<Field> fields { get; set; }
        public List<Logic> logic { get; set; }
        public Links _links { get; set; }
    }
}