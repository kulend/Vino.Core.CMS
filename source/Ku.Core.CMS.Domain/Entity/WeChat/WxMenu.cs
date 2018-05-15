﻿//----------------------------------------------------------------
// Copyright (C) 2018 kulend 版权所有
//
// 文件名：WxMenu.cs
// 功能描述：微信菜单 实体类
//
// 创建者：kulend@qq.com
// 创建时间：2018-02-04 19:13
//
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ku.Core.CMS.Domain.Entity.WeChat
{
    /// <summary>
    /// 微信菜单
    /// </summary>
    [Table("wechat_menu")]
    public class WxMenu : BaseProtectedEntity
    {
        /// <summary>
        /// 公众号ID
        /// </summary>
        [DataType("Hidden")]
        public long AccountId { get; set; }

        public WxAccount Account { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required, MaxLength(40)]
        [Display(Name = "名称")]
        public string Name { set; get; }

        /// <summary>
        /// 菜单数据
        /// </summary>
        [Display(Name = "菜单数据")]
        public string MenuData { set; get; }

        /// <summary>
        /// 最后发布时间
        /// </summary>
        public DateTime? PublishTime { set; get; }

        /// <summary>
        /// 是否个性化菜单
        /// </summary>
        [DefaultValue(false)]
        [Display(Name = "个性化菜单", Prompt = "是|否")]
        public bool IsIndividuation { set; get; } = false;

        /// <summary>
        /// 微信菜单ID
        /// </summary>
        [MaxLength(32)]
        [Display(Name = "微信菜单ID")]
        public string WxMenuId { set; get; }

        public WxMenuMatchRule MatchRule { set; get; }
    }

    public class WxMenuMatchRule
    {
        [MaxLength(20)]
        [Display(Name = "用户标签ID")]
        public string TagId { set; get; }

        [MaxLength(1)]
        [Display(Name = "性别")]
        public string Sex { set; get; }

        [MaxLength(1)]
        [Display(Name = "客户端")]
        public string Client { set; get; }

        [MaxLength(40)]
        [Display(Name = "国家")]
        public string Country { set; get; }

        [MaxLength(40)]
        [Display(Name = "省份")]
        public string Province { set; get; }

        [MaxLength(40)]
        [Display(Name = "城市")]
        public string City { set; get; }

        [MaxLength(10)]
        [Display(Name = "语言")]
        public string Language { set; get; }
    }
    
	/// <summary>
    /// 微信菜单 检索条件
    /// </summary>
	public class WxMenuSearch : BaseProtectedSearch<WxMenu>
    {
        public long? AccountId { set; get; }
    }
}
