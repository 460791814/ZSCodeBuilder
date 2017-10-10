using System;
namespace Model
{
	/// <summary>
	/// 微博
	/// </summary>
	[Serializable]
	public partial class tb_weibolicense:BaseModel
	{
		public tb_weibolicense()
		{}
		#region Model
		private string _id;
		private string _openid;
		private DateTime? _addtime;
		private int? _subscribe;
		private string _nickname;
		private int? _sex;
		private string _city;
		private string _country;
		private string _province;
		private string _language;
		private string _headimgurl;
		private string _subscribe_time;
		private string _unionid;
		private string _code;
		private string _usertype;
		private string _userid;
		/// <summary>
		/// 
		/// </summary>
		public string id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 公众号ID
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 订阅信息
		/// </summary>
		public int? subscribe
		{
			set{ _subscribe=value;}
			get{return _subscribe;}
		}
		/// <summary>
		/// 昵称
		/// </summary>
		public string nickname
		{
			set{ _nickname=value;}
			get{return _nickname;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public int? sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 城市
		/// </summary>
		public string city
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 国家
		/// </summary>
		public string country
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		/// 省份
		/// </summary>
		public string province
		{
			set{ _province=value;}
			get{return _province;}
		}
		/// <summary>
		/// 语言
		/// </summary>
		public string language
		{
			set{ _language=value;}
			get{return _language;}
		}
		/// <summary>
		/// 表头图片地址
		/// </summary>
		public string headimgurl
		{
			set{ _headimgurl=value;}
			get{return _headimgurl;}
		}
		/// <summary>
		/// 订阅时间
		/// </summary>
		public string subscribe_time
		{
			set{ _subscribe_time=value;}
			get{return _subscribe_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string unionid
		{
			set{ _unionid=value;}
			get{return _unionid;}
		}
		/// <summary>
		/// 编号对应客户表或者维护表外键
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 用户类型（客户、维护）
		/// </summary>
		public string userType
		{
			set{ _usertype=value;}
			get{return _usertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		#endregion Model

	}
}

