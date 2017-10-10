using System;
namespace Model
{
	/// <summary>
	/// 客户表
	/// </summary>
	[Serializable]
	public partial class tb_user:BaseModel
	{
		public tb_user()
		{}
		#region Model
		private string _id;
		private string _code;
		private string _nickname;
		private string _phonenum;
		private string _address;
		private decimal? _longitude;
		private decimal? _latitude;
		private string _remark;
		private DateTime? _createdate;
		private DateTime? _updatedate;
		private string _pwd;
		private string _province;
		private string _city;
		private string _county;
		private string _location;
		private string _sex;
		private string _job;
		private int? _age;
		private string _constellation;
		private string _hav;
		private int? _tall;
		private string _schedule;
		private string _sgin;
		private string _hobby;
		private DateTime? _birth;
		private string _wx;
		private string _issingle;
		private string _company;
		private string _companyaddress;
		private string _realname;
		private string _avatar;
		private bool _isdel;
		private DateTime? _addtime;
		/// <summary>
		/// 
		/// </summary>
		public string id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 唯一编码
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 联系人名字
		/// </summary>
		public string nickname
		{
			set{ _nickname=value;}
			get{return _nickname;}
		}
		/// <summary>
		/// 联系号码（登陆账号）
		/// </summary>
		public string phonenum
		{
			set{ _phonenum=value;}
			get{return _phonenum;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 经度
		/// </summary>
		public decimal? longitude
		{
			set{ _longitude=value;}
			get{return _longitude;}
		}
		/// <summary>
		/// 纬度
		/// </summary>
		public decimal? latitude
		{
			set{ _latitude=value;}
			get{return _latitude;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createdate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 更新时间
		/// </summary>
		public DateTime? updatedate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		/// <summary>
		/// 省
		/// </summary>
		public string province
		{
			set{ _province=value;}
			get{return _province;}
		}
		/// <summary>
		/// 市
		/// </summary>
		public string city
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 县
		/// </summary>
		public string county
		{
			set{ _county=value;}
			get{return _county;}
		}
		/// <summary>
		/// 所在地
		/// </summary>
		public string location
		{
			set{ _location=value;}
			get{return _location;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 职业
		/// </summary>
		public string job
		{
			set{ _job=value;}
			get{return _job;}
		}
		/// <summary>
		/// 年龄
		/// </summary>
		public int? age
		{
			set{ _age=value;}
			get{return _age;}
		}
		/// <summary>
		/// 星座
		/// </summary>
		public string constellation
		{
			set{ _constellation=value;}
			get{return _constellation;}
		}
		/// <summary>
		/// 体重
		/// </summary>
		public string hav
		{
			set{ _hav=value;}
			get{return _hav;}
		}
		/// <summary>
		/// 身高
		/// </summary>
		public int? tall
		{
			set{ _tall=value;}
			get{return _tall;}
		}
		/// <summary>
		/// 档期
		/// </summary>
		public string schedule
		{
			set{ _schedule=value;}
			get{return _schedule;}
		}
		/// <summary>
		/// 个性签名
		/// </summary>
		public string sgin
		{
			set{ _sgin=value;}
			get{return _sgin;}
		}
		/// <summary>
		/// 兴趣爱好
		/// </summary>
		public string hobby
		{
			set{ _hobby=value;}
			get{return _hobby;}
		}
		/// <summary>
		/// 生日
		/// </summary>
		public DateTime? birth
		{
			set{ _birth=value;}
			get{return _birth;}
		}
		/// <summary>
		/// 微信号
		/// </summary>
		public string wx
		{
			set{ _wx=value;}
			get{return _wx;}
		}
		/// <summary>
		/// 是否单身
		/// </summary>
		public string issingle
		{
			set{ _issingle=value;}
			get{return _issingle;}
		}
		/// <summary>
		/// 所在单位
		/// </summary>
		public string company
		{
			set{ _company=value;}
			get{return _company;}
		}
		/// <summary>
		/// 单位地址
		/// </summary>
		public string companyaddress
		{
			set{ _companyaddress=value;}
			get{return _companyaddress;}
		}
		/// <summary>
		/// 真实姓名
		/// </summary>
		public string realname
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string avatar
		{
			set{ _avatar=value;}
			get{return _avatar;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isdel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

