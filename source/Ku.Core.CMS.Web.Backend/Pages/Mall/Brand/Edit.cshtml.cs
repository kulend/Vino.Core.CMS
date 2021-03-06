using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ku.Core.CMS.Domain.Dto.Mall;
using Ku.Core.CMS.Domain.Entity.Mall;
using Ku.Core.CMS.IService.Mall;
using Ku.Core.CMS.Web.Base;
using Ku.Core.CMS.Web.Security;
using Ku.Core.Infrastructure.Exceptions;

namespace Ku.Core.CMS.Web.Backend.Pages.Mall.Brand
{
    /// <summary>
    /// 品牌 编辑页面
    /// </summary>
    [Auth("mall.brand")]
    public class EditModel : BasePage
    {
        private readonly IBrandService _service;

        public EditModel(IBrandService service)
        {
            this._service = service;
        }

        [BindProperty]
        public BrandDto Dto { set; get; }

        /// <summary>
        /// 取得数据
        /// </summary>
        [Auth("edit")]
        public async Task OnGetAsync(long? id)
        {
            if (id.HasValue)
            {
                Dto = await _service.GetByIdWithRefAsync(id.Value);
                if (Dto == null)
                {
                    throw new KuDataNotFoundException();
                }
                ViewData["Mode"] = "Edit";
            }
            else
            {
                Dto = new BrandDto();
                Dto.Categorys = new List<ProductCategoryDto>();
                ViewData["Mode"] = "Add";
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        [Auth("edit")]
        public async Task<IActionResult> OnPostAsync(long[] CategoryIds)
        {
            if (!ModelState.IsValid)
            {
                throw new KuArgNullException();
            }

            await _service.SaveAsync(Dto, CategoryIds);
            return Json(true);
        }
    }
}
