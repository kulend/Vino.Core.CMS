//----------------------------------------------------------------
// Copyright (C) 2018 kulend 版权所有
//
// 文件名：SmsQueueDto.cs
// 功能描述：短信队列 数据传输类
//
// 创建者：kulend@qq.com
// 创建时间：2018-05-22 15:57
//
//----------------------------------------------------------------

using Ku.Core.CMS.Domain.Enum.Communication;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ku.Core.CMS.Domain.Dto.Communication
{
    /// <summary>
    /// 短信队列
    /// </summary>
    public class SmsQueueDto : BaseProtectedDto
    {
        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public EmSmsQueueStatus Status { set; get; }

        /// <summary>
        /// 短信ID
        /// </summary>
        public long SmsId { set; get; }

        public SmsDto Sms { set; get; }

        /// <summary>
        /// 过期时间
        /// </summary>
        [Display(Name = "过期时间")]
        public DateTime ExpireTime { set; get; }

        /// <summary>
        /// 发送时间
        /// </summary>
        [Display(Name = "发送时间")]
        public DateTime? SendTime { set; get; }

        [StringLength(2000)]
        [Display(Name = "发送回应")]
        public string Response { set; get; }
    }
}
