//----------------------------------------------------------------
// Copyright (C) 2018 kulend 版权所有
//
// 文件名：NoticeDto.cs
// 功能描述：公告 数据传输类
//
// 创建者：kulend@qq.com
// 创建时间：2018-04-18 09:55
//
//----------------------------------------------------------------

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ku.Core.CMS.Domain.Enum;
using Ku.Core.Infrastructure.Attributes;

namespace Ku.Core.CMS.Domain.Dto.System
{
    /// <summary>
    /// 公告
    /// </summary>
    public class NoticeDto : BaseProtectedDto
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Required, StringLength(200)]
        [Display(Name = "标题")]
        public string Title { set; get; }

        /// <summary>
        /// 是否发布
        /// </summary>
        [DefaultValue(false)]
        [Display(Name = "是否发布", Prompt = "是|否")]
        public bool IsPublished { set; get; } = false;

        /// <summary>
        /// 发布时间
        /// </summary>
        [Display(Name = "发布时间")]
        public DateTime? PublishedTime { set; get; }

        /// <summary>
        /// 置顶序号
        /// </summary>
        [Display(Name = "置顶序号")]
        public int StickyNum { set; get; }

        /// <summary>
        /// 详情模式
        /// </summary>
        [Display(Name = "详情模式")]
        public EmDefaultContentType ContentType { set; get; }

        /// <summary>
        /// 详情内容
        /// </summary>
        [Display(Name = "详情内容")]
        public string Content { set; get; }
    }
}
