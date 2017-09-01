using System;
using System.Text;

namespace WIMARTS.DB.BusinessObjects
{
	[Serializable()]
	public partial class TemplateDesigns
	{
		private string _TemplateName;

		public string TemplateName
		{
			get { return _TemplateName; }
			set { _TemplateName = value; }
		}

		private string _Template;

		public string Template
		{
			get { return _Template; }
			set { _Template = value; }
		}

		private Nullable<DateTime> _CreateDate;

		public Nullable<DateTime> CreateDate
		{
			get { return _CreateDate; }
			set { _CreateDate = value; }
		}

		private Nullable<DateTime> _LastUpdatedDate;

		public Nullable<DateTime> LastUpdatedDate
		{
			get { return _LastUpdatedDate; }
			set { _LastUpdatedDate = value; }
		}

		public TemplateDesigns()
		{ }

		public TemplateDesigns(string TemplateName,string Template,Nullable<DateTime> CreateDate,Nullable<DateTime> LastUpdatedDate)
		{
			this.TemplateName = TemplateName;
			this.Template = Template;
			this.CreateDate = CreateDate;
			this.LastUpdatedDate = LastUpdatedDate;
		}

		public override string ToString()
		{
			return "TemplateName = " + TemplateName + ",Template = " + Template + ",CreateDate = " + CreateDate.ToString() + ",LastUpdatedDate = " + LastUpdatedDate.ToString();
		}

		public class TemplateNameComparer : System.Collections.Generic.IComparer<TemplateDesigns>
		{
			public SorterMode SorterMode;
			public TemplateNameComparer()
			{ }
			public TemplateNameComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<TemplateDesigns> Membres
			int System.Collections.Generic.IComparer<TemplateDesigns>.Compare(TemplateDesigns x, TemplateDesigns y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.TemplateName.CompareTo(x.TemplateName);
				}
				else
				{
					return x.TemplateName.CompareTo(y.TemplateName);
				}
			}
			#endregion
		}
		public class TemplateComparer : System.Collections.Generic.IComparer<TemplateDesigns>
		{
			public SorterMode SorterMode;
			public TemplateComparer()
			{ }
			public TemplateComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<TemplateDesigns> Membres
			int System.Collections.Generic.IComparer<TemplateDesigns>.Compare(TemplateDesigns x, TemplateDesigns y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.Template.CompareTo(x.Template);
				}
				else
				{
					return x.Template.CompareTo(y.Template);
				}
			}
			#endregion
		}
	}
}
