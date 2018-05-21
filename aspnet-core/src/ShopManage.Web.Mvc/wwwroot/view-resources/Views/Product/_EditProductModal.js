﻿ (function ($) {

    var _productService = abp.services.app.product;
    var _$modal = $('#ProductEditModal');
    var _$form = $('form[name=ProductEditForm]');

    function save() {

        if (!_$form.valid()) {
            return;
        }

        var dto = _$form.serializeFormToObject(); //序列化表单对象
        var data = {
            productEditDto: {
                Id: dto.Id,
                Code: '',
                Barcode: dto.Barcode,
                Price: dto.Price,
                OldPrice: dto.OldPrice,
                ShortName: dto.ShortName,
                Name: dto.Name,
                Size: dto.ShortName,
                ShortDescription: "",
                FullDescription: "",
                Picture: "http://p2.wmpic.me/article/2016/09/19/1474265209_uDMIqejD.jpg",
                Status: 1,
                dto.CategoryId = Number(dto.CategoryId),
                IsBest: Number(dto.IsBest != undefined),
                IsNew: Number(dto.IsNew != undefined),
                CommentTimes: 30,
                SoldNum: 20
            }
        }
        
        abp.ui.setBusy(_$modal);//避免重复提交
        //约定大于配置
        _productService.createOrUpdateProduct(data).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page to see new product!
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    }

    //Handle save button click
    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    //Handle enter key
    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    $.AdminBSB.input.activate(_$form);

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);