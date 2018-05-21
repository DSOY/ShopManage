//import { Number } from "core-js/library/web/timers";

(function () {
    $(function () {

        var _productService = abp.services.app.product;
        var _$modal = $('#ProductCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate();

        $('#RefreshButton').click(function () {
            refreshProductList();
        });

        $('.delete-product').click(function () {
            var productId = $(this).attr("data-product-id");
            var Name = $(this).attr('data-product-name');

            deleteProduct(productId, Name);
        });

        //编辑
        $('.edit-product').click(function (e) {
            var productId = $(this).attr("data-product-id");

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Product/EditProductModal?productId=' + productId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#ProductEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        //添加
        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            //验证
            if (!_$form.valid()) {
                return;
            }

            var dto = _$form.serializeFormToObject(); //序列化表单对象
            dto.Id = null;
            dto.Code = '';
            dto.Barcode = '';
            dto.Picture = "http://p2.wmpic.me/article/2016/09/19/1474265209_uDMIqejD.jpg";
            dto.CommentTimes = 0;
            dto.SoldNum = 0;
            dto.ShortDescription ="";
            dto.FullDescription = "";
            dto.Status = 1;
            dto.CategoryId = Number(dto.CategoryId);
            dto.IsBest = Number(dto.IsBest != undefined);
            dto.IsNew = Number(dto.IsNew != undefined);

            var data = {
                productEditDto: dto
            }

            abp.ui.setBusy(_$modal);//避免重复提交
            //约定大于配置
            _productService.createOrUpdateProduct(data).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new product!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshProductList() {
            location.reload(true); //reload page to see new product!
        }

        function deleteProduct(productId, Name) {
            abp.message.confirm(
                "确定删除 '" + Name + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        //var data = { id: Number(productId) };
                        _productService.deteleProduct({ id: Number(productId)}).done(function () {
                            refreshProductList();
                        });
                    }
                }
            );
        }
    });
})();