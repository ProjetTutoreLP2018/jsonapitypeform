using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormTypeForm
{
    public class Attachment
    {
        public string type { get; set; }
        public string href { get; set; }
    }

    public class Choice
    {
        public string id { get; set; }
        public string label { get; set; }
        public Attachment attachment { get; set; }
    }

    public class Labels
    {
        public string left { get; set; }
        public string right { get; set; }
        public string center { get; set; }
    }

    public class Price
    {
        public string type { get; set; }
        public string value { get; set; }
    }

    public class Properties
    {
        public string description { get; set; }
        public List<Choice> choices { get; set; }
        public List<object> fields { get; set; }
        public bool allow_multiple_selection { get; set; }
        public bool randomize { get; set; }
        public bool allow_other_choice { get; set; }
        public bool vertical_alignment { get; set; }
        public bool supersized { get; set; }
        public bool show_labels { get; set; }
        public bool alphabetical_order { get; set; }
        public bool hide_marks { get; set; }
        public string button_text { get; set; }
        public int steps { get; set; }
        public string shape { get; set; }
        public Labels labels { get; set; }
        public bool start_at_one { get; set; }
        public string structure { get; set; }
        public string separator { get; set; }
        public string currency { get; set; }
        public Price price { get; set; }
        public bool show_button { get; set; }
    }

    public class Validations
    {
        public bool required { get; set; }
        public int max_length { get; set; }
        public int min_value { get; set; }
        public int max_value { get; set; }
    }

    public class Attachment2
    {
        public string type { get; set; }
        public string href { get; set; }
        public double scale { get; set; }
    }

    public class Field
    {
        public string @ref { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public Properties properties { get; set; }
        public Validations validations { get; set; }
        public Attachment2 attachment { get; set; }
    }

    public class To
    {
        public string type { get; set; }
        public string value { get; set; }
    }

    public class Target
    {
        public string type { get; set; }
        public string value { get; set; }
    }

    public class Value
    {
        public string type { get; set; }
        public int value { get; set; }
    }

    public class Details
    {
        public To to { get; set; }
        public Target target { get; set; }
        public Value value { get; set; }
    }

    public class Value2
    {
    }

    public class Var
    {
        public string type { get; set; }
        public Value2 value { get; set; }
    }

    public class Condition
    {
        public string op { get; set; }
        public List<Var> vars { get; set; }
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

    public class Theme
    {
        public string href { get; set; }
    }

    public class Workspace
    {
        public string href { get; set; }
    }

    public class Links
    {
        public string display { get; set; }
    }

    public class Image
    {
        public string href { get; set; }
    }

    public class Meta
    {
        public bool allow_indexing { get; set; }
        public string description { get; set; }
        public Image image { get; set; }
    }

    public class Self
    {
        public bool enabled { get; set; }
        public List<string> recipients { get; set; }
        public string reply_to { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
    }

    public class Respondent
    {
        public bool enabled { get; set; }
        public string recipient { get; set; }
        public List<string> reply_to { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
    }

    public class Notifications
    {
        public Self self { get; set; }
        public Respondent respondent { get; set; }
    }

    public class Settings
    {
        public string language { get; set; }
        public bool is_public { get; set; }
        public string progress_bar { get; set; }
        public bool show_progress_bar { get; set; }
        public bool show_typeform_branding { get; set; }
        public Meta meta { get; set; }
        public string redirect_after_submit_url { get; set; }
        public string google_analytics { get; set; }
        public Notifications notifications { get; set; }
    }

    public class RootObject
    {
        public string id { get; set; }
        public string title { get; set; }
        public string language { get; set; }
        public List<Field> fields { get; set; }
        public List<string> hidden { get; set; }
        public List<Logic> logic { get; set; }
        public Theme theme { get; set; }
        public Workspace workspace { get; set; }
        public Links _links { get; set; }
        public Settings settings { get; set; }
    }
}
