//----------------------------------------------------------------
// Copyright (C) 2018 vino 版权所有
//
// 文件名：WxMenuService.cs
// 功能描述：微信菜单 业务逻辑处理类
//
// 创建者：kulend@qq.com
// 创建时间：2018-02-04 19:13
//
//----------------------------------------------------------------

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ku.Core.CMS.Data.Repository.WeChat;
using Ku.Core.CMS.Domain;
using Ku.Core.CMS.Domain.Dto.WeChat;
using Ku.Core.CMS.Domain.Entity.WeChat;
using Ku.Core.CMS.IService.WeChat;
using Ku.Core.Infrastructure.Exceptions;
using Ku.Core.Infrastructure.Extensions;
using Ku.Core.Infrastructure.IdGenerator;

namespace Ku.Core.CMS.Service.WeChat
{
    public partial class WxMenuService : BaseService, IWxMenuService
    {
        protected readonly IWxMenuRepository _repository;

        #region 构造函数

        public WxMenuService(IWxMenuRepository repository)
        {
            this._repository = repository;
        }

        #endregion

        #region 自动生成的方法

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sort">排序</param>
        /// <returns>List<WxMenuDto></returns>
        public async Task<List<WxMenuDto>> GetListAsync(WxMenuSearch where, string sort)
        {
            var data = await _repository.QueryAsync(where.GetExpression(), sort ?? "CreateTime desc");
            return Mapper.Map<List<WxMenuDto>>(data);
        }

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="size">条数</param>
        /// <param name="where">查询条件</param>
        /// <param name="sort">排序</param>
        /// <returns>count：条数；items：分页数据</returns>
        public async Task<(int count, List<WxMenuDto> items)> GetListAsync(int page, int size, WxMenuSearch where, string sort)
        {
            var data = await _repository.PageQueryAsync(page, size, where.GetExpression(), sort ?? "CreateTime desc");
            return (data.count, Mapper.Map<List<WxMenuDto>>(data.items));
        }

        /// <summary>
        /// 根据主键取得数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task<WxMenuDto> GetByIdAsync(long id)
        {
            return Mapper.Map<WxMenuDto>(await this._repository.GetByIdAsync(id));
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        public async Task SaveAsync(WxMenuDto dto)
        {
            WxMenu model = Mapper.Map<WxMenu>(dto);
            if (model.Id == 0)
            {
                //新增
                model.Id = ID.NewID();
                model.CreateTime = DateTime.Now;
                model.IsDeleted = false;
                if (!model.IsIndividuation)
                {
                    model.MatchRule = new WxMenuMatchRule
                    {
                        TagId = "",
                        Sex = "",
                        Client = "",
                        Country = "",
                        Province = "",
                        City = "",
                        Language = "",
                    };
                }
                await _repository.InsertAsync(model);
            }
            else
            {
                //更新
                var item = await _repository.GetByIdAsync(model.Id);
                if (item == null)
                {
                    throw new VinoDataNotFoundException("无法取得微信菜单数据！");
                }

                //TODO:这里进行赋值
                item.Name = model.Name;
                item.MenuData = model.MenuData;
                item.IsIndividuation = model.IsIndividuation;
                if (!model.IsIndividuation)
                {
                    model.MatchRule = new WxMenuMatchRule
                    {
                        TagId = "",
                        Sex = "",
                        Client = "",
                        Country = "",
                        Province = "",
                        City = "",
                        Language = "",
                    };
                }

                if (item.MatchRule != null)
                {
                    item.MatchRule.TagId = model.MatchRule.TagId;
                    item.MatchRule.Sex = model.MatchRule.Sex;
                    item.MatchRule.Client = model.MatchRule.Client;
                    item.MatchRule.Country = model.MatchRule.Country;
                    item.MatchRule.Province = model.MatchRule.Province;
                    item.MatchRule.City = model.MatchRule.City;
                    item.MatchRule.Language = model.MatchRule.Language;
                }
                else
                {
                    item.MatchRule = new WxMenuMatchRule
                    {
                        TagId = model.MatchRule.TagId,
                        Sex = model.MatchRule.Sex,
                        Client = model.MatchRule.Client,
                        Country = model.MatchRule.Country,
                        Province = model.MatchRule.Province,
                        City = model.MatchRule.City,
                        Language = model.MatchRule.Language,
                    };
                }
                _repository.Update(item);
            }
            await _repository.SaveAsync();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task DeleteAsync(params long[] id)
        {
            if (await _repository.DeleteAsync(id))
            {
                await _repository.SaveAsync();
            }
        }

        /// <summary>
        /// 恢复数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task RestoreAsync(params long[] id)
        {
            if (await _repository.RestoreAsync(id))
            {
                await _repository.SaveAsync();
            }
        }

        #endregion

        #region 其他方法

        #endregion
    }
}