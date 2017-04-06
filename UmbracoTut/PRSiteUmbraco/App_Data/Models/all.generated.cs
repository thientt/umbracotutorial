using  System;
using  System.Collections.Generic;
using  System.Linq.Expressions;
using  System.Web;
using  Umbraco.Core.Models;
using  Umbraco.Core.Models.PublishedContent;
using  Umbraco.Web;
using  Umbraco.ModelsBuilder;
using  Umbraco.ModelsBuilder.Umbraco;
[assembly: PureLiveAssembly]
[assembly:ModelsBuilderAssembly(PureLive = true, SourceHash = "35215dbbe1e7a4a5")]
[assembly:System.Reflection.AssemblyVersion("0.0.0.1")]


// FILE: models.generated.cs

//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v3.0.6.97
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------















namespace Umbraco.Web.PublishedContentModels
{
	/// <summary>Home</summary>
	[PublishedContentModel("home")]
	public partial class Home : PublishedContentModel, IIntroControl, ILicenseControls
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "home";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public Home(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Home, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Intro: Enter you introduction text here
		///</summary>
		[ImplementPropertyType("intro")]
		public string Intro
		{
			get { return IntroControl.GetIntro(this); }
		}

		///<summary>
		/// By
		///</summary>
		[ImplementPropertyType("by")]
		public string By
		{
			get { return LicenseControls.GetBy(this); }
		}

		///<summary>
		/// Created
		///</summary>
		[ImplementPropertyType("created")]
		public string Created
		{
			get { return LicenseControls.GetCreated(this); }
		}

		///<summary>
		/// icon-heart
		///</summary>
		[ImplementPropertyType("iconHeart")]
		public string IconHeart
		{
			get { return LicenseControls.GetIconHeart(this); }
		}

		///<summary>
		/// Link
		///</summary>
		[ImplementPropertyType("link")]
		public string Link
		{
			get { return LicenseControls.GetLink(this); }
		}
	}

	/// <summary>Blog</summary>
	[PublishedContentModel("blog")]
	public partial class Blog : PublishedContentModel, ITitleControls
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "blog";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public Blog(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Blog, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Title: Enter the title for the page , if this is left  blank  the name of the page  will be used.
		///</summary>
		[ImplementPropertyType("title")]
		public string Title
		{
			get { return TitleControls.GetTitle(this); }
		}
	}

	/// <summary>Portfolio</summary>
	[PublishedContentModel("portfolio")]
	public partial class Portfolio : PublishedContentModel, ILicenseControls, ITitleControls
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "portfolio";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public Portfolio(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Portfolio, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// By
		///</summary>
		[ImplementPropertyType("by")]
		public string By
		{
			get { return LicenseControls.GetBy(this); }
		}

		///<summary>
		/// Created
		///</summary>
		[ImplementPropertyType("created")]
		public string Created
		{
			get { return LicenseControls.GetCreated(this); }
		}

		///<summary>
		/// icon-heart
		///</summary>
		[ImplementPropertyType("iconHeart")]
		public string IconHeart
		{
			get { return LicenseControls.GetIconHeart(this); }
		}

		///<summary>
		/// Link
		///</summary>
		[ImplementPropertyType("link")]
		public string Link
		{
			get { return LicenseControls.GetLink(this); }
		}

		///<summary>
		/// Title: Enter the title for the page , if this is left  blank  the name of the page  will be used.
		///</summary>
		[ImplementPropertyType("title")]
		public string Title
		{
			get { return TitleControls.GetTitle(this); }
		}
	}

	/// <summary>Services</summary>
	[PublishedContentModel("services")]
	public partial class Services : PublishedContentModel, ITitleControls
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "services";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public Services(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Services, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Title: Enter the title for the page , if this is left  blank  the name of the page  will be used.
		///</summary>
		[ImplementPropertyType("title")]
		public string Title
		{
			get { return TitleControls.GetTitle(this); }
		}
	}

	/// <summary>Content</summary>
	[PublishedContentModel("about")]
	public partial class About : PublishedContentModel, IBasicContentControl, ITitleControls
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "about";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public About(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<About, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Content Grid: Enter  the content for the page
		///</summary>
		[ImplementPropertyType("contentGrid")]
		public Newtonsoft.Json.Linq.JToken ContentGrid
		{
			get { return BasicContentControl.GetContentGrid(this); }
		}

		///<summary>
		/// Title: Enter the title for the page , if this is left  blank  the name of the page  will be used.
		///</summary>
		[ImplementPropertyType("title")]
		public string Title
		{
			get { return TitleControls.GetTitle(this); }
		}
	}

	/// <summary>Contact</summary>
	[PublishedContentModel("contact")]
	public partial class Contact : PublishedContentModel, ITitleControls
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "contact";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public Contact(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Contact, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Title: Enter the title for the page , if this is left  blank  the name of the page  will be used.
		///</summary>
		[ImplementPropertyType("title")]
		public string Title
		{
			get { return TitleControls.GetTitle(this); }
		}
	}

	// Mixin content Type 1101 with alias "introControl"
	/// <summary>Intro Controls</summary>
	public partial interface IIntroControl : IPublishedContent
	{
		/// <summary>Intro</summary>
		string Intro { get; }
	}

	/// <summary>Intro Controls</summary>
	[PublishedContentModel("introControl")]
	public partial class IntroControl : PublishedContentModel, IIntroControl
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "introControl";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public IntroControl(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<IntroControl, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Intro: Enter you introduction text here
		///</summary>
		[ImplementPropertyType("intro")]
		public string Intro
		{
			get { return GetIntro(this); }
		}

		/// <summary>Static getter for Intro</summary>
		public static string GetIntro(IIntroControl that) { return that.GetPropertyValue<string>("intro"); }
	}

	// Mixin content Type 1102 with alias "titleControls"
	/// <summary>Title Controls</summary>
	public partial interface ITitleControls : IPublishedContent
	{
		/// <summary>Title</summary>
		string Title { get; }
	}

	/// <summary>Title Controls</summary>
	[PublishedContentModel("titleControls")]
	public partial class TitleControls : PublishedContentModel, ITitleControls
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "titleControls";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public TitleControls(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<TitleControls, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Title: Enter the title for the page , if this is left  blank  the name of the page  will be used.
		///</summary>
		[ImplementPropertyType("title")]
		public string Title
		{
			get { return GetTitle(this); }
		}

		/// <summary>Static getter for Title</summary>
		public static string GetTitle(ITitleControls that) { return that.GetPropertyValue<string>("title"); }
	}

	// Mixin content Type 1103 with alias "licenseControls"
	/// <summary>License Controls</summary>
	public partial interface ILicenseControls : IPublishedContent
	{
		/// <summary>By</summary>
		string By { get; }

		/// <summary>Created</summary>
		string Created { get; }

		/// <summary>icon-heart</summary>
		string IconHeart { get; }

		/// <summary>Link</summary>
		string Link { get; }
	}

	/// <summary>License Controls</summary>
	[PublishedContentModel("licenseControls")]
	public partial class LicenseControls : PublishedContentModel, ILicenseControls
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "licenseControls";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public LicenseControls(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<LicenseControls, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// By
		///</summary>
		[ImplementPropertyType("by")]
		public string By
		{
			get { return GetBy(this); }
		}

		/// <summary>Static getter for By</summary>
		public static string GetBy(ILicenseControls that) { return that.GetPropertyValue<string>("by"); }

		///<summary>
		/// Created
		///</summary>
		[ImplementPropertyType("created")]
		public string Created
		{
			get { return GetCreated(this); }
		}

		/// <summary>Static getter for Created</summary>
		public static string GetCreated(ILicenseControls that) { return that.GetPropertyValue<string>("created"); }

		///<summary>
		/// icon-heart
		///</summary>
		[ImplementPropertyType("iconHeart")]
		public string IconHeart
		{
			get { return GetIconHeart(this); }
		}

		/// <summary>Static getter for icon-heart</summary>
		public static string GetIconHeart(ILicenseControls that) { return that.GetPropertyValue<string>("iconHeart"); }

		///<summary>
		/// Link
		///</summary>
		[ImplementPropertyType("link")]
		public string Link
		{
			get { return GetLink(this); }
		}

		/// <summary>Static getter for Link</summary>
		public static string GetLink(ILicenseControls that) { return that.GetPropertyValue<string>("link"); }
	}

	// Mixin content Type 1106 with alias "basicContentControl"
	/// <summary>Basic Content Control</summary>
	public partial interface IBasicContentControl : IPublishedContent
	{
		/// <summary>Content Grid</summary>
		Newtonsoft.Json.Linq.JToken ContentGrid { get; }
	}

	/// <summary>Basic Content Control</summary>
	[PublishedContentModel("basicContentControl")]
	public partial class BasicContentControl : PublishedContentModel, IBasicContentControl
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "basicContentControl";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public BasicContentControl(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<BasicContentControl, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Content Grid: Enter  the content for the page
		///</summary>
		[ImplementPropertyType("contentGrid")]
		public Newtonsoft.Json.Linq.JToken ContentGrid
		{
			get { return GetContentGrid(this); }
		}

		/// <summary>Static getter for Content Grid</summary>
		public static Newtonsoft.Json.Linq.JToken GetContentGrid(IBasicContentControl that) { return that.GetPropertyValue<Newtonsoft.Json.Linq.JToken>("contentGrid"); }
	}

	/// <summary>Folder</summary>
	[PublishedContentModel("Folder")]
	public partial class Folder : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "Folder";
		public new const PublishedItemType ModelItemType = PublishedItemType.Media;
#pragma warning restore 0109

		public Folder(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Folder, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Contents:
		///</summary>
		[ImplementPropertyType("contents")]
		public object Contents
		{
			get { return this.GetPropertyValue("contents"); }
		}
	}

	/// <summary>Image</summary>
	[PublishedContentModel("Image")]
	public partial class Image : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "Image";
		public new const PublishedItemType ModelItemType = PublishedItemType.Media;
#pragma warning restore 0109

		public Image(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Image, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Size
		///</summary>
		[ImplementPropertyType("umbracoBytes")]
		public string UmbracoBytes
		{
			get { return this.GetPropertyValue<string>("umbracoBytes"); }
		}

		///<summary>
		/// Type
		///</summary>
		[ImplementPropertyType("umbracoExtension")]
		public string UmbracoExtension
		{
			get { return this.GetPropertyValue<string>("umbracoExtension"); }
		}

		///<summary>
		/// Upload image
		///</summary>
		[ImplementPropertyType("umbracoFile")]
		public Umbraco.Web.Models.ImageCropDataSet UmbracoFile
		{
			get { return this.GetPropertyValue<Umbraco.Web.Models.ImageCropDataSet>("umbracoFile"); }
		}

		///<summary>
		/// Height
		///</summary>
		[ImplementPropertyType("umbracoHeight")]
		public string UmbracoHeight
		{
			get { return this.GetPropertyValue<string>("umbracoHeight"); }
		}

		///<summary>
		/// Width
		///</summary>
		[ImplementPropertyType("umbracoWidth")]
		public string UmbracoWidth
		{
			get { return this.GetPropertyValue<string>("umbracoWidth"); }
		}
	}

	/// <summary>File</summary>
	[PublishedContentModel("File")]
	public partial class File : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "File";
		public new const PublishedItemType ModelItemType = PublishedItemType.Media;
#pragma warning restore 0109

		public File(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<File, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Size
		///</summary>
		[ImplementPropertyType("umbracoBytes")]
		public string UmbracoBytes
		{
			get { return this.GetPropertyValue<string>("umbracoBytes"); }
		}

		///<summary>
		/// Type
		///</summary>
		[ImplementPropertyType("umbracoExtension")]
		public string UmbracoExtension
		{
			get { return this.GetPropertyValue<string>("umbracoExtension"); }
		}

		///<summary>
		/// Upload file
		///</summary>
		[ImplementPropertyType("umbracoFile")]
		public object UmbracoFile
		{
			get { return this.GetPropertyValue("umbracoFile"); }
		}
	}

	/// <summary>Member</summary>
	[PublishedContentModel("Member")]
	public partial class Member : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "Member";
		public new const PublishedItemType ModelItemType = PublishedItemType.Member;
#pragma warning restore 0109

		public Member(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Member, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Is Approved
		///</summary>
		[ImplementPropertyType("umbracoMemberApproved")]
		public bool UmbracoMemberApproved
		{
			get { return this.GetPropertyValue<bool>("umbracoMemberApproved"); }
		}

		///<summary>
		/// Comments
		///</summary>
		[ImplementPropertyType("umbracoMemberComments")]
		public string UmbracoMemberComments
		{
			get { return this.GetPropertyValue<string>("umbracoMemberComments"); }
		}

		///<summary>
		/// Failed Password Attempts
		///</summary>
		[ImplementPropertyType("umbracoMemberFailedPasswordAttempts")]
		public string UmbracoMemberFailedPasswordAttempts
		{
			get { return this.GetPropertyValue<string>("umbracoMemberFailedPasswordAttempts"); }
		}

		///<summary>
		/// Last Lockout Date
		///</summary>
		[ImplementPropertyType("umbracoMemberLastLockoutDate")]
		public string UmbracoMemberLastLockoutDate
		{
			get { return this.GetPropertyValue<string>("umbracoMemberLastLockoutDate"); }
		}

		///<summary>
		/// Last Login Date
		///</summary>
		[ImplementPropertyType("umbracoMemberLastLogin")]
		public string UmbracoMemberLastLogin
		{
			get { return this.GetPropertyValue<string>("umbracoMemberLastLogin"); }
		}

		///<summary>
		/// Last Password Change Date
		///</summary>
		[ImplementPropertyType("umbracoMemberLastPasswordChangeDate")]
		public string UmbracoMemberLastPasswordChangeDate
		{
			get { return this.GetPropertyValue<string>("umbracoMemberLastPasswordChangeDate"); }
		}

		///<summary>
		/// Is Locked Out
		///</summary>
		[ImplementPropertyType("umbracoMemberLockedOut")]
		public bool UmbracoMemberLockedOut
		{
			get { return this.GetPropertyValue<bool>("umbracoMemberLockedOut"); }
		}

		///<summary>
		/// Password Answer
		///</summary>
		[ImplementPropertyType("umbracoMemberPasswordRetrievalAnswer")]
		public string UmbracoMemberPasswordRetrievalAnswer
		{
			get { return this.GetPropertyValue<string>("umbracoMemberPasswordRetrievalAnswer"); }
		}

		///<summary>
		/// Password Question
		///</summary>
		[ImplementPropertyType("umbracoMemberPasswordRetrievalQuestion")]
		public string UmbracoMemberPasswordRetrievalQuestion
		{
			get { return this.GetPropertyValue<string>("umbracoMemberPasswordRetrievalQuestion"); }
		}
	}

}



// EOF
